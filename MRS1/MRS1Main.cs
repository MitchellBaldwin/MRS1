/*
 * Mobile Robot System Host Controller (MRS-HOST)
 * RMB - 11 Jan 2016
 * 
 * 
 * Test mode	(0x00)	Measures the position of a potentiometer and report it to back to the PC host
 * TRex mode	(0x01)	TRex controlled over i2c bus
 * RC mode		(0x02)	TRex controlled by RC radio
 * 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MRS1
{
    public partial class MRS1 : Form
    {
        #region Message type definitions
        public const Byte CommFramingByte = 0x00;           // Identifies the end of a serial message 

        public const Byte TextMsgMsgType = 0x00;            // Payload consists of a text message - bidirectional
        public const Byte SetModeMsgType = 0x01;

        public const Byte TRexCmdMsgType = 0x10;
        public const Byte TRexStatMsgType = 0x11;

        #endregion Message type definitions

        // Buffers for serial communication with the embedded device
        public const Byte PACKET_SIZE = 30;
        public const Byte ENCODED_PACKET_SIZE = PACKET_SIZE + 1;
        public const Byte COMM_BUFFER_SIZE = ENCODED_PACKET_SIZE + 1;

        Byte[] packetBuffer = new Byte[PACKET_SIZE];
        Byte[] encodedPacketBuffer = new Byte[ENCODED_PACKET_SIZE];
        Byte[] inBuffer = new Byte[COMM_BUFFER_SIZE];
        Byte[] outBuffer = new Byte[COMM_BUFFER_SIZE];
        Byte[] dummy = new Byte[1];

        Byte receivedMessageType = 0xFF;

        TRex tRex = new TRex();

        ToolStripButton[] modeButtons = new ToolStripButton[3];

        // Set the display update timer interval to 100 ms
        public const int RESPONSE_TIMEOUT = 50; // Number of display update timer intervals to wait for a reply from the MRS-MCC
        private int displayUpdatePeriod = 10;   // Sets the number of timer intervals between updates to the displays
        private int displayUpdateTimerTicks = 0;           // Counter to implement the interval between display updates

        #region Flags
        // Switch for displaying contents of commands sent to the MRS Main Controller
        Boolean showAllCommandBufferUpdates = true;
        public Boolean ShowAllMRSMCCommandBufferUpdates
        {
            get { return showAllCommandBufferUpdates; }
            set { showAllCommandBufferUpdates = value; }
        }

        // Switch or displaying contents of the communications buffer incoming from the MRS Main Controller
        Boolean showInBufferUpdates = true;
        public Boolean ShowInBufferUpdates
        {
            get { return showInBufferUpdates; }
            set { showInBufferUpdates = value; }
        }

        // Switch or displaying contents of the communications buffer outgoing to the MRS Main Controller
        Boolean showOutBufferUpdates = true;
        public Boolean ShowOutBufferUpdates
        {
            get { return showOutBufferUpdates; }
            set { showOutBufferUpdates = value; }
        }

        // Flag indicating that a new message has been received from the MRS Main Controller
        Boolean mrsmcMessageReceived = false;
        public Boolean MrsmcMessageReceived
        {
            get { return mrsmcMessageReceived; }
            set { mrsmcMessageReceived = value; }
        }

        // Flag indicating a timeout error occured in the thread handling serial communications with the MRS Main Controller
        Boolean commTimeoutErrorFlag = false;
        public Boolean CommTimeoutErrorFlag
        {
            get { return commTimeoutErrorFlag; }
            set { commTimeoutErrorFlag = value; }
        }

        // Flag indicating a framing error occured in the thread handling serial communications with the MRS Main Controller
        Boolean commFramingErrorFlag = false;
        public Boolean CommFramingErrorFlag
        {
            get { return commFramingErrorFlag; }
            set { commFramingErrorFlag = value; }
        }

        // Flag indicating a framing error occured in the thread handling serial communications with the MRS Main Controller
        Boolean commChecksumErrorFlag = false;
        public Boolean CommChecksumErrorFlag
        {
            get { return commChecksumErrorFlag; }
            set { commChecksumErrorFlag = value; }
        }
        
        // Flag indicating there is a new TRex motor controller command
        Boolean newTRexMotorControllerCommand = false;
        public Boolean NewTRexMotorControllerCommand
        {
            get { return newTRexMotorControllerCommand; }
            set { newTRexMotorControllerCommand = value; }
        }

        // Flag indicating a Motor Controller status message has been sent and we are awaiting the response
        //(used to detect a timeout when awaiting receipt of a status update from the Motor Controller)
        Boolean mrsmccStatusRequestPending = false;
        public Boolean MRSMCCStatusRequestPending
        {
            get { return mrsmccStatusRequestPending; }
            set { mrsmccStatusRequestPending = value; }
        }
        #endregion Flags

        #region Form level functions
        public MRS1()
        {
            InitializeComponent();
        }

        private void MRS1_Load(object sender, EventArgs e)
        {
            MRSMainControllerSerialPort.PortName = comPortToolStripComboBox.Text;
            mcspBaudRateDisplayLabel.Text = MRSMainControllerSerialPort.BaudRate.ToString();
            mcspDataBitsDisplayLabel.Text = MRSMainControllerSerialPort.DataBits.ToString();
            mcspParityDisplayLabel.Text = MRSMainControllerSerialPort.Parity.ToString();
            mcspStopBitsDisplayLabel.Text = MRSMainControllerSerialPort.StopBits.ToString();

            MRSMainControllerSerialPort.ReceivedBytesThreshold = 32;
            MRSMainControllerSerialPort.ReadTimeout = 500;
            MRSMainControllerSerialPort.WriteTimeout = 500;

            steeringPictureBox.Image = new Bitmap(steeringPictureBox.Width, steeringPictureBox.Height);

            modeButtons[0] = testToolStripButton;
            modeButtons[1] = i2cToolStripButton;
            modeButtons[2] = rcToolStripButton;
        }

        private void MRS1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.comPortTexrApplicationSetting = comPortToolStripComboBox.Text;
            Properties.Settings.Default.Save();
        }
        #endregion Form level functions

        #region Serial communications functions
        // Serial port callback function to handle the receipt of messages from the Motor Controller
        private void MRSMainControllerSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            if (MRSMainControllerSerialPort.BytesToRead < COMM_BUFFER_SIZE)
            {
                Console.WriteLine("False call to DataReceived");
                return;
            }
            try
            {
                MRSMainControllerSerialPort.Read(inBuffer, 0, COMM_BUFFER_SIZE);
                commTimeoutErrorFlag = false;      // If no exception was thrown then we should have receiced a complete buffer (COMM_BUFFER_SIZE bits)

                // Check that the first byte contains the CommStartByte
                if (inBuffer[COMM_BUFFER_SIZE - 1] != CommFramingByte)
                {
                    commFramingErrorFlag = true;
                    Console.WriteLine("Serial port framing error");
                    return;
                }
                else
                {
                    commFramingErrorFlag = false;
                }

                // A properly framed serial packet has arrived, so decode it
                for (int i = 0; i < ENCODED_PACKET_SIZE; ++i)
                {
                    encodedPacketBuffer[i] = inBuffer[i];
                }
                packetBuffer = COBSCodec.decode(encodedPacketBuffer);

                // Check that the checksums match
                Byte checkSum = 0;
                for (int i = 0; i < PACKET_SIZE - 1; ++i)
                {
                    checkSum += packetBuffer[i];
                }
                if (checkSum == packetBuffer[PACKET_SIZE - 1])
                {
                    commChecksumErrorFlag = false;
                }
                else
                {
                    commChecksumErrorFlag = true;
                    Console.WriteLine("Serial port checksum error");
                    return;
                }

                // If no errors then set flag indicating that a valid message has been received
                mrsmcMessageReceived = true;
                receivedMessageType = packetBuffer[0x00];
            }
            catch (System.TimeoutException)
            {
                commTimeoutErrorFlag = true;
                Console.WriteLine("Serial port timeout");
                mrsmcMessageReceived = false;
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
                serialConnectToolStripButton.Checked = false;
                toggleDisplayUpdateTimerToolStripButton.Checked = false;
            }

        }

        // Helper function to format the outBuffer with a Motor Controller message / command
        private void BuildCommMessage(Byte msgType, Byte[] buffer)
        {
            Byte checkSum = 0;

            for (int i = 0; i < PACKET_SIZE; ++i)
            {
                packetBuffer[i] = 0;
            }

            packetBuffer[0] = msgType;
            for (int i = 0; i < buffer.Length; ++i)
            {
                packetBuffer[1 + i] = buffer[i];
                checkSum += buffer[i];
            }
            checkSum = 0x00;
            for (int i = 0; i < PACKET_SIZE - 1; ++i)
            {
                checkSum += packetBuffer[i];
            }
            packetBuffer[PACKET_SIZE - 1] = checkSum;

            encodedPacketBuffer = COBSCodec.encode(packetBuffer);
            for (int i = 0; i < COMM_BUFFER_SIZE - 1; ++i)
            {
                outBuffer[i] = encodedPacketBuffer[i];
            }
            outBuffer[COMM_BUFFER_SIZE - 1] = 0x00;
        }

        // Helper function to send the contents of the outBuffer to the CLCPR Device
        private void SendCommandMessage()
        {
            try
            {
                MRSMainControllerSerialPort.Write(outBuffer, 0, COMM_BUFFER_SIZE);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
            }
            if (ShowOutBufferUpdates)
            {
                DisplayOutBufferToConsole();
            }
        }

        private void BuildAndSendCommandMessage(Byte msgType, Byte[] buffer)
        {
            BuildCommMessage(msgType, buffer);
            SendCommandMessage();
        }

        
        #endregion Serial communications functions

        private void mcspTimer_Tick(object sender, EventArgs e)
        {
            #region Communication status display
            // Display communication error status
            commErrorDisplayLabel.ForeColor = Color.Black;
            if (serialConnectToolStripButton.Checked)
            {
                commErrorDisplayLabel.Text = "Connected - no errors";
            }
            else
            {
                commErrorDisplayLabel.Text = "Not connected";
            }
            if (commTimeoutErrorFlag)
            {
                commErrorDisplayLabel.ForeColor = Color.Red;
                commErrorDisplayLabel.Text = "Serial port timeout";
                commTimeoutErrorFlag = false;
            }
            if (commFramingErrorFlag)
            {
                commErrorDisplayLabel.ForeColor = Color.Red;
                commErrorDisplayLabel.Text = "Serial port framing error";
                commFramingErrorFlag = false;
            }
            if (commChecksumErrorFlag)
            {
                commErrorDisplayLabel.ForeColor = Color.Red;
                commErrorDisplayLabel.Text = "Serial port checksum error";
                commChecksumErrorFlag = false;
            }
            if (commTimeoutErrorFlag)
            {
                commErrorDisplayLabel.ForeColor = Color.Red;
                commErrorDisplayLabel.Text = "Serial port timeout";
            }
            #endregion Communication status display

            #region Handle any new message from the MRS Master Controller
            if (mrsmcMessageReceived)
            {
                switch (receivedMessageType)
                {
                    case TextMsgMsgType:
                        String message = "";
                        for (int i = 1; i < PACKET_SIZE - 1; ++i)
                        {
                            if (packetBuffer[i] != 0x00)
                            {
                                message += (char)packetBuffer[i];
                            }
                        }
                        textMessageTextBox.AppendText(message);
                        Console.Write(message);
                        break;

                    case SetModeMsgType:

                        break;

                    case TRexCmdMsgType:

                        break;

                    case TRexStatMsgType:
                        for (int i = 0; i < TRex.TREX_STATUS_BUFFER_SIZE; ++i)
                        {
                            tRex.StatusBuffer[i] = packetBuffer[i + 1];
                        }
                        if (ShowInBufferUpdates)
                        {
                            DisplayInBufferToConsole();
                        }
                        mrsmccStatusRequestPending = false;
                        break;

                    default:

                        break;
                }
                
                // Message handled; reset flag:
                mrsmcMessageReceived = false;

            }                                                   // Serial Communication with Master Controller
            #endregion Handle any new message from the MRS Master Controller

            #region Scheduler
            // If any part of the command set for the motor controller has been updated then build a new message and send it
            // Otherwise performother scheduled activities
            if (newTRexMotorControllerCommand)
            {
                BuildAndSendCommandMessage(TRexCmdMsgType, tRex.CommandBuffer);
                newTRexMotorControllerCommand = false;
                displayUpdateTimerTicks = 0;
            }
            else
            {
                ++displayUpdateTimerTicks;

                if (!mrsmccStatusRequestPending)
                {
                    if (displayUpdateTimerTicks % displayUpdatePeriod == 0)
                    {
                        BuildAndSendCommandMessage(TRexStatMsgType, dummy);
                        mrsmccStatusRequestPending = true;
                    }
                }
                else
                {
                    if (displayUpdateTimerTicks >= RESPONSE_TIMEOUT)
                    {
                        commErrorDisplayLabel.ForeColor = Color.Orange;
                        commErrorDisplayLabel.Text = "MRS-MCC status update timeout";
                        Console.WriteLine("MRS-MCC status update timeout");
                        mrsmccStatusRequestPending = false;
                        displayUpdateTimerTicks = 0;
                    }
                }

            }
            #endregion Scheduler

            #region Update graphic displays
            using (Graphics g = Graphics.FromImage(steeringPictureBox.Image))
            {
                // Create pen & brush
                Pen blackPen = new Pen(Color.Black, 1);
                SolidBrush blackBrush = new SolidBrush(Color.Black);

                g.DrawEllipse(blackPen, 43, 15, 10, 20);

                // Create rectangle for ellipse
                Rectangle rect = new Rectangle(0, 0, 95, 49);

                // Create start and sweep angles. 
                float startAngle = 265.0F;
                float sweepAngle = 10.0F;

                // Draw pie to screen
                g.FillPie(blackBrush, rect, startAngle, sweepAngle);
            }
            steeringPictureBox.Invalidate();
            #endregion Update motor control graphic display

            #region Update numerical and text data displays
            if (ShowAllMRSMCCommandBufferUpdates)
            {
                DisplayAllCommBuffersToGUI();
            }

            throttleSettingDisplayLabel.Text = tRex.Throttle.ToString("000");
            lMotSpeedDisplayLabel.Text = tRex.LMotSpeed.ToString("000");
            rMotSpeedDisplayLabel.Text = tRex.RMotSpeed.ToString("000");

            tRexVSupplyDisplayLabel.Text = (tRex.BatV / 100.0).ToString("N2");
            leftIMotorDisplayLabel.Text = tRex.LMotI.ToString("###0");
            rightIMotorDisplayLabel.Text = tRex.RMotI.ToString("###0");
            tRexXAccelDisplayLabel.Text = "X: " + tRex.AccelX.ToString("###0");
            tRexYAccelDisplayLabel.Text = "Y: " + tRex.AccelY.ToString("###0");
            tRexZAccelDisplayLabel.Text = "Z: " + tRex.AccelZ.ToString("###0");
            #endregion Update numerical and text data displays
        }

        #region Display functions
        // Display contents of the serial communiction buffers
        private void DisplayAllCommBuffersToGUI()
        {
            String CommBufStr = "OUT: ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += outBuffer[i].ToString("X2");
                if (i < outBuffer.Length) CommBufStr += " ";
            }
            outBufferDisplayLabel.Text = CommBufStr;
            
            CommBufStr = "IN:  ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += inBuffer[i].ToString("X2");
                if (i < inBuffer.Length) CommBufStr += " ";
            }
            inBufferDisplayLabel.Text = CommBufStr;

            String PacketStr = "PKT: ";
            for (int i = 0; i < PACKET_SIZE; ++i)
            {
                PacketStr += packetBuffer[i].ToString("X2");
                if (i < packetBuffer.Length) PacketStr += " ";
            }
            packetDisplayLabel.Text = PacketStr;
        }

        // Display contents of the serial inBuffer
        private void DisplayInBufferToConsole()
        {
            String CommBufStr = "IN:  ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += inBuffer[i].ToString("X2");
                if (i < inBuffer.Length) CommBufStr += " ";
            }
            //inBufferDisplayLabel.Text = CommBufStr;
            Console.WriteLine(CommBufStr);
        }

        // Display contents of the serial outBuffer
        private void DisplayOutBufferToConsole()
        {
            String CommBufStr = "OUT: ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += outBuffer[i].ToString("X2");
                if (i < outBuffer.Length) CommBufStr += " ";
            }
            //outBufferDisplayLabel.Text = CommBufStr;
            Console.WriteLine(CommBufStr);
        }

        #endregion Display functions

        #region Menu and Toolbar event handlers
        private void serialConnectToolStripButton_Click(object sender, EventArgs e)
        {
            if (serialConnectToolStripButton.Checked)
            {
                try
                {
                    MRSMainControllerSerialPort.Open();
                    displayUpdateTimer.Enabled = true;
                    toggleDisplayUpdateTimerToolStripButton.Checked = true;
                }
                catch (IOException ioe)
                {
                    Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
                    serialConnectToolStripButton.Checked = false;
                }
            }
            else
            {
                if (MRSMainControllerSerialPort.IsOpen)
                {
                    MRSMainControllerSerialPort.Close();
                    displayUpdateTimer.Enabled = false;
                    toggleDisplayUpdateTimerToolStripButton.Checked = false;
                }
            }
        }

        private void toggleSerialCommDataPanelToolStripButton_Click(object sender, EventArgs e)
        {
            serialCommsDataPanel.Visible = toggleSerialCommDataPanelToolStripButton.Checked;
        }

        private void comPortToolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            if (MRSMainControllerSerialPort.IsOpen)
            {
                MRSMainControllerSerialPort.Close();
                serialConnectToolStripButton.Checked = false;
                displayUpdateTimer.Enabled = false;
                toggleDisplayUpdateTimerToolStripButton.Checked = false;
                commErrorDisplayLabel.Text = " Not connected";
            }
            MRSMainControllerSerialPort.PortName = comPortToolStripComboBox.Text;
            mcspPortDisplayLabel.Text = MRSMainControllerSerialPort.PortName;
        }

        private void modeToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton tsb in modeButtons)
            {
                tsb.Checked = tsb == sender;
                if (tsb.Checked)
                {
                    Byte[] mode = new Byte[1];
                    String tagStr = tsb.Tag.ToString();
                    mode[0] = Convert.ToByte(tagStr);
                    BuildAndSendCommandMessage(SetModeMsgType, mode);
                }
            }
        }

        private void toggleDisplayUpdateTimerToolStripButton_Click(object sender, EventArgs e)
        {
            displayUpdateTimer.Enabled = toggleDisplayUpdateTimerToolStripButton.Checked;
        }

        private void showAllBufferUpdatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            showAllCommandBufferUpdates = showAllBufferUpdatesCheckBox.Checked;
            if (showAllCommandBufferUpdates)
            {
                inBufferDisplayLabel.Visible = true;
                outBufferDisplayLabel.Visible = true;
                packetDisplayLabel.Visible = true;
                DisplayAllCommBuffersToGUI();
            }
            else
            {
                inBufferDisplayLabel.Visible = false;
                outBufferDisplayLabel.Visible = false;
                packetDisplayLabel.Visible = false;
            }
        }

        #endregion Menu and Toolbar event handlers

        #region Control yoke event handlers

        private void throttleForwardButton_Click(object sender, EventArgs e)
        {
            if (tRex.Throttle < 255)
            {
                ++tRex.Throttle;
                newTRexMotorControllerCommand = true;
            }
        }

        private void throttleBackButton_Click(object sender, EventArgs e)
        {
            if (tRex.Throttle > -255)
            {
                --tRex.Throttle;
                newTRexMotorControllerCommand = true;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            tRex.Throttle = 0;
            newTRexMotorControllerCommand = true;
        }

        private void turnLeftButton_Click(object sender, EventArgs e)
        {
            if (tRex.Steering > -255)
            {
                --tRex.Steering;
                newTRexMotorControllerCommand = true;
            }
        }

        private void turnRightButton_Click(object sender, EventArgs e)
        {
            if (tRex.Steering < 255)
            {
                ++tRex.Steering;
                newTRexMotorControllerCommand = true;
            }
        }

        private void centerSteeringButton_Click(object sender, EventArgs e)
        {
            tRex.Steering = 0;
            newTRexMotorControllerCommand = true;
        }

        private void speed100Button_Click(object sender, EventArgs e)
        {
            tRex.Throttle = 255;
            newTRexMotorControllerCommand = true;
        }

        private void speed75Button_Click(object sender, EventArgs e)
        {
            tRex.Throttle = 191;
            newTRexMotorControllerCommand = true;
        }

        private void speed50Button_Click(object sender, EventArgs e)
        {
            tRex.Throttle = 127;
            newTRexMotorControllerCommand = true;
        }

        private void speed25Button_Click(object sender, EventArgs e)
        {
            tRex.Throttle = 63;
            newTRexMotorControllerCommand = true;
        }

        #endregion Control yoke event handlers


        

    }
}
