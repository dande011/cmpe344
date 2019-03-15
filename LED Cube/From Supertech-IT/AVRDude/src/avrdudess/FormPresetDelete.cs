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
    public partial class FormPresetDelete : Form
    {
        private Form1 mainForm;

        public FormPresetDelete(Form1 mainForm)
        {
            InitializeComponent();

            Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Text = "Delete preset";

            this.mainForm = mainForm;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mainForm.presets.remove((Preset)cmbPresets.SelectedItem);
            mainForm.presets.save();
            Close();
        }

        private void FormPresetDelete_Shown(object sender, EventArgs e)
        {
            mainForm.presets.setDataSource(cmbPresets);
        }
    }
}
