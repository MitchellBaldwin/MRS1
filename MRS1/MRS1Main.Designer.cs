﻿namespace MRS1
{
    partial class MRS1
    {

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRS1));
            this.MRSMainControllerSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.MRS1MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MRS1MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.serialConnectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toggleSerialCommDataPanelToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.comPortToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.testToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.i2cToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rcToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleDisplayUpdateTimerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.displayUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.throttleSettingDisplayLabel = new System.Windows.Forms.Label();
            this.lMotSpeedDisplayLabel = new System.Windows.Forms.Label();
            this.rMotSpeedDisplayLabel = new System.Windows.Forms.Label();
            this.textMessageTextBox = new System.Windows.Forms.TextBox();
            this.tRexStatusPanel = new System.Windows.Forms.Panel();
            this.vdcLabel = new System.Windows.Forms.Label();
            this.tRexVSupplyDisplayLabel = new System.Windows.Forms.Label();
            this.motorBatteryPictureBox = new System.Windows.Forms.PictureBox();
            this.rightIMotorDisplayLabel = new System.Windows.Forms.Label();
            this.mALAbel = new System.Windows.Forms.Label();
            this.leftIMotorDisplayLabel = new System.Windows.Forms.Label();
            this.iMotorLabel = new System.Windows.Forms.Label();
            this.tRexAccelerometerPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trexAccelerometerPanelLabel = new System.Windows.Forms.Label();
            this.tRexXAccelDisplayLabel = new System.Windows.Forms.Label();
            this.tRexZAccelDisplayLabel = new System.Windows.Forms.Label();
            this.tRexYAccelDisplayLabel = new System.Windows.Forms.Label();
            this.speed100Button = new System.Windows.Forms.Button();
            this.speed75Button = new System.Windows.Forms.Button();
            this.speed50Button = new System.Windows.Forms.Button();
            this.speed25Button = new System.Windows.Forms.Button();
            this.serialCommsDataPanel = new System.Windows.Forms.Panel();
            this.packetDisplayLabel = new System.Windows.Forms.Label();
            this.commErrorDisplayLabel = new System.Windows.Forms.Label();
            this.showAllBufferUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.bytePositionLabel = new System.Windows.Forms.Label();
            this.inBufferDisplayLabel = new System.Windows.Forms.Label();
            this.outBufferDisplayLabel = new System.Windows.Forms.Label();
            this.mcspStopBitsDisplayLabel = new System.Windows.Forms.Label();
            this.mcspDataBitsDisplayLabel = new System.Windows.Forms.Label();
            this.mcspParityDisplayLabel = new System.Windows.Forms.Label();
            this.mcspBaudRateDisplayLabel = new System.Windows.Forms.Label();
            this.mcspPortDisplayLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OSB1 = new System.Windows.Forms.Button();
            this.HDGDisplayLabel = new System.Windows.Forms.Label();
            this.MFCD1PictureBox = new System.Windows.Forms.PictureBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.throttleBackButton = new System.Windows.Forms.Button();
            this.throttleForwardButton = new System.Windows.Forms.Button();
            this.steeringPictureBox = new System.Windows.Forms.PictureBox();
            this.centerSteeringButton = new System.Windows.Forms.Button();
            this.turnRightButton = new System.Windows.Forms.Button();
            this.turnLeftButton = new System.Windows.Forms.Button();
            this.MFCD2Panel = new System.Windows.Forms.Panel();
            this.MFCD2HDGDisplayLabel = new System.Windows.Forms.Label();
            this.MFCD2PictureBox = new System.Windows.Forms.PictureBox();
            this.MRS1MainToolStrip.SuspendLayout();
            this.tRexStatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.motorBatteryPictureBox)).BeginInit();
            this.tRexAccelerometerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.serialCommsDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MFCD1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.steeringPictureBox)).BeginInit();
            this.MFCD2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MFCD2PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MRSMainControllerSerialPort
            // 
            this.MRSMainControllerSerialPort.BaudRate = 115200;
            this.MRSMainControllerSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MRSMainControllerSerialPort_DataReceived);
            // 
            // MRS1MainStatusStrip
            // 
            this.MRS1MainStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MRS1MainStatusStrip.Location = new System.Drawing.Point(0, 1100);
            this.MRS1MainStatusStrip.Name = "MRS1MainStatusStrip";
            this.MRS1MainStatusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.MRS1MainStatusStrip.Size = new System.Drawing.Size(1512, 22);
            this.MRS1MainStatusStrip.TabIndex = 0;
            this.MRS1MainStatusStrip.Text = "statusStrip1";
            // 
            // MRS1MainToolStrip
            // 
            this.MRS1MainToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MRS1MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialConnectToolStripButton,
            this.toggleSerialCommDataPanelToolStripButton,
            this.comPortToolStripComboBox,
            this.toolStripSeparator1,
            this.testToolStripButton,
            this.i2cToolStripButton,
            this.rcToolStripButton,
            this.toolStripSeparator2,
            this.toggleDisplayUpdateTimerToolStripButton,
            this.toolStripButton1});
            this.MRS1MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MRS1MainToolStrip.Name = "MRS1MainToolStrip";
            this.MRS1MainToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.MRS1MainToolStrip.Size = new System.Drawing.Size(1512, 33);
            this.MRS1MainToolStrip.TabIndex = 1;
            this.MRS1MainToolStrip.Text = "toolStrip1";
            // 
            // serialConnectToolStripButton
            // 
            this.serialConnectToolStripButton.CheckOnClick = true;
            this.serialConnectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.serialConnectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("serialConnectToolStripButton.Image")));
            this.serialConnectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.serialConnectToolStripButton.Name = "serialConnectToolStripButton";
            this.serialConnectToolStripButton.Size = new System.Drawing.Size(28, 30);
            this.serialConnectToolStripButton.Text = "serialConnectToolStripButton";
            this.serialConnectToolStripButton.ToolTipText = "Display Comm Buffer contents";
            this.serialConnectToolStripButton.Click += new System.EventHandler(this.serialConnectToolStripButton_Click);
            // 
            // toggleSerialCommDataPanelToolStripButton
            // 
            this.toggleSerialCommDataPanelToolStripButton.Checked = true;
            this.toggleSerialCommDataPanelToolStripButton.CheckOnClick = true;
            this.toggleSerialCommDataPanelToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleSerialCommDataPanelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toggleSerialCommDataPanelToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("toggleSerialCommDataPanelToolStripButton.Image")));
            this.toggleSerialCommDataPanelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleSerialCommDataPanelToolStripButton.Name = "toggleSerialCommDataPanelToolStripButton";
            this.toggleSerialCommDataPanelToolStripButton.Size = new System.Drawing.Size(28, 30);
            this.toggleSerialCommDataPanelToolStripButton.ToolTipText = "Toggle serial communications data panel";
            this.toggleSerialCommDataPanelToolStripButton.Click += new System.EventHandler(this.toggleSerialCommDataPanelToolStripButton_Click);
            // 
            // comPortToolStripComboBox
            // 
            this.comPortToolStripComboBox.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.comPortToolStripComboBox.Name = "comPortToolStripComboBox";
            this.comPortToolStripComboBox.Size = new System.Drawing.Size(110, 33);
            this.comPortToolStripComboBox.Text = global::MRS1.Properties.Settings.Default.comPortTexrApplicationSetting;
            this.comPortToolStripComboBox.TextChanged += new System.EventHandler(this.comPortToolStripComboBox_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // testToolStripButton
            // 
            this.testToolStripButton.AutoSize = false;
            this.testToolStripButton.Checked = true;
            this.testToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.testToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.testToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.testToolStripButton.Name = "testToolStripButton";
            this.testToolStripButton.Size = new System.Drawing.Size(32, 22);
            this.testToolStripButton.Tag = "0";
            this.testToolStripButton.Text = "Test";
            this.testToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.testToolStripButton.ToolTipText = "Test";
            this.testToolStripButton.Click += new System.EventHandler(this.modeToolStripButton_Click);
            // 
            // i2cToolStripButton
            // 
            this.i2cToolStripButton.AutoSize = false;
            this.i2cToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.i2cToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.i2cToolStripButton.Name = "i2cToolStripButton";
            this.i2cToolStripButton.Size = new System.Drawing.Size(32, 22);
            this.i2cToolStripButton.Tag = "1";
            this.i2cToolStripButton.Text = "i2c";
            this.i2cToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.i2cToolStripButton.ToolTipText = "Test";
            this.i2cToolStripButton.Click += new System.EventHandler(this.modeToolStripButton_Click);
            // 
            // rcToolStripButton
            // 
            this.rcToolStripButton.AutoSize = false;
            this.rcToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.rcToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rcToolStripButton.Name = "rcToolStripButton";
            this.rcToolStripButton.Size = new System.Drawing.Size(32, 22);
            this.rcToolStripButton.Tag = "2";
            this.rcToolStripButton.Text = "RC";
            this.rcToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.rcToolStripButton.ToolTipText = "Test";
            this.rcToolStripButton.Click += new System.EventHandler(this.modeToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // toggleDisplayUpdateTimerToolStripButton
            // 
            this.toggleDisplayUpdateTimerToolStripButton.CheckOnClick = true;
            this.toggleDisplayUpdateTimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toggleDisplayUpdateTimerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("toggleDisplayUpdateTimerToolStripButton.Image")));
            this.toggleDisplayUpdateTimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleDisplayUpdateTimerToolStripButton.Name = "toggleDisplayUpdateTimerToolStripButton";
            this.toggleDisplayUpdateTimerToolStripButton.Size = new System.Drawing.Size(28, 30);
            this.toggleDisplayUpdateTimerToolStripButton.Text = "toggleDisplayUpdateTimerToolStripButton";
            this.toggleDisplayUpdateTimerToolStripButton.ToolTipText = "Start/Stop display updates";
            this.toggleDisplayUpdateTimerToolStripButton.Click += new System.EventHandler(this.toggleDisplayUpdateTimerToolStripButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 30);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // displayUpdateTimer
            // 
            this.displayUpdateTimer.Tick += new System.EventHandler(this.mcspTimer_Tick);
            // 
            // throttleSettingDisplayLabel
            // 
            this.throttleSettingDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.throttleSettingDisplayLabel.Location = new System.Drawing.Point(1179, 825);
            this.throttleSettingDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.throttleSettingDisplayLabel.Name = "throttleSettingDisplayLabel";
            this.throttleSettingDisplayLabel.Size = new System.Drawing.Size(48, 25);
            this.throttleSettingDisplayLabel.TabIndex = 19;
            this.throttleSettingDisplayLabel.Text = "000";
            this.throttleSettingDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lMotSpeedDisplayLabel
            // 
            this.lMotSpeedDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMotSpeedDisplayLabel.Location = new System.Drawing.Point(1150, 708);
            this.lMotSpeedDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMotSpeedDisplayLabel.Name = "lMotSpeedDisplayLabel";
            this.lMotSpeedDisplayLabel.Size = new System.Drawing.Size(48, 25);
            this.lMotSpeedDisplayLabel.TabIndex = 21;
            this.lMotSpeedDisplayLabel.Text = "000";
            this.lMotSpeedDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rMotSpeedDisplayLabel
            // 
            this.rMotSpeedDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rMotSpeedDisplayLabel.Location = new System.Drawing.Point(1208, 708);
            this.rMotSpeedDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rMotSpeedDisplayLabel.Name = "rMotSpeedDisplayLabel";
            this.rMotSpeedDisplayLabel.Size = new System.Drawing.Size(48, 25);
            this.rMotSpeedDisplayLabel.TabIndex = 22;
            this.rMotSpeedDisplayLabel.Text = "000";
            this.rMotSpeedDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textMessageTextBox
            // 
            this.textMessageTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMessageTextBox.Location = new System.Drawing.Point(13, 751);
            this.textMessageTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textMessageTextBox.Multiline = true;
            this.textMessageTextBox.Name = "textMessageTextBox";
            this.textMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textMessageTextBox.Size = new System.Drawing.Size(649, 138);
            this.textMessageTextBox.TabIndex = 23;
            // 
            // tRexStatusPanel
            // 
            this.tRexStatusPanel.Controls.Add(this.vdcLabel);
            this.tRexStatusPanel.Controls.Add(this.tRexVSupplyDisplayLabel);
            this.tRexStatusPanel.Controls.Add(this.motorBatteryPictureBox);
            this.tRexStatusPanel.Controls.Add(this.rightIMotorDisplayLabel);
            this.tRexStatusPanel.Controls.Add(this.mALAbel);
            this.tRexStatusPanel.Controls.Add(this.leftIMotorDisplayLabel);
            this.tRexStatusPanel.Controls.Add(this.iMotorLabel);
            this.tRexStatusPanel.Location = new System.Drawing.Point(1286, 655);
            this.tRexStatusPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tRexStatusPanel.Name = "tRexStatusPanel";
            this.tRexStatusPanel.Size = new System.Drawing.Size(208, 234);
            this.tRexStatusPanel.TabIndex = 24;
            // 
            // vdcLabel
            // 
            this.vdcLabel.AutoSize = true;
            this.vdcLabel.Location = new System.Drawing.Point(112, 20);
            this.vdcLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vdcLabel.Name = "vdcLabel";
            this.vdcLabel.Size = new System.Drawing.Size(43, 20);
            this.vdcLabel.TabIndex = 23;
            this.vdcLabel.Text = "VDC";
            // 
            // tRexVSupplyDisplayLabel
            // 
            this.tRexVSupplyDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRexVSupplyDisplayLabel.Location = new System.Drawing.Point(45, 15);
            this.tRexVSupplyDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tRexVSupplyDisplayLabel.Name = "tRexVSupplyDisplayLabel";
            this.tRexVSupplyDisplayLabel.Size = new System.Drawing.Size(72, 28);
            this.tRexVSupplyDisplayLabel.TabIndex = 0;
            this.tRexVSupplyDisplayLabel.Text = "0.000";
            this.tRexVSupplyDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // motorBatteryPictureBox
            // 
            this.motorBatteryPictureBox.Image = global::MRS1.Properties.Resources.BatteryH2;
            this.motorBatteryPictureBox.Location = new System.Drawing.Point(40, 8);
            this.motorBatteryPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.motorBatteryPictureBox.Name = "motorBatteryPictureBox";
            this.motorBatteryPictureBox.Size = new System.Drawing.Size(132, 43);
            this.motorBatteryPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.motorBatteryPictureBox.TabIndex = 26;
            this.motorBatteryPictureBox.TabStop = false;
            // 
            // rightIMotorDisplayLabel
            // 
            this.rightIMotorDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightIMotorDisplayLabel.Location = new System.Drawing.Point(144, 75);
            this.rightIMotorDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rightIMotorDisplayLabel.Name = "rightIMotorDisplayLabel";
            this.rightIMotorDisplayLabel.Size = new System.Drawing.Size(60, 25);
            this.rightIMotorDisplayLabel.TabIndex = 25;
            this.rightIMotorDisplayLabel.Text = "0000";
            this.rightIMotorDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mALAbel
            // 
            this.mALAbel.AutoSize = true;
            this.mALAbel.Location = new System.Drawing.Point(87, 80);
            this.mALAbel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mALAbel.Name = "mALAbel";
            this.mALAbel.Size = new System.Drawing.Size(33, 20);
            this.mALAbel.TabIndex = 24;
            this.mALAbel.Text = "mA";
            // 
            // leftIMotorDisplayLabel
            // 
            this.leftIMotorDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftIMotorDisplayLabel.Location = new System.Drawing.Point(4, 75);
            this.leftIMotorDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.leftIMotorDisplayLabel.Name = "leftIMotorDisplayLabel";
            this.leftIMotorDisplayLabel.Size = new System.Drawing.Size(60, 25);
            this.leftIMotorDisplayLabel.TabIndex = 22;
            this.leftIMotorDisplayLabel.Text = "0000";
            this.leftIMotorDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iMotorLabel
            // 
            this.iMotorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.iMotorLabel.AutoSize = true;
            this.iMotorLabel.Location = new System.Drawing.Point(51, 55);
            this.iMotorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iMotorLabel.Name = "iMotorLabel";
            this.iMotorLabel.Size = new System.Drawing.Size(104, 20);
            this.iMotorLabel.TabIndex = 2;
            this.iMotorLabel.Text = "Motor current";
            this.iMotorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tRexAccelerometerPanel
            // 
            this.tRexAccelerometerPanel.Controls.Add(this.pictureBox1);
            this.tRexAccelerometerPanel.Controls.Add(this.trexAccelerometerPanelLabel);
            this.tRexAccelerometerPanel.Controls.Add(this.tRexXAccelDisplayLabel);
            this.tRexAccelerometerPanel.Controls.Add(this.tRexZAccelDisplayLabel);
            this.tRexAccelerometerPanel.Controls.Add(this.tRexYAccelDisplayLabel);
            this.tRexAccelerometerPanel.Location = new System.Drawing.Point(914, 655);
            this.tRexAccelerometerPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tRexAccelerometerPanel.Name = "tRexAccelerometerPanel";
            this.tRexAccelerometerPanel.Size = new System.Drawing.Size(208, 234);
            this.tRexAccelerometerPanel.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(76, 29);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // trexAccelerometerPanelLabel
            // 
            this.trexAccelerometerPanelLabel.AutoSize = true;
            this.trexAccelerometerPanelLabel.Location = new System.Drawing.Point(3, 5);
            this.trexAccelerometerPanelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.trexAccelerometerPanelLabel.Name = "trexAccelerometerPanelLabel";
            this.trexAccelerometerPanelLabel.Size = new System.Drawing.Size(89, 20);
            this.trexAccelerometerPanelLabel.TabIndex = 26;
            this.trexAccelerometerPanelLabel.Text = "TRex Accel";
            // 
            // tRexXAccelDisplayLabel
            // 
            this.tRexXAccelDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRexXAccelDisplayLabel.Location = new System.Drawing.Point(4, 74);
            this.tRexXAccelDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tRexXAccelDisplayLabel.Name = "tRexXAccelDisplayLabel";
            this.tRexXAccelDisplayLabel.Size = new System.Drawing.Size(74, 25);
            this.tRexXAccelDisplayLabel.TabIndex = 25;
            this.tRexXAccelDisplayLabel.Text = "X:0000";
            this.tRexXAccelDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tRexZAccelDisplayLabel
            // 
            this.tRexZAccelDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRexZAccelDisplayLabel.Location = new System.Drawing.Point(135, 74);
            this.tRexZAccelDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tRexZAccelDisplayLabel.Name = "tRexZAccelDisplayLabel";
            this.tRexZAccelDisplayLabel.Size = new System.Drawing.Size(74, 25);
            this.tRexZAccelDisplayLabel.TabIndex = 24;
            this.tRexZAccelDisplayLabel.Text = "Z:0000";
            this.tRexZAccelDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tRexYAccelDisplayLabel
            // 
            this.tRexYAccelDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRexYAccelDisplayLabel.Location = new System.Drawing.Point(135, 26);
            this.tRexYAccelDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tRexYAccelDisplayLabel.Name = "tRexYAccelDisplayLabel";
            this.tRexYAccelDisplayLabel.Size = new System.Drawing.Size(74, 25);
            this.tRexYAccelDisplayLabel.TabIndex = 23;
            this.tRexYAccelDisplayLabel.Text = "Y:0000";
            this.tRexYAccelDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // speed100Button
            // 
            this.speed100Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speed100Button.Location = new System.Drawing.Point(1234, 788);
            this.speed100Button.Margin = new System.Windows.Forms.Padding(0);
            this.speed100Button.Name = "speed100Button";
            this.speed100Button.Size = new System.Drawing.Size(42, 25);
            this.speed100Button.TabIndex = 28;
            this.speed100Button.Text = "100";
            this.speed100Button.UseVisualStyleBackColor = true;
            this.speed100Button.Click += new System.EventHandler(this.speed100Button_Click);
            // 
            // speed75Button
            // 
            this.speed75Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speed75Button.Location = new System.Drawing.Point(1234, 812);
            this.speed75Button.Margin = new System.Windows.Forms.Padding(0);
            this.speed75Button.Name = "speed75Button";
            this.speed75Button.Size = new System.Drawing.Size(42, 25);
            this.speed75Button.TabIndex = 29;
            this.speed75Button.Text = "75";
            this.speed75Button.UseVisualStyleBackColor = true;
            this.speed75Button.Click += new System.EventHandler(this.speed75Button_Click);
            // 
            // speed50Button
            // 
            this.speed50Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speed50Button.Location = new System.Drawing.Point(1234, 837);
            this.speed50Button.Margin = new System.Windows.Forms.Padding(0);
            this.speed50Button.Name = "speed50Button";
            this.speed50Button.Size = new System.Drawing.Size(42, 25);
            this.speed50Button.TabIndex = 30;
            this.speed50Button.Text = "50";
            this.speed50Button.UseVisualStyleBackColor = true;
            this.speed50Button.Click += new System.EventHandler(this.speed50Button_Click);
            // 
            // speed25Button
            // 
            this.speed25Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speed25Button.Location = new System.Drawing.Point(1234, 862);
            this.speed25Button.Margin = new System.Windows.Forms.Padding(0);
            this.speed25Button.Name = "speed25Button";
            this.speed25Button.Size = new System.Drawing.Size(42, 25);
            this.speed25Button.TabIndex = 31;
            this.speed25Button.Text = "25";
            this.speed25Button.UseVisualStyleBackColor = true;
            this.speed25Button.Click += new System.EventHandler(this.speed25Button_Click);
            // 
            // serialCommsDataPanel
            // 
            this.serialCommsDataPanel.Controls.Add(this.packetDisplayLabel);
            this.serialCommsDataPanel.Controls.Add(this.commErrorDisplayLabel);
            this.serialCommsDataPanel.Controls.Add(this.showAllBufferUpdatesCheckBox);
            this.serialCommsDataPanel.Controls.Add(this.bytePositionLabel);
            this.serialCommsDataPanel.Controls.Add(this.inBufferDisplayLabel);
            this.serialCommsDataPanel.Controls.Add(this.outBufferDisplayLabel);
            this.serialCommsDataPanel.Controls.Add(this.mcspStopBitsDisplayLabel);
            this.serialCommsDataPanel.Controls.Add(this.mcspDataBitsDisplayLabel);
            this.serialCommsDataPanel.Controls.Add(this.mcspParityDisplayLabel);
            this.serialCommsDataPanel.Controls.Add(this.mcspBaudRateDisplayLabel);
            this.serialCommsDataPanel.Controls.Add(this.mcspPortDisplayLabel);
            this.serialCommsDataPanel.Controls.Add(this.label1);
            this.serialCommsDataPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.serialCommsDataPanel.Location = new System.Drawing.Point(0, 946);
            this.serialCommsDataPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serialCommsDataPanel.Name = "serialCommsDataPanel";
            this.serialCommsDataPanel.Size = new System.Drawing.Size(1512, 154);
            this.serialCommsDataPanel.TabIndex = 49;
            // 
            // packetDisplayLabel
            // 
            this.packetDisplayLabel.AutoSize = true;
            this.packetDisplayLabel.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packetDisplayLabel.Location = new System.Drawing.Point(18, 109);
            this.packetDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.packetDisplayLabel.Name = "packetDisplayLabel";
            this.packetDisplayLabel.Size = new System.Drawing.Size(58, 22);
            this.packetDisplayLabel.TabIndex = 61;
            this.packetDisplayLabel.Text = "PKT:";
            // 
            // commErrorDisplayLabel
            // 
            this.commErrorDisplayLabel.Location = new System.Drawing.Point(573, 14);
            this.commErrorDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commErrorDisplayLabel.Name = "commErrorDisplayLabel";
            this.commErrorDisplayLabel.Size = new System.Drawing.Size(231, 20);
            this.commErrorDisplayLabel.TabIndex = 60;
            this.commErrorDisplayLabel.Text = "Not connected";
            // 
            // showAllBufferUpdatesCheckBox
            // 
            this.showAllBufferUpdatesCheckBox.AutoSize = true;
            this.showAllBufferUpdatesCheckBox.Checked = true;
            this.showAllBufferUpdatesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAllBufferUpdatesCheckBox.Location = new System.Drawing.Point(921, 12);
            this.showAllBufferUpdatesCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showAllBufferUpdatesCheckBox.Name = "showAllBufferUpdatesCheckBox";
            this.showAllBufferUpdatesCheckBox.Size = new System.Drawing.Size(202, 24);
            this.showAllBufferUpdatesCheckBox.TabIndex = 59;
            this.showAllBufferUpdatesCheckBox.Text = "Show all buffer updates";
            this.showAllBufferUpdatesCheckBox.UseVisualStyleBackColor = true;
            this.showAllBufferUpdatesCheckBox.CheckedChanged += new System.EventHandler(this.showAllBufferUpdatesCheckBox_CheckedChanged);
            // 
            // bytePositionLabel
            // 
            this.bytePositionLabel.AutoSize = true;
            this.bytePositionLabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bytePositionLabel.Location = new System.Drawing.Point(18, 38);
            this.bytePositionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bytePositionLabel.Name = "bytePositionLabel";
            this.bytePositionLabel.Size = new System.Drawing.Size(1210, 22);
            this.bytePositionLabel.TabIndex = 58;
            this.bytePositionLabel.Text = "POS: 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 1" +
    "9 1A 1B 1C 1D 1E 1F";
            // 
            // inBufferDisplayLabel
            // 
            this.inBufferDisplayLabel.AutoSize = true;
            this.inBufferDisplayLabel.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inBufferDisplayLabel.Location = new System.Drawing.Point(18, 83);
            this.inBufferDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inBufferDisplayLabel.Name = "inBufferDisplayLabel";
            this.inBufferDisplayLabel.Size = new System.Drawing.Size(58, 22);
            this.inBufferDisplayLabel.TabIndex = 57;
            this.inBufferDisplayLabel.Text = "IN: ";
            // 
            // outBufferDisplayLabel
            // 
            this.outBufferDisplayLabel.AutoSize = true;
            this.outBufferDisplayLabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outBufferDisplayLabel.Location = new System.Drawing.Point(18, 63);
            this.outBufferDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outBufferDisplayLabel.Name = "outBufferDisplayLabel";
            this.outBufferDisplayLabel.Size = new System.Drawing.Size(70, 22);
            this.outBufferDisplayLabel.TabIndex = 56;
            this.outBufferDisplayLabel.Text = "OUT: ";
            // 
            // mcspStopBitsDisplayLabel
            // 
            this.mcspStopBitsDisplayLabel.Location = new System.Drawing.Point(508, 14);
            this.mcspStopBitsDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mcspStopBitsDisplayLabel.Name = "mcspStopBitsDisplayLabel";
            this.mcspStopBitsDisplayLabel.Size = new System.Drawing.Size(56, 20);
            this.mcspStopBitsDisplayLabel.TabIndex = 54;
            this.mcspStopBitsDisplayLabel.Text = "One";
            this.mcspStopBitsDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mcspDataBitsDisplayLabel
            // 
            this.mcspDataBitsDisplayLabel.Location = new System.Drawing.Point(393, 14);
            this.mcspDataBitsDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mcspDataBitsDisplayLabel.Name = "mcspDataBitsDisplayLabel";
            this.mcspDataBitsDisplayLabel.Size = new System.Drawing.Size(39, 20);
            this.mcspDataBitsDisplayLabel.TabIndex = 53;
            this.mcspDataBitsDisplayLabel.Text = "8";
            this.mcspDataBitsDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mcspParityDisplayLabel
            // 
            this.mcspParityDisplayLabel.Location = new System.Drawing.Point(441, 14);
            this.mcspParityDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mcspParityDisplayLabel.Name = "mcspParityDisplayLabel";
            this.mcspParityDisplayLabel.Size = new System.Drawing.Size(58, 20);
            this.mcspParityDisplayLabel.TabIndex = 52;
            this.mcspParityDisplayLabel.Text = "None";
            this.mcspParityDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mcspBaudRateDisplayLabel
            // 
            this.mcspBaudRateDisplayLabel.Location = new System.Drawing.Point(312, 14);
            this.mcspBaudRateDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mcspBaudRateDisplayLabel.Name = "mcspBaudRateDisplayLabel";
            this.mcspBaudRateDisplayLabel.Size = new System.Drawing.Size(72, 20);
            this.mcspBaudRateDisplayLabel.TabIndex = 51;
            this.mcspBaudRateDisplayLabel.Text = "9600";
            this.mcspBaudRateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mcspPortDisplayLabel
            // 
            this.mcspPortDisplayLabel.Location = new System.Drawing.Point(231, 14);
            this.mcspPortDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mcspPortDisplayLabel.Name = "mcspPortDisplayLabel";
            this.mcspPortDisplayLabel.Size = new System.Drawing.Size(72, 20);
            this.mcspPortDisplayLabel.TabIndex = 50;
            this.mcspPortDisplayLabel.Text = "COM1";
            this.mcspPortDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "MRS Main Controller Serial:";
            // 
            // OSB1
            // 
            this.OSB1.Location = new System.Drawing.Point(782, 49);
            this.OSB1.Name = "OSB1";
            this.OSB1.Size = new System.Drawing.Size(60, 55);
            this.OSB1.TabIndex = 53;
            this.OSB1.UseVisualStyleBackColor = true;
            this.OSB1.Click += new System.EventHandler(this.OSB1_Click);
            // 
            // HDGDisplayLabel
            // 
            this.HDGDisplayLabel.AutoSize = true;
            this.HDGDisplayLabel.BackColor = System.Drawing.Color.Magenta;
            this.HDGDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HDGDisplayLabel.ForeColor = System.Drawing.Color.Black;
            this.HDGDisplayLabel.Location = new System.Drawing.Point(242, 110);
            this.HDGDisplayLabel.Name = "HDGDisplayLabel";
            this.HDGDisplayLabel.Size = new System.Drawing.Size(49, 20);
            this.HDGDisplayLabel.TabIndex = 56;
            this.HDGDisplayLabel.Text = "HDG";
            // 
            // MFCD1PictureBox
            // 
            this.MFCD1PictureBox.Image = global::MRS1.Properties.Resources.MRC_42085H_UTM_16N_N_4756980_E_609580_NAD83_4m;
            this.MFCD1PictureBox.Location = new System.Drawing.Point(13, 110);
            this.MFCD1PictureBox.Name = "MFCD1PictureBox";
            this.MFCD1PictureBox.Size = new System.Drawing.Size(520, 437);
            this.MFCD1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MFCD1PictureBox.TabIndex = 55;
            this.MFCD1PictureBox.TabStop = false;
            // 
            // stopButton
            // 
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.Location = new System.Drawing.Point(1131, 820);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(42, 35);
            this.stopButton.TabIndex = 20;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // throttleBackButton
            // 
            this.throttleBackButton.Image = ((System.Drawing.Image)(resources.GetObject("throttleBackButton.Image")));
            this.throttleBackButton.Location = new System.Drawing.Point(1182, 854);
            this.throttleBackButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.throttleBackButton.Name = "throttleBackButton";
            this.throttleBackButton.Size = new System.Drawing.Size(42, 35);
            this.throttleBackButton.TabIndex = 18;
            this.throttleBackButton.UseVisualStyleBackColor = true;
            this.throttleBackButton.Click += new System.EventHandler(this.throttleBackButton_Click);
            // 
            // throttleForwardButton
            // 
            this.throttleForwardButton.Image = ((System.Drawing.Image)(resources.GetObject("throttleForwardButton.Image")));
            this.throttleForwardButton.Location = new System.Drawing.Point(1182, 786);
            this.throttleForwardButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.throttleForwardButton.Name = "throttleForwardButton";
            this.throttleForwardButton.Size = new System.Drawing.Size(42, 35);
            this.throttleForwardButton.TabIndex = 17;
            this.throttleForwardButton.UseVisualStyleBackColor = true;
            this.throttleForwardButton.Click += new System.EventHandler(this.throttleForwardButton_Click);
            // 
            // steeringPictureBox
            // 
            this.steeringPictureBox.Location = new System.Drawing.Point(1131, 655);
            this.steeringPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.steeringPictureBox.Name = "steeringPictureBox";
            this.steeringPictureBox.Size = new System.Drawing.Size(144, 77);
            this.steeringPictureBox.TabIndex = 16;
            this.steeringPictureBox.TabStop = false;
            // 
            // centerSteeringButton
            // 
            this.centerSteeringButton.Image = ((System.Drawing.Image)(resources.GetObject("centerSteeringButton.Image")));
            this.centerSteeringButton.Location = new System.Drawing.Point(1182, 742);
            this.centerSteeringButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.centerSteeringButton.Name = "centerSteeringButton";
            this.centerSteeringButton.Size = new System.Drawing.Size(42, 35);
            this.centerSteeringButton.TabIndex = 15;
            this.centerSteeringButton.UseVisualStyleBackColor = true;
            this.centerSteeringButton.Click += new System.EventHandler(this.centerSteeringButton_Click);
            // 
            // turnRightButton
            // 
            this.turnRightButton.Image = ((System.Drawing.Image)(resources.GetObject("turnRightButton.Image")));
            this.turnRightButton.Location = new System.Drawing.Point(1233, 742);
            this.turnRightButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.turnRightButton.Name = "turnRightButton";
            this.turnRightButton.Size = new System.Drawing.Size(42, 35);
            this.turnRightButton.TabIndex = 14;
            this.turnRightButton.UseVisualStyleBackColor = true;
            this.turnRightButton.Click += new System.EventHandler(this.turnRightButton_Click);
            // 
            // turnLeftButton
            // 
            this.turnLeftButton.Image = ((System.Drawing.Image)(resources.GetObject("turnLeftButton.Image")));
            this.turnLeftButton.Location = new System.Drawing.Point(1131, 742);
            this.turnLeftButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.turnLeftButton.Name = "turnLeftButton";
            this.turnLeftButton.Size = new System.Drawing.Size(42, 35);
            this.turnLeftButton.TabIndex = 13;
            this.turnLeftButton.UseVisualStyleBackColor = true;
            this.turnLeftButton.Click += new System.EventHandler(this.turnLeftButton_Click);
            // 
            // MFCD2Panel
            // 
            this.MFCD2Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MFCD2Panel.Controls.Add(this.MFCD2HDGDisplayLabel);
            this.MFCD2Panel.Controls.Add(this.MFCD2PictureBox);
            this.MFCD2Panel.Location = new System.Drawing.Point(620, 110);
            this.MFCD2Panel.Name = "MFCD2Panel";
            this.MFCD2Panel.Size = new System.Drawing.Size(800, 480);
            this.MFCD2Panel.TabIndex = 57;
            // 
            // MFCD2HDGDisplayLabel
            // 
            this.MFCD2HDGDisplayLabel.AutoSize = true;
            this.MFCD2HDGDisplayLabel.BackColor = System.Drawing.Color.Transparent;
            this.MFCD2HDGDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MFCD2HDGDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MFCD2HDGDisplayLabel.ForeColor = System.Drawing.Color.Black;
            this.MFCD2HDGDisplayLabel.Location = new System.Drawing.Point(376, 0);
            this.MFCD2HDGDisplayLabel.Name = "MFCD2HDGDisplayLabel";
            this.MFCD2HDGDisplayLabel.Size = new System.Drawing.Size(51, 22);
            this.MFCD2HDGDisplayLabel.TabIndex = 57;
            this.MFCD2HDGDisplayLabel.Text = "HDG";
            // 
            // MFCD2PictureBox
            // 
            this.MFCD2PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MFCD2PictureBox.Location = new System.Drawing.Point(0, 0);
            this.MFCD2PictureBox.Name = "MFCD2PictureBox";
            this.MFCD2PictureBox.Size = new System.Drawing.Size(800, 480);
            this.MFCD2PictureBox.TabIndex = 58;
            this.MFCD2PictureBox.TabStop = false;
            this.MFCD2PictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MFCD2PictureBox_Paint);
            // 
            // MRS1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1512, 1122);
            this.Controls.Add(this.OSB1);
            this.Controls.Add(this.HDGDisplayLabel);
            this.Controls.Add(this.MFCD1PictureBox);
            this.Controls.Add(this.serialCommsDataPanel);
            this.Controls.Add(this.speed25Button);
            this.Controls.Add(this.speed50Button);
            this.Controls.Add(this.speed75Button);
            this.Controls.Add(this.speed100Button);
            this.Controls.Add(this.tRexAccelerometerPanel);
            this.Controls.Add(this.tRexStatusPanel);
            this.Controls.Add(this.textMessageTextBox);
            this.Controls.Add(this.rMotSpeedDisplayLabel);
            this.Controls.Add(this.lMotSpeedDisplayLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.throttleSettingDisplayLabel);
            this.Controls.Add(this.throttleBackButton);
            this.Controls.Add(this.throttleForwardButton);
            this.Controls.Add(this.steeringPictureBox);
            this.Controls.Add(this.centerSteeringButton);
            this.Controls.Add(this.turnRightButton);
            this.Controls.Add(this.turnLeftButton);
            this.Controls.Add(this.MRS1MainToolStrip);
            this.Controls.Add(this.MRS1MainStatusStrip);
            this.Controls.Add(this.MFCD2Panel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MRS1";
            this.Text = "MRS1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MRS1_FormClosing);
            this.Load += new System.EventHandler(this.MRS1_Load);
            this.MRS1MainToolStrip.ResumeLayout(false);
            this.MRS1MainToolStrip.PerformLayout();
            this.tRexStatusPanel.ResumeLayout(false);
            this.tRexStatusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.motorBatteryPictureBox)).EndInit();
            this.tRexAccelerometerPanel.ResumeLayout(false);
            this.tRexAccelerometerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.serialCommsDataPanel.ResumeLayout(false);
            this.serialCommsDataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MFCD1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.steeringPictureBox)).EndInit();
            this.MFCD2Panel.ResumeLayout(false);
            this.MFCD2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MFCD2PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort MRSMainControllerSerialPort;
        private System.Windows.Forms.StatusStrip MRS1MainStatusStrip;
        private System.Windows.Forms.ToolStrip MRS1MainToolStrip;
        private System.Windows.Forms.Timer displayUpdateTimer;
        private System.Windows.Forms.ToolStripButton serialConnectToolStripButton;
        private System.Windows.Forms.ToolStripButton toggleSerialCommDataPanelToolStripButton;
        private System.Windows.Forms.Button turnLeftButton;
        private System.Windows.Forms.Button turnRightButton;
        private System.Windows.Forms.Button centerSteeringButton;
        private System.Windows.Forms.PictureBox steeringPictureBox;
        private System.Windows.Forms.Button throttleForwardButton;
        private System.Windows.Forms.Button throttleBackButton;
        private System.Windows.Forms.Label throttleSettingDisplayLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label lMotSpeedDisplayLabel;
        private System.Windows.Forms.Label rMotSpeedDisplayLabel;
        private System.Windows.Forms.TextBox textMessageTextBox;
        private System.Windows.Forms.ToolStripComboBox comPortToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton testToolStripButton;
        private System.Windows.Forms.ToolStripButton i2cToolStripButton;
        private System.Windows.Forms.ToolStripButton rcToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel tRexStatusPanel;
        private System.Windows.Forms.Label leftIMotorDisplayLabel;
        private System.Windows.Forms.Label iMotorLabel;
        private System.Windows.Forms.Label tRexVSupplyDisplayLabel;
        private System.Windows.Forms.Label rightIMotorDisplayLabel;
        private System.Windows.Forms.Label mALAbel;
        private System.Windows.Forms.Label vdcLabel;
        private System.Windows.Forms.PictureBox motorBatteryPictureBox;
        private System.Windows.Forms.Panel tRexAccelerometerPanel;
        private System.Windows.Forms.Label trexAccelerometerPanelLabel;
        private System.Windows.Forms.Label tRexXAccelDisplayLabel;
        private System.Windows.Forms.Label tRexZAccelDisplayLabel;
        private System.Windows.Forms.Label tRexYAccelDisplayLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button speed100Button;
        private System.Windows.Forms.Button speed75Button;
        private System.Windows.Forms.Button speed50Button;
        private System.Windows.Forms.Button speed25Button;
        private System.Windows.Forms.Panel serialCommsDataPanel;
        private System.Windows.Forms.Label packetDisplayLabel;
        private System.Windows.Forms.Label commErrorDisplayLabel;
        private System.Windows.Forms.CheckBox showAllBufferUpdatesCheckBox;
        private System.Windows.Forms.Label bytePositionLabel;
        private System.Windows.Forms.Label inBufferDisplayLabel;
        private System.Windows.Forms.Label outBufferDisplayLabel;
        private System.Windows.Forms.Label mcspStopBitsDisplayLabel;
        private System.Windows.Forms.Label mcspDataBitsDisplayLabel;
        private System.Windows.Forms.Label mcspParityDisplayLabel;
        private System.Windows.Forms.Label mcspBaudRateDisplayLabel;
        private System.Windows.Forms.Label mcspPortDisplayLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toggleDisplayUpdateTimerToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button OSB1;
        private System.Windows.Forms.PictureBox MFCD1PictureBox;
        private System.Windows.Forms.Label HDGDisplayLabel;
        private System.Windows.Forms.Panel MFCD2Panel;
        private System.Windows.Forms.Label MFCD2HDGDisplayLabel;
        private System.Windows.Forms.PictureBox MFCD2PictureBox;
    }
}

