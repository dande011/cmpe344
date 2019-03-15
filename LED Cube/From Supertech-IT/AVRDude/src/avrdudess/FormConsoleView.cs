/*
 * Project: AVRDUDESS - A GUI for AVRDUDE
 * Author: Zak Kemble, me@zakkemble.co.uk
 * Copyright: (C) 2013 by Zak Kemble
 * License: GNU GPL v3 (see License.txt)
 * Web: http://blog.zakkemble.co.uk/avrdudess-a-gui-for-avrdude/
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace avrdudess
{
    public partial class FormConsoleView : Form
    {
        public FormConsoleView()
        {
            InitializeComponent();

            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Text = "AVRDUDESS - Console";
        }

        // Add text
        public void add(string text)
        {
            txtConsole.AppendText(text);
        }

        // Minimize on close
        private void FormConsoleView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
        }

        // CTRL + A to select all
        private void txtConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                txtConsole.SelectAll();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        // Tool item select all
        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            txtConsole.SelectAll();
        }

        // Tool item copy
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            if(txtConsole.SelectionLength > 0)
                Clipboard.SetText(txtConsole.SelectedText);
        }

        // Tool item clear
        private void tsmiClear_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }
    }
}
