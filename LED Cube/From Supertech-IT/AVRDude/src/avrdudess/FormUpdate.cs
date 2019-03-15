/*
 * Project: AVRDUDESS - A GUI for AVRDUDE
 * Author: Zak Kemble, me@zakkemble.co.uk
 * Copyright: (C) 2013 by Zak Kemble
 * License: GNU GPL v3 (see License.txt)
 * Web: http://blog.zakkemble.co.uk/avrdudess-a-gui-for-avrdude/
 */

using System;
using System.IO;
using System.Windows.Forms;

namespace avrdudess
{
    public partial class FormUpdate : Form
    {
        private string address;
        private UpdateCheck updater;

        public FormUpdate()
        {
            InitializeComponent();

            Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Text = "Update available";
        }

        public void setUpdateData(string msg, string address, UpdateCheck updater)
        {
            lblInfo.Text = msg;
            this.address = address;
            this.updater = updater;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dontAskAgain();
            System.Diagnostics.Process.Start(address);
            Close();
        }

        private void btnLater_Click(object sender, EventArgs e)
        {
            dontAskAgain();
            Close();
        }

        private void dontAskAgain()
        {
            if (cbDontAskAgain.Checked)
                updater.disable();
        }
    }
}
