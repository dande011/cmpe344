namespace avrdudess
{
    partial class Form1
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
            this.cmbProg = new System.Windows.Forms.ComboBox();
            this.cmbMCU = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBitClock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbForce = new System.Windows.Forms.CheckBox();
            this.cbNoVerify = new System.Windows.Forms.CheckBox();
            this.btnProgram = new System.Windows.Forms.Button();
            this.txtHFuse = new System.Windows.Forms.TextBox();
            this.txtLFuse = new System.Windows.Forms.TextBox();
            this.txtEFuse = new System.Windows.Forms.TextBox();
            this.cmbPresets = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnPresetSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPresetDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCmdLine = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbEEPROMFile = new System.Windows.Forms.GroupBox();
            this.pEEPROMOp = new System.Windows.Forms.Panel();
            this.rbEEPROMOpVerify = new System.Windows.Forms.RadioButton();
            this.rbEEPROMOpRead = new System.Windows.Forms.RadioButton();
            this.rbEEPROMOpWrite = new System.Windows.Forms.RadioButton();
            this.txtEEPROMFile = new System.Windows.Forms.TextBox();
            this.cmbEEPROMFormat = new System.Windows.Forms.ComboBox();
            this.btnEEPROMBrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.gbFlashFile = new System.Windows.Forms.GroupBox();
            this.pFlashOp = new System.Windows.Forms.Panel();
            this.rbFlashOpVerify = new System.Windows.Forms.RadioButton();
            this.rbFlashOpRead = new System.Windows.Forms.RadioButton();
            this.rbFlashOpWrite = new System.Windows.Forms.RadioButton();
            this.txtFlashFile = new System.Windows.Forms.TextBox();
            this.cmbFlashFormat = new System.Windows.Forms.ComboBox();
            this.btnFlashBrowse = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbShowToolTips = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbSetFuses = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReadFuses = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbDoNotWrite = new System.Windows.Forms.CheckBox();
            this.cbDisableFlashErase = new System.Windows.Forms.CheckBox();
            this.cbEraseFlashEEPROM = new System.Windows.Forms.CheckBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbSetLock = new System.Windows.Forms.CheckBox();
            this.btnReadLock = new System.Windows.Forms.Button();
            this.txtLock = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnForceStop = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtAdditional = new System.Windows.Forms.TextBox();
            this.statusBar1 = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdVerbose = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbEEPROMFile.SuspendLayout();
            this.pEEPROMOp.SuspendLayout();
            this.gbFlashFile.SuspendLayout();
            this.pFlashOp.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.statusBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbProg
            // 
            this.cmbProg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProg.FormattingEnabled = true;
            this.cmbProg.Location = new System.Drawing.Point(6, 32);
            this.cmbProg.Name = "cmbProg";
            this.cmbProg.Size = new System.Drawing.Size(176, 21);
            this.cmbProg.TabIndex = 1;
            this.cmbProg.SelectedIndexChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // cmbMCU
            // 
            this.cmbMCU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMCU.FormattingEnabled = true;
            this.cmbMCU.Location = new System.Drawing.Point(6, 72);
            this.cmbMCU.Name = "cmbMCU";
            this.cmbMCU.Size = new System.Drawing.Size(176, 21);
            this.cmbMCU.TabIndex = 2;
            this.cmbMCU.SelectedIndexChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Programmer (-c)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "MCU (-p)";
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(6, 112);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(176, 21);
            this.cmbPort.TabIndex = 3;
            this.cmbPort.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port (-P)";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(6, 152);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(176, 20);
            this.txtBaudRate.TabIndex = 4;
            this.txtBaudRate.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            this.txtBaudRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Baud rate (-b)";
            // 
            // txtBitClock
            // 
            this.txtBitClock.Location = new System.Drawing.Point(6, 191);
            this.txtBitClock.Name = "txtBitClock";
            this.txtBitClock.Size = new System.Drawing.Size(176, 20);
            this.txtBitClock.TabIndex = 5;
            this.txtBitClock.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            this.txtBitClock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Bit clock (-B)";
            // 
            // cbForce
            // 
            this.cbForce.AutoSize = true;
            this.cbForce.Location = new System.Drawing.Point(6, 19);
            this.cbForce.Name = "cbForce";
            this.cbForce.Size = new System.Drawing.Size(71, 17);
            this.cbForce.TabIndex = 30;
            this.cbForce.Text = "Force (-F)";
            this.cbForce.UseVisualStyleBackColor = true;
            this.cbForce.CheckedChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // cbNoVerify
            // 
            this.cbNoVerify.AutoSize = true;
            this.cbNoVerify.Location = new System.Drawing.Point(6, 42);
            this.cbNoVerify.Name = "cbNoVerify";
            this.cbNoVerify.Size = new System.Drawing.Size(108, 17);
            this.cbNoVerify.TabIndex = 31;
            this.cbNoVerify.Text = "Disable verify (-V)";
            this.cbNoVerify.UseVisualStyleBackColor = true;
            this.cbNoVerify.CheckedChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // btnProgram
            // 
            this.btnProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgram.Location = new System.Drawing.Point(12, 337);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(192, 23);
            this.btnProgram.TabIndex = 36;
            this.btnProgram.Text = "Start!";
            this.btnProgram.UseVisualStyleBackColor = true;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
            // 
            // txtHFuse
            // 
            this.txtHFuse.Location = new System.Drawing.Point(25, 42);
            this.txtHFuse.Name = "txtHFuse";
            this.txtHFuse.Size = new System.Drawing.Size(43, 20);
            this.txtHFuse.TabIndex = 22;
            this.txtHFuse.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            this.txtHFuse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHex_KeyPress);
            // 
            // txtLFuse
            // 
            this.txtLFuse.Location = new System.Drawing.Point(25, 16);
            this.txtLFuse.Name = "txtLFuse";
            this.txtLFuse.Size = new System.Drawing.Size(43, 20);
            this.txtLFuse.TabIndex = 21;
            this.txtLFuse.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            this.txtLFuse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHex_KeyPress);
            // 
            // txtEFuse
            // 
            this.txtEFuse.Location = new System.Drawing.Point(25, 68);
            this.txtEFuse.Name = "txtEFuse";
            this.txtEFuse.Size = new System.Drawing.Size(43, 20);
            this.txtEFuse.TabIndex = 23;
            this.txtEFuse.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            this.txtEFuse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHex_KeyPress);
            // 
            // cmbPresets
            // 
            this.cmbPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPresets.FormattingEnabled = true;
            this.cmbPresets.Location = new System.Drawing.Point(6, 19);
            this.cmbPresets.Name = "cmbPresets";
            this.cmbPresets.Size = new System.Drawing.Size(188, 21);
            this.cmbPresets.TabIndex = 18;
            this.cmbPresets.SelectedIndexChanged += new System.EventHandler(this.cbPresets_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(125, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 13);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Fuse settings";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnPresetSave
            // 
            this.btnPresetSave.Location = new System.Drawing.Point(6, 46);
            this.btnPresetSave.Name = "btnPresetSave";
            this.btnPresetSave.Size = new System.Drawing.Size(75, 23);
            this.btnPresetSave.TabIndex = 19;
            this.btnPresetSave.Text = "Save...";
            this.btnPresetSave.UseVisualStyleBackColor = true;
            this.btnPresetSave.Click += new System.EventHandler(this.btnPresetSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPresetDelete);
            this.groupBox1.Controls.Add(this.btnPresetSave);
            this.groupBox1.Controls.Add(this.cmbPresets);
            this.groupBox1.Location = new System.Drawing.Point(416, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presets";
            // 
            // btnPresetDelete
            // 
            this.btnPresetDelete.Location = new System.Drawing.Point(87, 46);
            this.btnPresetDelete.Name = "btnPresetDelete";
            this.btnPresetDelete.Size = new System.Drawing.Size(75, 23);
            this.btnPresetDelete.TabIndex = 20;
            this.btnPresetDelete.Text = "Delete...";
            this.btnPresetDelete.UseVisualStyleBackColor = true;
            this.btnPresetDelete.Click += new System.EventHandler(this.btnPresetDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbProg);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbMCU);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbPort);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtBaudRate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtBitClock);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 221);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Main";
            // 
            // txtCmdLine
            // 
            this.txtCmdLine.Location = new System.Drawing.Point(12, 366);
            this.txtCmdLine.Name = "txtCmdLine";
            this.txtCmdLine.ReadOnly = true;
            this.txtCmdLine.Size = new System.Drawing.Size(604, 20);
            this.txtCmdLine.TabIndex = 50;
            this.txtCmdLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCmdLine_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gbEEPROMFile);
            this.groupBox3.Controls.Add(this.gbFlashFile);
            this.groupBox3.Location = new System.Drawing.Point(210, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 221);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Files";
            // 
            // gbEEPROMFile
            // 
            this.gbEEPROMFile.Controls.Add(this.pEEPROMOp);
            this.gbEEPROMFile.Controls.Add(this.txtEEPROMFile);
            this.gbEEPROMFile.Controls.Add(this.cmbEEPROMFormat);
            this.gbEEPROMFile.Controls.Add(this.btnEEPROMBrowse);
            this.gbEEPROMFile.Controls.Add(this.label6);
            this.gbEEPROMFile.Location = new System.Drawing.Point(6, 117);
            this.gbEEPROMFile.Name = "gbEEPROMFile";
            this.gbEEPROMFile.Size = new System.Drawing.Size(188, 98);
            this.gbEEPROMFile.TabIndex = 5;
            this.gbEEPROMFile.TabStop = false;
            this.gbEEPROMFile.Text = "EEPROM";
            // 
            // pEEPROMOp
            // 
            this.pEEPROMOp.Controls.Add(this.rbEEPROMOpVerify);
            this.pEEPROMOp.Controls.Add(this.rbEEPROMOpRead);
            this.pEEPROMOp.Controls.Add(this.rbEEPROMOpWrite);
            this.pEEPROMOp.Location = new System.Drawing.Point(3, 68);
            this.pEEPROMOp.Name = "pEEPROMOp";
            this.pEEPROMOp.Size = new System.Drawing.Size(179, 22);
            this.pEEPROMOp.TabIndex = 33;
            // 
            // rbEEPROMOpVerify
            // 
            this.rbEEPROMOpVerify.AutoSize = true;
            this.rbEEPROMOpVerify.Location = new System.Drawing.Point(119, 3);
            this.rbEEPROMOpVerify.Name = "rbEEPROMOpVerify";
            this.rbEEPROMOpVerify.Size = new System.Drawing.Size(51, 17);
            this.rbEEPROMOpVerify.TabIndex = 17;
            this.rbEEPROMOpVerify.Text = "Verify";
            this.rbEEPROMOpVerify.UseVisualStyleBackColor = true;
            this.rbEEPROMOpVerify.CheckedChanged += new System.EventHandler(this.radioButton_flashEEPROMOp_CheckedChanged);
            // 
            // rbEEPROMOpRead
            // 
            this.rbEEPROMOpRead.AutoSize = true;
            this.rbEEPROMOpRead.Location = new System.Drawing.Point(62, 3);
            this.rbEEPROMOpRead.Name = "rbEEPROMOpRead";
            this.rbEEPROMOpRead.Size = new System.Drawing.Size(51, 17);
            this.rbEEPROMOpRead.TabIndex = 16;
            this.rbEEPROMOpRead.Text = "Read";
            this.rbEEPROMOpRead.UseVisualStyleBackColor = true;
            this.rbEEPROMOpRead.CheckedChanged += new System.EventHandler(this.radioButton_flashEEPROMOp_CheckedChanged);
            // 
            // rbEEPROMOpWrite
            // 
            this.rbEEPROMOpWrite.AutoSize = true;
            this.rbEEPROMOpWrite.Checked = true;
            this.rbEEPROMOpWrite.Location = new System.Drawing.Point(6, 3);
            this.rbEEPROMOpWrite.Name = "rbEEPROMOpWrite";
            this.rbEEPROMOpWrite.Size = new System.Drawing.Size(50, 17);
            this.rbEEPROMOpWrite.TabIndex = 15;
            this.rbEEPROMOpWrite.TabStop = true;
            this.rbEEPROMOpWrite.Text = "Write";
            this.rbEEPROMOpWrite.UseVisualStyleBackColor = true;
            this.rbEEPROMOpWrite.CheckedChanged += new System.EventHandler(this.radioButton_flashEEPROMOp_CheckedChanged);
            // 
            // txtEEPROMFile
            // 
            this.txtEEPROMFile.Location = new System.Drawing.Point(6, 19);
            this.txtEEPROMFile.Name = "txtEEPROMFile";
            this.txtEEPROMFile.Size = new System.Drawing.Size(145, 20);
            this.txtEEPROMFile.TabIndex = 12;
            this.txtEEPROMFile.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // cmbEEPROMFormat
            // 
            this.cmbEEPROMFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEEPROMFormat.FormattingEnabled = true;
            this.cmbEEPROMFormat.Location = new System.Drawing.Point(51, 45);
            this.cmbEEPROMFormat.Name = "cmbEEPROMFormat";
            this.cmbEEPROMFormat.Size = new System.Drawing.Size(131, 21);
            this.cmbEEPROMFormat.TabIndex = 14;
            this.cmbEEPROMFormat.SelectedIndexChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // btnEEPROMBrowse
            // 
            this.btnEEPROMBrowse.Location = new System.Drawing.Point(157, 19);
            this.btnEEPROMBrowse.Name = "btnEEPROMBrowse";
            this.btnEEPROMBrowse.Size = new System.Drawing.Size(25, 20);
            this.btnEEPROMBrowse.TabIndex = 13;
            this.btnEEPROMBrowse.Text = "...";
            this.btnEEPROMBrowse.UseVisualStyleBackColor = true;
            this.btnEEPROMBrowse.Click += new System.EventHandler(this.btnEEPROMBrowse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Format";
            // 
            // gbFlashFile
            // 
            this.gbFlashFile.Controls.Add(this.pFlashOp);
            this.gbFlashFile.Controls.Add(this.txtFlashFile);
            this.gbFlashFile.Controls.Add(this.cmbFlashFormat);
            this.gbFlashFile.Controls.Add(this.btnFlashBrowse);
            this.gbFlashFile.Controls.Add(this.label11);
            this.gbFlashFile.Location = new System.Drawing.Point(6, 16);
            this.gbFlashFile.Name = "gbFlashFile";
            this.gbFlashFile.Size = new System.Drawing.Size(188, 98);
            this.gbFlashFile.TabIndex = 4;
            this.gbFlashFile.TabStop = false;
            this.gbFlashFile.Text = "Flash";
            // 
            // pFlashOp
            // 
            this.pFlashOp.Controls.Add(this.rbFlashOpVerify);
            this.pFlashOp.Controls.Add(this.rbFlashOpRead);
            this.pFlashOp.Controls.Add(this.rbFlashOpWrite);
            this.pFlashOp.Location = new System.Drawing.Point(3, 68);
            this.pFlashOp.Name = "pFlashOp";
            this.pFlashOp.Size = new System.Drawing.Size(179, 22);
            this.pFlashOp.TabIndex = 33;
            // 
            // rbFlashOpVerify
            // 
            this.rbFlashOpVerify.AutoSize = true;
            this.rbFlashOpVerify.Location = new System.Drawing.Point(119, 3);
            this.rbFlashOpVerify.Name = "rbFlashOpVerify";
            this.rbFlashOpVerify.Size = new System.Drawing.Size(51, 17);
            this.rbFlashOpVerify.TabIndex = 11;
            this.rbFlashOpVerify.Text = "Verify";
            this.rbFlashOpVerify.UseVisualStyleBackColor = true;
            this.rbFlashOpVerify.CheckedChanged += new System.EventHandler(this.radioButton_flashEEPROMOp_CheckedChanged);
            // 
            // rbFlashOpRead
            // 
            this.rbFlashOpRead.AutoSize = true;
            this.rbFlashOpRead.Location = new System.Drawing.Point(62, 3);
            this.rbFlashOpRead.Name = "rbFlashOpRead";
            this.rbFlashOpRead.Size = new System.Drawing.Size(51, 17);
            this.rbFlashOpRead.TabIndex = 10;
            this.rbFlashOpRead.Text = "Read";
            this.rbFlashOpRead.UseVisualStyleBackColor = true;
            this.rbFlashOpRead.CheckedChanged += new System.EventHandler(this.radioButton_flashEEPROMOp_CheckedChanged);
            // 
            // rbFlashOpWrite
            // 
            this.rbFlashOpWrite.AutoSize = true;
            this.rbFlashOpWrite.Checked = true;
            this.rbFlashOpWrite.Location = new System.Drawing.Point(6, 3);
            this.rbFlashOpWrite.Name = "rbFlashOpWrite";
            this.rbFlashOpWrite.Size = new System.Drawing.Size(50, 17);
            this.rbFlashOpWrite.TabIndex = 9;
            this.rbFlashOpWrite.TabStop = true;
            this.rbFlashOpWrite.Text = "Write";
            this.rbFlashOpWrite.UseVisualStyleBackColor = true;
            this.rbFlashOpWrite.CheckedChanged += new System.EventHandler(this.radioButton_flashEEPROMOp_CheckedChanged);
            // 
            // txtFlashFile
            // 
            this.txtFlashFile.Location = new System.Drawing.Point(6, 19);
            this.txtFlashFile.Name = "txtFlashFile";
            this.txtFlashFile.Size = new System.Drawing.Size(145, 20);
            this.txtFlashFile.TabIndex = 6;
            this.txtFlashFile.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // cmbFlashFormat
            // 
            this.cmbFlashFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFlashFormat.FormattingEnabled = true;
            this.cmbFlashFormat.Location = new System.Drawing.Point(51, 45);
            this.cmbFlashFormat.Name = "cmbFlashFormat";
            this.cmbFlashFormat.Size = new System.Drawing.Size(131, 21);
            this.cmbFlashFormat.TabIndex = 8;
            this.cmbFlashFormat.SelectedIndexChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // btnFlashBrowse
            // 
            this.btnFlashBrowse.Location = new System.Drawing.Point(157, 19);
            this.btnFlashBrowse.Name = "btnFlashBrowse";
            this.btnFlashBrowse.Size = new System.Drawing.Size(25, 20);
            this.btnFlashBrowse.TabIndex = 7;
            this.btnFlashBrowse.Text = "...";
            this.btnFlashBrowse.UseVisualStyleBackColor = true;
            this.btnFlashBrowse.Click += new System.EventHandler(this.btnFlashBrowse_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Format";
            // 
            // cbShowToolTips
            // 
            this.cbShowToolTips.AutoSize = true;
            this.cbShowToolTips.Checked = true;
            this.cbShowToolTips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowToolTips.Location = new System.Drawing.Point(416, 341);
            this.cbShowToolTips.Name = "cbShowToolTips";
            this.cbShowToolTips.Size = new System.Drawing.Size(89, 17);
            this.cbShowToolTips.TabIndex = 38;
            this.cbShowToolTips.Text = "Show tooltips";
            this.cbShowToolTips.UseVisualStyleBackColor = true;
            this.cbShowToolTips.CheckedChanged += new System.EventHandler(this.cbShowToolTips_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbSetFuses);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btnReadFuses);
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.txtHFuse);
            this.groupBox4.Controls.Add(this.txtLFuse);
            this.groupBox4.Controls.Add(this.txtEFuse);
            this.groupBox4.Location = new System.Drawing.Point(416, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fuses";
            // 
            // cbSetFuses
            // 
            this.cbSetFuses.AutoSize = true;
            this.cbSetFuses.Checked = true;
            this.cbSetFuses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSetFuses.Location = new System.Drawing.Point(124, 74);
            this.cbSetFuses.Name = "cbSetFuses";
            this.cbSetFuses.Size = new System.Drawing.Size(70, 17);
            this.cbSetFuses.TabIndex = 26;
            this.cbSetFuses.Text = "Set fuses";
            this.cbSetFuses.UseVisualStyleBackColor = true;
            this.cbSetFuses.CheckedChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "E";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "L";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "H";
            // 
            // btnReadFuses
            // 
            this.btnReadFuses.Location = new System.Drawing.Point(96, 42);
            this.btnReadFuses.Name = "btnReadFuses";
            this.btnReadFuses.Size = new System.Drawing.Size(98, 23);
            this.btnReadFuses.TabIndex = 25;
            this.btnReadFuses.Text = "Read from MCU";
            this.btnReadFuses.UseVisualStyleBackColor = true;
            this.btnReadFuses.Click += new System.EventHandler(this.btnReadFuses_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.cmdVerbose);
            this.groupBox5.Controls.Add(this.cbDoNotWrite);
            this.groupBox5.Controls.Add(this.cbForce);
            this.groupBox5.Controls.Add(this.cbDisableFlashErase);
            this.groupBox5.Controls.Add(this.cbEraseFlashEEPROM);
            this.groupBox5.Controls.Add(this.cbNoVerify);
            this.groupBox5.Location = new System.Drawing.Point(12, 239);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(398, 92);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Options";
            // 
            // cbDoNotWrite
            // 
            this.cbDoNotWrite.AutoSize = true;
            this.cbDoNotWrite.Location = new System.Drawing.Point(154, 42);
            this.cbDoNotWrite.Name = "cbDoNotWrite";
            this.cbDoNotWrite.Size = new System.Drawing.Size(101, 17);
            this.cbDoNotWrite.TabIndex = 34;
            this.cbDoNotWrite.Text = "Do not write (-n)";
            this.cbDoNotWrite.UseVisualStyleBackColor = true;
            this.cbDoNotWrite.CheckedChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // cbDisableFlashErase
            // 
            this.cbDisableFlashErase.AutoSize = true;
            this.cbDisableFlashErase.Location = new System.Drawing.Point(6, 65);
            this.cbDisableFlashErase.Name = "cbDisableFlashErase";
            this.cbDisableFlashErase.Size = new System.Drawing.Size(135, 17);
            this.cbDisableFlashErase.TabIndex = 32;
            this.cbDisableFlashErase.Text = "Disable flash erase (-D)";
            this.cbDisableFlashErase.UseVisualStyleBackColor = true;
            this.cbDisableFlashErase.CheckedChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // cbEraseFlashEEPROM
            // 
            this.cbEraseFlashEEPROM.AutoSize = true;
            this.cbEraseFlashEEPROM.Location = new System.Drawing.Point(154, 19);
            this.cbEraseFlashEEPROM.Name = "cbEraseFlashEEPROM";
            this.cbEraseFlashEEPROM.Size = new System.Drawing.Size(166, 17);
            this.cbEraseFlashEEPROM.TabIndex = 33;
            this.cbEraseFlashEEPROM.Text = "Erase flash and EEPROM (-e)";
            this.cbEraseFlashEEPROM.UseVisualStyleBackColor = true;
            this.cbEraseFlashEEPROM.CheckedChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(590, 337);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(26, 23);
            this.btnAbout.TabIndex = 39;
            this.btnAbout.Text = "?";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbSetLock);
            this.groupBox6.Controls.Add(this.btnReadLock);
            this.groupBox6.Controls.Add(this.txtLock);
            this.groupBox6.Location = new System.Drawing.Point(416, 203);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 74);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Lock bits";
            // 
            // cbSetLock
            // 
            this.cbSetLock.AutoSize = true;
            this.cbSetLock.Location = new System.Drawing.Point(124, 45);
            this.cbSetLock.Name = "cbSetLock";
            this.cbSetLock.Size = new System.Drawing.Size(65, 17);
            this.cbSetLock.TabIndex = 29;
            this.cbSetLock.Text = "Set lock";
            this.cbSetLock.UseVisualStyleBackColor = true;
            this.cbSetLock.CheckedChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // btnReadLock
            // 
            this.btnReadLock.Location = new System.Drawing.Point(96, 16);
            this.btnReadLock.Name = "btnReadLock";
            this.btnReadLock.Size = new System.Drawing.Size(98, 23);
            this.btnReadLock.TabIndex = 28;
            this.btnReadLock.Text = "Read from MCU";
            this.btnReadLock.UseVisualStyleBackColor = true;
            this.btnReadLock.Click += new System.EventHandler(this.btnReadLock_Click);
            // 
            // txtLock
            // 
            this.txtLock.Location = new System.Drawing.Point(6, 19);
            this.txtLock.Name = "txtLock";
            this.txtLock.Size = new System.Drawing.Size(43, 20);
            this.txtLock.TabIndex = 27;
            this.txtLock.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            this.txtLock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHex_KeyPress);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnForceStop
            // 
            this.btnForceStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnForceStop.Location = new System.Drawing.Point(210, 337);
            this.btnForceStop.Name = "btnForceStop";
            this.btnForceStop.Size = new System.Drawing.Size(75, 23);
            this.btnForceStop.TabIndex = 37;
            this.btnForceStop.Text = "Stop";
            this.btnForceStop.UseVisualStyleBackColor = true;
            this.btnForceStop.Click += new System.EventHandler(this.btnForceStop_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtAdditional);
            this.groupBox7.Location = new System.Drawing.Point(416, 283);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 48);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Additional settings";
            // 
            // txtAdditional
            // 
            this.txtAdditional.Location = new System.Drawing.Point(6, 19);
            this.txtAdditional.Name = "txtAdditional";
            this.txtAdditional.Size = new System.Drawing.Size(188, 20);
            this.txtAdditional.TabIndex = 35;
            this.txtAdditional.TextChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // statusBar1
            // 
            this.statusBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus});
            this.statusBar1.Location = new System.Drawing.Point(0, 397);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(628, 22);
            this.statusBar1.TabIndex = 37;
            // 
            // tssStatus
            // 
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(38, 17);
            this.tssStatus.Text = "Ready";
            // 
            // cmdVerbose
            // 
            this.cmdVerbose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdVerbose.FormattingEnabled = true;
            this.cmdVerbose.Location = new System.Drawing.Point(207, 63);
            this.cmdVerbose.Name = "cmdVerbose";
            this.cmdVerbose.Size = new System.Drawing.Size(95, 21);
            this.cmdVerbose.TabIndex = 35;
            this.cmdVerbose.SelectedIndexChanged += new System.EventHandler(this.event_generateCmdLine);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(151, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Verbosity";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnProgram;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnForceStop;
            this.ClientSize = new System.Drawing.Size(628, 419);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnForceStop);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cbShowToolTips);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtCmdLine);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProgram);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.gbEEPROMFile.ResumeLayout(false);
            this.gbEEPROMFile.PerformLayout();
            this.pEEPROMOp.ResumeLayout(false);
            this.pEEPROMOp.PerformLayout();
            this.gbFlashFile.ResumeLayout(false);
            this.gbFlashFile.PerformLayout();
            this.pFlashOp.ResumeLayout(false);
            this.pFlashOp.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.statusBar1.ResumeLayout(false);
            this.statusBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProg;
        private System.Windows.Forms.ComboBox cmbMCU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBitClock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbForce;
        private System.Windows.Forms.CheckBox cbNoVerify;
        private System.Windows.Forms.Button btnProgram;
        private System.Windows.Forms.TextBox txtHFuse;
        private System.Windows.Forms.TextBox txtLFuse;
        private System.Windows.Forms.TextBox txtEFuse;
        private System.Windows.Forms.ComboBox cmbPresets;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnPresetSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCmdLine;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFlashBrowse;
        private System.Windows.Forms.TextBox txtFlashFile;
        private System.Windows.Forms.CheckBox cbShowToolTips;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnReadFuses;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPresetDelete;
        private System.Windows.Forms.GroupBox gbFlashFile;
        private System.Windows.Forms.Panel pFlashOp;
        private System.Windows.Forms.RadioButton rbFlashOpVerify;
        private System.Windows.Forms.RadioButton rbFlashOpRead;
        private System.Windows.Forms.RadioButton rbFlashOpWrite;
        private System.Windows.Forms.ComboBox cmbFlashFormat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gbEEPROMFile;
        private System.Windows.Forms.Panel pEEPROMOp;
        private System.Windows.Forms.RadioButton rbEEPROMOpVerify;
        private System.Windows.Forms.RadioButton rbEEPROMOpRead;
        private System.Windows.Forms.RadioButton rbEEPROMOpWrite;
        private System.Windows.Forms.TextBox txtEEPROMFile;
        private System.Windows.Forms.ComboBox cmbEEPROMFormat;
        private System.Windows.Forms.Button btnEEPROMBrowse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbDoNotWrite;
        private System.Windows.Forms.CheckBox cbDisableFlashErase;
        private System.Windows.Forms.CheckBox cbEraseFlashEEPROM;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnForceStop;
        private System.Windows.Forms.TextBox txtLock;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtAdditional;
        private System.Windows.Forms.StatusStrip statusBar1;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.CheckBox cbSetFuses;
        private System.Windows.Forms.Button btnReadLock;
        private System.Windows.Forms.CheckBox cbSetLock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmdVerbose;
    }
}

