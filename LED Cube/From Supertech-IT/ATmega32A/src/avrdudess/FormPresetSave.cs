/*
 * Project: AVRDUDESS - A GUI for AVRDUDE
 * Author: Zak Kemble, me@zakkemble.co.uk
 * Copyright: (C) 2013 by Zak Kemble
 * License: GNU GPL v3 (see License.txt)
 * Web: http://blog.zakkemble.co.uk/avrdudess-a-gui-for-avrdude/
 */

using System;
using System.Windows.Forms;

namespace avrdudess
{
    public partial class FormPresetSave : Form
    {
        private Form1 mainForm;

        public FormPresetSave(Form1 mainForm)
        {
            InitializeComponent();

            Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Text = "Save preset";

            this.mainForm = mainForm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPreset.Text.Length < 1)
                return;
            mainForm.presets.add(txtPreset.Text);
            mainForm.presets.save();
            Close();
        }

        private void FormPresetSave_Shown(object sender, EventArgs e)
        {
            txtPreset.Text = "";
        }
    }
}
