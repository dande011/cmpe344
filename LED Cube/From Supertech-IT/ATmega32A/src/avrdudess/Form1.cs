/*
 * Project: AVRDUDESS - A GUI for AVRDUDE
 * Author: Zak Kemble, me@zakkemble.co.uk
 * Copyright: (C) 2013 by Zak Kemble
 * License: GNU GPL v3 (see License.txt)
 * Web: http://blog.zakkemble.co.uk/avrdudess-a-gui-for-avrdude/
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace avrdudess
{
    public partial class Form1 : Form
    {
        private const string FILE_AVRDUDECONF = "avrdude.conf";
        private const string WEB_ADDR_FUSE_SETTINGS = "http://www.engbedded.com/fusecalc";

        private List<Programmer> programmers    = new List<Programmer>();
        private List<MCU> mcus                  = new List<MCU>();
        private List<FileFormat> fileFormats    = new List<FileFormat>();
        private ToolTip ToolTip1                = new ToolTip();
        private Avrdude avrdude;
        public Presets presets;
        private FormPresetSave savePreset;
        private FormPresetDelete deletePreset;
        private CmdLine cmdLine;
        private UpdateCheck updater;
        public bool ready                       = false;
        private string flashOperation           = "w";
        private string EEPROMOperation          = "w";

        public string prog
        {
            get { return ((Programmer)cmbProg.SelectedItem).name; }
            set
            {
                bool ok = false;
                foreach (Programmer b in programmers)
                {
                    if (b.name == value)
                    {
                        cmbProg.SelectedItem = b;
                        ok = true;
                        break;
                    }
                }
                if (!ok)
                    MessageBox.Show("Preset programmer not found (" + value + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public string mcu
        {
            get { return ((MCU)cmbMCU.SelectedItem).name; }
            set
            {
                bool ok = false;
                foreach (MCU b in mcus)
                {
                    if (b.name == value)
                    {
                        cmbMCU.SelectedItem = b;
                        ok = true;
                        break;
                    }
                }
                if (!ok)
                    MessageBox.Show("Preset MCU not found (" + value + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public string port
        {
            get { return cmbPort.Text.Trim(); }
            set { cmbPort.Text = value; }
        }

        public string baudRate
        {
            get { return txtBaudRate.Text.Trim(); }
            set { txtBaudRate.Text = value; }
        }

        public string bitClock
        {
            get { return txtBitClock.Text.Trim(); }
            set { txtBitClock.Text = value; }
        }

        public bool force
        {
            get { return cbForce.Checked; }
            set { cbForce.Checked = value; }
        }

        public bool disableVerify
        {
            get { return cbNoVerify.Checked; }
            set { cbNoVerify.Checked = value; }
        }

        public bool disableFlashErase
        {
            get { return cbDisableFlashErase.Checked; }
            set { cbDisableFlashErase.Checked = value; }
        }

        public bool eraseFlashAndEEPROM
        {
            get { return cbEraseFlashEEPROM.Checked; }
            set { cbEraseFlashEEPROM.Checked = value; }
        }

        public bool doNotWrite
        {
            get { return cbDoNotWrite.Checked; }
            set { cbDoNotWrite.Checked = value; }
        }

        public string cmdBox
        {
            set { txtCmdLine.Text = value; }
        }

        public string flashFile
        {
            get { return txtFlashFile.Text.Trim(); }
            set { txtFlashFile.Text = value; }
        }

        public string flashFileFormat
        {
            get { return ((FileFormat)cmbFlashFormat.SelectedItem).name; }
            set
            {
                foreach (FileFormat b in fileFormats)
                {
                    if (b.name == value)
                    {
                        cmbFlashFormat.SelectedItem = b;
                        break;
                    }
                }
            }
        }

        public string flashFileOperation
        {
            get { return flashOperation; }
            set
            {
                if (value == "w")
                    rbFlashOpWrite.Checked = true;
                else if (value == "r")
                    rbFlashOpRead.Checked = true;
                else
                    rbFlashOpVerify.Checked = true;
            }
        }

        public string EEPROMFile
        {
            get { return txtEEPROMFile.Text.Trim(); }
            set { txtEEPROMFile.Text = value; }
        }

        public string EEPROMFileFormat
        {
            get { return ((FileFormat)cmbEEPROMFormat.SelectedItem).name; }
            set
            {
                foreach (FileFormat b in fileFormats)
                {
                    if (b.name == value)
                    {
                        cmbEEPROMFormat.SelectedItem = b;
                        break;
                    }
                }
            }
        }

        public string EEPROMFileOperation
        {
            get { return EEPROMOperation; }
            set
            {
                if (value == "w")
                    rbEEPROMOpWrite.Checked = true;
                else if (value == "r")
                    rbEEPROMOpRead.Checked = true;
                else
                    rbEEPROMOpVerify.Checked = true;
            }
        }

        public bool setFuses
        {
            get { return cbSetFuses.Checked; }
            set { cbSetFuses.Checked = value; }
        }

        public string highFuse
        {
            get { return txtHFuse.Text; }
            set { txtHFuse.Text = value; }
        }

        public string lowFuse
        {
            get { return txtLFuse.Text; }
            set { txtLFuse.Text = value; }
        }

        public string exFuse
        {
            get { return txtEFuse.Text; }
            set { txtEFuse.Text = value; }
        }

        public bool setLock
        {
            get { return cbSetLock.Checked; }
            set { cbSetLock.Checked = value; }
        }

        public string lockSetting
        {
            get { return txtLock.Text; }
            set { txtLock.Text = value; }
        }

        public string additionalSettings
        {
            get { return txtAdditional.Text; }
            set { txtAdditional.Text = value; }
        }

        public string avrdudeStatus
        {
            set { tssStatus.Text = value; }
        }

        public byte verbosity
        {
            get { return (byte)cmdVerbose.SelectedItem; }
            set { cmdVerbose.SelectedItem = value; }
        }

        public Form1()
        {
            InitializeComponent();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Version version = assembly.GetName().Version;

            Icon = Icon.ExtractAssociatedIcon(assembly.Location);
            Text = String.Format("AVRDUDESS v{0}.{1}", version.Major, version.Minor);

            enableClientAreaDrag(Controls);

            // Update COM ports
            cmbPort.DropDown += new System.EventHandler(this.cbPort_DropDown);

            // Drag and drop
            gbFlashFile.AllowDrop = true;
            gbFlashFile.DragEnter += new DragEventHandler(event_DragEnter);
            gbFlashFile.DragDrop += new DragEventHandler(event_DragDrop);

            // Drag and drop
            gbEEPROMFile.AllowDrop = true;
            gbEEPROMFile.DragEnter += new DragEventHandler(event_DragEnter);
            gbEEPROMFile.DragDrop += new DragEventHandler(event_DragDrop);

            openFileDialog1.Filter = "Hex files (*.hex)|*.hex";
            openFileDialog1.Filter += "|EEPROM files (*.eep)|*.eep";
            openFileDialog1.Filter += "|All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Open flash file";

            openFileDialog2.Filter = "EEPROM files (*.eep)|*.eep";
            openFileDialog2.Filter += "|Hex files (*.hex)|*.hex";
            openFileDialog2.Filter += "|All files (*.*)|*.*";
            openFileDialog2.CheckFileExists = false;
            openFileDialog2.FileName = "";
            openFileDialog2.Title = "Open EEPROM file";

            fileFormats.Add(new FileFormat("a", "Auto (writing only)"));
            fileFormats.Add(new FileFormat("i", "Intel Hex"));
            fileFormats.Add(new FileFormat("s", "Motorola S-record"));
            fileFormats.Add(new FileFormat("r", "Raw binary"));
            fileFormats.Add(new FileFormat("d", "Decimal (reading only)"));
            fileFormats.Add(new FileFormat("h", "Hexadecimal (reading only)"));
            fileFormats.Add(new FileFormat("b", "Binary (reading only)"));

            cmdLine = new CmdLine(this);
            presets = new Presets(this);
            savePreset = new FormPresetSave(this);
            deletePreset = new FormPresetDelete(this);
            avrdude = new Avrdude(this);
        }

        private void enableClientAreaDrag(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is GroupBox)
                {
                    c.MouseDown += Form1_MouseDown;
                    c.MouseUp += Form1_MouseUp;
                    c.MouseMove += Form1_MouseMove;
                    //enableClientAreaDrag(c.Controls); // nested groupbox window drag not working correctly yet
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load programmers & MCUs
            loadConfig();

            // Sort alphabetically
            programmers.Sort();
            mcus.Sort();

            // Add default
            programmers.Insert(0, new Programmer("", "Select a programmer..."));
            mcus.Insert(0, new MCU("", "Select an MCU..."));

            // Set combo boxes

            cmbMCU.ValueMember = null;
            cmbMCU.DataSource = mcus;
            cmbMCU.DisplayMember = "fullName";

            cmbProg.ValueMember = null;
            cmbProg.DataSource = programmers;
            cmbProg.DisplayMember = "fullName";

            cmbFlashFormat.ValueMember = null;
            cmbFlashFormat.DataSource = new BindingSource(fileFormats, null);
            cmbFlashFormat.DisplayMember = "fullName";

            cmbEEPROMFormat.ValueMember = null;
            cmbEEPROMFormat.DataSource = new BindingSource(fileFormats, null);
            cmbEEPROMFormat.DisplayMember = "fullName";

            cmdVerbose.Items.Clear();
            for (byte i=0;i<5;i++)
                cmdVerbose.Items.Add(i);
            cmdVerbose.SelectedIndex = 0;

            // Load presets
            presets.load();
            presets.setDataSource(cmbPresets);

            // Tool tips
            ToolTip1.ReshowDelay = 100;
            ToolTip1.UseAnimation = false;
            ToolTip1.UseFading = false;
            ToolTip1.SetToolTip(cmbProg, "Programmer");
            ToolTip1.SetToolTip(cmbMCU, "MCU to program");
            ToolTip1.SetToolTip(cmbPort, "Set COM/LTP/USB port" + Environment.NewLine + "For LTP/USB ports you will have to type it in manually");
            ToolTip1.SetToolTip(txtBaudRate, "Port baud rate");
            ToolTip1.SetToolTip(txtBitClock, "Bit clock period (us)" + Environment.NewLine + "If you're having trouble programming with the USBasp try setting this to 32");
            ToolTip1.SetToolTip(txtFlashFile, "Hex file (.hex)" + Environment.NewLine + "You can also drag and drop files here");
            ToolTip1.SetToolTip(pFlashOp, "");
            ToolTip1.SetToolTip(txtEEPROMFile, "EEPROM file (.eep)" + Environment.NewLine + "You can also drag and drop files here");
            ToolTip1.SetToolTip(pEEPROMOp, "");
            ToolTip1.SetToolTip(cbForce, "Skip signature check");
            ToolTip1.SetToolTip(cbNoVerify, "Don't verify after writing");
            ToolTip1.SetToolTip(cbDisableFlashErase, "Don't erase flash before writing");
            ToolTip1.SetToolTip(cbEraseFlashEEPROM, "Erase both flash and EEPROM");
            ToolTip1.SetToolTip(cbDoNotWrite, "Don't write anything, used for debugging AVRDUDE");
            ToolTip1.SetToolTip(txtLFuse, "Low fuse");
            ToolTip1.SetToolTip(txtHFuse, "High fuse");
            ToolTip1.SetToolTip(txtEFuse, "Extended fuse");
            ToolTip1.SetToolTip(txtLock, "Lock bits");

            ready = true;

            updater = new UpdateCheck(this);
        }

        // Basic parsing of avrdude.conf to get programmers & MCUs
        private void loadConfig()
        {
            string conf_loc = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILE_AVRDUDECONF);

            if (!File.Exists(conf_loc))
            {
                MessageBox.Show(FILE_AVRDUDECONF + " is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] lines = File.ReadAllLines(conf_loc);
            for(int i=0;i<lines.Length;i++)
            {
                string s = lines[i].Trim();
                if ((s == "part" || s == "programmer") && lines.Length - i > 3)
                {
                    i++;
                    string[] idEntry = lines[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (idEntry.Length == 2)
                    {
                        string id = idEntry[1].Trim(new char[] { ' ', '"', ';' });

                        i++;
                        string[] descEntry = lines[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        if (descEntry.Length == 2)
                        {
                            string desc = descEntry[1].Trim(new char[] { ' ', '"', ';' });
                            if (s == "part")
                                mcus.Add(new MCU(id, desc));
                            else
                                programmers.Add(new Programmer(id, desc));
                        }
                    }
                }
            }
        }

        // Drag and drop
        private void event_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        // Drag and drop
        private void event_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if(((GroupBox)sender).Name == "gbFlashFile")
                txtFlashFile.Text = files[0];
            else
                txtEEPROMFile.Text = files[0];
        }

        // Port drop down, refresh available COM ports
        private void cbPort_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cmbPort.Items.Clear();
            foreach (string p in ports)
                cmbPort.Items.Add(p);
        }

        // General event for when a control changes
        private void event_generateCmdLine(object sender, EventArgs e)
        {
            cmdLine.generate();
        }

        // Enable/disable tooltips
        private void cbShowToolTips_CheckedChanged(object sender, EventArgs e)
        {
            ToolTip1.Active = cbShowToolTips.Checked;
        }

        // Flash & EEPROM operation radio buttons
        private void radioButton_flashEEPROMOp_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                string op;
                if (radioButton.Text == "Write")
                    op = "w";
                else if (radioButton.Text == "Read")
                    op = "r";
                else
                    op = "v";

                if (radioButton.Parent.Name == "pFlashOp")
                    flashOperation = op;
                else
                    EEPROMOperation = op;

                cmdLine.generate();
            }
        }

        // Open flash file
        private void btnFlashBrowse_Click(object sender, EventArgs e)
        {
           if(openFileDialog1.ShowDialog() == DialogResult.OK)
               txtFlashFile.Text = openFileDialog1.FileName;
        }

        // Open EEPROM file
        private void btnEEPROMBrowse_Click(object sender, EventArgs e)
        {
            if(openFileDialog2.ShowDialog() == DialogResult.OK)
                txtEEPROMFile.Text = openFileDialog2.FileName;
        }

        // Only allow digits and delete
        // This isn't perfect, but its close enough
        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = ((TextBox)sender);
            if (e.KeyChar != 8 && (Control.ModifierKeys & Keys.Control) != Keys.Control)
            {
                if (!Char.IsDigit(e.KeyChar) || (txtBox.SelectionLength == 0 && txtBox.Text.Length >= 10))
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                }
            }
        }

        // Only allow hex digits and delete
        // This isn't perfect, but its close enough
        private void txtHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = ((TextBox)sender);
            if (e.KeyChar != 8 && (Control.ModifierKeys & Keys.Control) != Keys.Control)
            {
                if ((!Char.IsDigit(e.KeyChar) && !"ABCDEFX".Contains(Char.ToUpper(e.KeyChar).ToString())) || (txtBox.SelectionLength == 0 && txtBox.Text.Length >= 4))
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                }
            }
        }

        // Form shown, show console form
        private void Form1_Shown(object sender, EventArgs e)
        {
            avrdude.showConsole();
            Focus();
        }

        // Program!
        private void btnProgram_Click(object sender, EventArgs e)
        {
            avrdude.launch(txtCmdLine.Text);
        }

        // Force stop
        private void btnForceStop_Click(object sender, EventArgs e)
        {
            avrdude.kill();
        }

        // Save a preset
        private void btnPresetSave_Click(object sender, EventArgs e)
        {
            savePreset.ShowDialog();

            // Update data source
            presets.setDataSource(cmbPresets, cbPresets_SelectedIndexChanged);
        }

        // Delete a preset
        private void btnPresetDelete_Click(object sender, EventArgs e)
        {
            deletePreset.ShowDialog();

            // Update data source
            presets.setDataSource(cmbPresets, cbPresets_SelectedIndexChanged);
        }

        // Preset choice changed
        private void cbPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                var item = (Preset)cmbPresets.SelectedItem;
                if (item != null)
                    item.load(this);
            }
        }

        // Fuse link clicked
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(WEB_ADDR_FUSE_SETTINGS);
        }

        // Read fuses
        private void btnReadFuses_Click(object sender, EventArgs e)
        {
            string[] fuseFiles = new string[3];
            for(byte i=0;i<fuseFiles.Length;i++)
                fuseFiles[i] = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Guid.NewGuid().ToString(), ".TMP"));

            string cmd = cmdLine.generateReadFuses(fuseFiles[0], fuseFiles[1], fuseFiles[2]);
            avrdude.launch(cmd, readFuseFiles, fuseFiles);
        }

        // Read and display file contents
        private void readFuseFiles(object param)
        {
            string[] fuseFiles = (string[])param;

            for (byte i = 0; i < fuseFiles.Length; i++)
            {
                if (File.Exists(fuseFiles[i]))
                {
                    string text = File.ReadAllText(fuseFiles[i]).Trim();
                    File.Delete(fuseFiles[i]);

                    // Get textbox to use
                    TextBox c;
                    if (i == 0)
                        c = txtLFuse;
                    else if (i == 1)
                        c = txtHFuse;
                    else
                        c = txtEFuse;

                    BeginInvoke(new MethodInvoker(() =>
                    {
                        c.Text = text;
                    }));
                }
            }
        }

        // Read lock byte
        private void btnReadLock_Click(object sender, EventArgs e)
        {
            string lockFile = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Guid.NewGuid().ToString(), ".TMP"));

            string cmd = cmdLine.generateReadLock(lockFile);
            avrdude.launch(cmd, readLockFile, lockFile);
        }

        // Read and display file contents
        private void readLockFile(object param)
        {
            string lockFile = (string)param;

            if (File.Exists(lockFile))
            {
                string text = File.ReadAllText(lockFile).Trim();
                File.Delete(lockFile);

                BeginInvoke(new MethodInvoker(() =>
                {
                    txtLock.Text = text;
                }));
            }
        }

        // About
        private void btnAbout_Click(object sender, EventArgs e)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Version version = assembly.GetName().Version;

            string about = "";
            about += "AVRDUDESS" + Environment.NewLine;
            about += "Version " + version.Major + "." + version.Minor + Environment.NewLine;
            about += "Copyright (c) 2013 Zak Kemble" + Environment.NewLine;
            about += Environment.NewLine;
            about += "zakkemble.co.uk";

            MessageBox.Show(about, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Update message box
        public void showUpdateMsg(string msg, string address)
        {
            Focus();
            FormUpdate f = new FormUpdate();
            f.setUpdateData(msg, address, updater);
            f.ShowDialog();
        }

        // Drag client area
        bool drag = false;
        Point dragStart;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            Point tmp = PointToScreen(new Point(0, 0));
            tmp = new Point(tmp.X - Location.X, tmp.Y - Location.Y);

            Point a = new Point(e.X, e.Y);
            if (sender is GroupBox)
            {
                a.X += ((GroupBox)sender).Location.X;
                a.Y += ((GroupBox)sender).Location.Y;
            }

            dragStart = new Point(a.X + tmp.X, a.Y + tmp.Y);
        }
        /*
        private void getAb(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is GroupBox)
                {

                    getAb(c.Controls);
                }
            }
        }
        */
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
                Location = new Point(Cursor.Position.X - dragStart.X, Cursor.Position.Y - dragStart.Y);
        }

        // CTRL + A to select all
        private void txtCmdLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                txtCmdLine.SelectAll();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
