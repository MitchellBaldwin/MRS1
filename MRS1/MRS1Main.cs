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
        // Defines
        public const Byte CommStartByte = 0x0F;
        
        public const Byte TextMsgMsgType = 0x00;
        public const Byte SetModeMsgType = 0x01;

        public const Byte TRexCmdMsgType = 0x10;
        public const Byte TRexStatMsgType = 0x11;
        
        // Buffers for serial communication with MRS Main Controller
        public const Byte COMM_BUFFER_SIZE = 32;
        Byte[] inBuffer = new Byte[COMM_BUFFER_SIZE];
        Byte[] outBuffer = new Byte[COMM_BUFFER_SIZE];
        Byte[] dummy = new Byte[1];

        TRex tRex = new TRex();

        ToolStripButton[] modeButtons = new ToolStripButton[3];

        // Switch for displaying contents of commands sent to the MRS Main Controller
        Boolean showAllMRSMCCommandBufferUpdates = false;
        public Boolean ShowAllMRSMCCommandBufferUpdates
        {
            get { return showAllMRSMCCommandBufferUpdates; }
            set { showAllMRSMCCommandBufferUpdates = value; }
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

        private int displayUpdatePeriod = 10;   // Sets the number of timer intervals between updates to the displays
        private int displayCount = 0;           // Counter to implement the interval between display updates

        // Flag indicating a Motor Controller status message has been sent and we are awaiting the response
        //(used to detect a timeout when awaiting receipt of a status update from the Motor Controller)
        Boolean mcStatusRequestSent = false;
        public Boolean McStatusRequestSent
        {
            get { return mcStatusRequestSent; }
            set { mcStatusRequestSent = value; }
        }

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

        private void mcspConnectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mcspConnectCheckBox.Checked)
            {
                try
                {
                    mcspTimer.Enabled = true;
                    MRSMainControllerSerialPort.Open();
                }
                catch (IOException ioe)
                {
                    Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
                    mcspConnectCheckBox.Checked = false;
                }
            }
            else
            {
                if (MRSMainControllerSerialPort.IsOpen)
                {
                    MRSMainControllerSerialPort.Close();
                    mcspTimer.Enabled = false;
                }
            }
        }

        private void mcspTimer_Tick(object sender, EventArgs e)
        {
            if (ShowAllMRSMCCommandBufferUpdates)
            {
                DisplayCommBuffers();
            }

            // Display communication error status
            commErrorDisplayLabel.ForeColor = Color.Black;
            if (mcspConnectCheckBox.Checked)
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
            // Handle any new message from the MRS Master Controller
            if (mrsmcMessageReceived)
            {
                Byte mrsmcMessageType = inBuffer[0x01];
                switch (mrsmcMessageType)
                {
                    case TextMsgMsgType:
                        String message = "";
                        for (int i = 2; i < COMM_BUFFER_SIZE - 1; ++i)
                        {
                            if (inBuffer[i] != 0x00)
                            {
                                message += (char)inBuffer[i];
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
                        for (int i=0; i<TRex.TREX_STATUS_BUFFER_SIZE; ++i)
                        {
                            tRex.StatusBuffer[i] = inBuffer[i + 2];
                        }
                        if (ShowInBufferUpdates)
                        {
                            DisplayInBuffer();
                        }
                        mcStatusRequestSent = false;
                        // Displays will be updated below in this timer event handler
                        break;

                    default:

                        break;
                }

                mrsmcMessageReceived = false;
            }         // Serial Communication with Master Controller

            // If a new motor controller command is not pending then request a motor controller status update
            if (!newTRexMotorControllerCommand)
            {
                ++displayCount;

                if (displayCount >= 10)
                {
                    if (mcStatusRequestSent)
                    {
                        commErrorDisplayLabel.ForeColor = Color.Orange;
                        commErrorDisplayLabel.Text = "MC status update timeout";
                        Console.WriteLine("MC status update timeout");
                        mcStatusRequestSent = false;
                    }
                    else
                    {
                        BuildCommMessage(TRexStatMsgType, dummy);
                        try
                        {
                            MRSMainControllerSerialPort.Write(outBuffer, 0, COMM_BUFFER_SIZE);
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
                        }
                        mcStatusRequestSent = true;
                    }
                    displayCount = 0;
                }
            }

            // If any part of the command set for the motor controller has been updated then build a new message and send it
            if (newTRexMotorControllerCommand)
            {
                BuildCommMessage(TRexCmdMsgType, tRex.CommandBuffer);
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
                    DisplayOutBuffer();
                }
                newTRexMotorControllerCommand = false;
                displayCount = 0;
            }
            
            // Update motor control graphic display
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

            // Update motor controller data displays
            throttleSettingDisplayLabel.Text = tRex.Throttle.ToString("000");
            lMotSpeedDisplayLabel.Text = tRex.LMotSpeed.ToString("000");
            rMotSpeedDisplayLabel.Text = tRex.RMotSpeed.ToString("000");

            tRexVSupplyDisplayLabel.Text = (tRex.BatV / 100.0).ToString("N2");
            leftIMotorDisplayLabel.Text = tRex.LMotI.ToString("###0");
            rightIMotorDisplayLabel.Text = tRex.RMotI.ToString("###0");
            tRexXAccelDisplayLabel.Text = "X: " + tRex.AccelX.ToString("###0");
            tRexYAccelDisplayLabel.Text = "Y: " + tRex.AccelY.ToString("###0");
            tRexZAccelDisplayLabel.Text = "Z: " + tRex.AccelZ.ToString("###0");

        }

        // Helper function to format the outBuffer with a Motor Controller message / command
        private void BuildCommMessage(Byte msgType, Byte[] buffer)
        {
            Byte checkSum = 0;

            for (int i = 0; i<COMM_BUFFER_SIZE; ++i)
            {
                outBuffer[i] = 0;
            }

            outBuffer[0] = CommStartByte;
            outBuffer[1] = msgType;
            checkSum = CommStartByte;
            checkSum += msgType;
            for (int i=0; i<buffer.Length; ++i)
            {
                outBuffer[2 + i] = buffer[i];
                checkSum += buffer[i];
            }
            outBuffer[COMM_BUFFER_SIZE - 1] = checkSum;
        }
        
        // Serial port callback function to handle the receipt of messages from the Motor Controller
        private void MRSMainControllerSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                MRSMainControllerSerialPort.Read(inBuffer, 0, COMM_BUFFER_SIZE);
                commTimeoutErrorFlag = false;      // If no exception was thrown then we should have receiced a complete buffer (COMM_BUFFER_SIZE bits)

                // Check that the first byte contains the CommStartByte
                if (inBuffer[0x00] != CommStartByte)
                {
                    commFramingErrorFlag = true;
                    Console.WriteLine("Serial port framing error");
                    return;
                }
                else
                {
                    commFramingErrorFlag = false;
                }

                // Check that the checksums match
                Byte checkSum = 0;
                for (int i=0; i<COMM_BUFFER_SIZE-1; ++i)
                {
                    checkSum += inBuffer[i];
                }
                if (checkSum == inBuffer[COMM_BUFFER_SIZE-1])
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
            }
            catch (System.TimeoutException)
            {
                commTimeoutErrorFlag = true;
                Console.WriteLine("Serial port timeout");
                mrsmcMessageReceived = false;
            }

        }

        // Display contents of both serial communiction buffers
        private void DisplayCommBuffers()
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
        }

        // Display contents of the serial inBuffer
        private void DisplayInBuffer()
        {
            String CommBufStr = "IN:  ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += inBuffer[i].ToString("X2");
                if (i < inBuffer.Length) CommBufStr += " ";
            }
            inBufferDisplayLabel.Text = CommBufStr;
        }

        // Display contents of the serial outBuffer
        private void DisplayOutBuffer()
        {
            String CommBufStr = "OUT: ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += outBuffer[i].ToString("X2");
                if (i < outBuffer.Length) CommBufStr += " ";
            }
            outBufferDisplayLabel.Text = CommBufStr;
        }

        private void showAllBufferUpdatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            showAllMRSMCCommandBufferUpdates = showAllBufferUpdatesCheckBox.Checked;
        }

        private void printCommBufToolStripButton_Click(object sender, EventArgs e)
        {
            if (printCommBufToolStripButton.Checked)
            {
                inBufferDisplayLabel.Visible = true;
                outBufferDisplayLabel.Visible = true;
                DisplayCommBuffers();
            }
            else
            {
                inBufferDisplayLabel.Visible = false;
                outBufferDisplayLabel.Visible = false;
            }
            
        }

        private void testCommsToolStripButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(TRexStatMsgType, dummy);
            
            if (!mcspConnectCheckBox.Checked)
            {
                mcspConnectCheckBox.Checked = true;
            }

            try
            {
                MRSMainControllerSerialPort.Write(outBuffer, 0, COMM_BUFFER_SIZE);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
            }

        }

        private void comPortToolStripComboBox_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comPortToolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            Boolean wasOpen = false;

            if (mcspConnectCheckBox.Checked)
            {
                wasOpen = true;
                mcspConnectCheckBox.Checked = false;
            }
            MRSMainControllerSerialPort.PortName = comPortToolStripComboBox.Text;
            if (wasOpen)
            {
                mcspConnectCheckBox.Checked = true;
            }
        }

        private void modeToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton tsb in modeButtons)
            {
                tsb.Checked = tsb == sender;
                if (tsb.Checked)
                {
                    Byte[] mode = new Byte[1];
                    mode[0] = Convert.ToByte(tsb.Tag.ToString());
                    BuildCommMessage(SetModeMsgType, mode);
                    try
                    {
                        MRSMainControllerSerialPort.Write(outBuffer, 0, COMM_BUFFER_SIZE);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
                    }
                }
            }
        }

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
