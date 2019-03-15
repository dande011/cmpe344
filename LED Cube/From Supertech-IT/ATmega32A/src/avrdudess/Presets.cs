﻿/*
 * Project: AVRDUDESS - A GUI for AVRDUDE
 * Author: Zak Kemble, me@zakkemble.co.uk
 * Copyright: (C) 2013 by Zak Kemble
 * License: GNU GPL v3 (see License.txt)
 * Web: http://blog.zakkemble.co.uk/avrdudess-a-gui-for-avrdude/
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace avrdudess
{
    public class Presets
    {
        private const string FILE_PRESETS = "presets.xml";

        private Form1 mainForm;
        public List<Preset> presets = new List<Preset>();
        private string presets_loc;

        public Presets(Form1 mainForm)
        {
            this.mainForm = mainForm;
            presets_loc = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILE_PRESETS);
        }

        public void setDataSource(ComboBox cb, EventHandler handler)
        {
            cb.SelectedIndexChanged -= handler;
            setDataSource(cb);
            cb.SelectedIndexChanged += handler;
        }

        public void setDataSource(ComboBox cb)
        {
            cb.DataSource = null;
            cb.ValueMember = null;
            cb.DataSource = presets;
            cb.DisplayMember = "name";
        }

        // New preset
        public void add(string name)
        {
            presets.Add(new Preset(mainForm, name));
        }

        // Delete preset
        public void remove(Preset preset)
        {
            presets.Remove(preset);
        }

        // Save presets
        public void save()
        {
            TextWriter tw = null;
            try
            {
                tw = new StreamWriter(presets_loc);
                new XmlSerializer(typeof(List<Preset>)).Serialize(tw, presets);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occored trying to save presets" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tw != null)
                tw.Close();
        }

        // Load presets
        public void load()
        {
            TextReader tr = null;
            try
            {
                // If presets file doesn't exist, make it and add default preset
                if (!File.Exists(presets_loc))
                {
                    File.Create(presets_loc).Close();
                    add("Default");
                    save();
                }

                tr = new StreamReader(presets_loc);
                presets = (List<Preset>)(new XmlSerializer(typeof(List<Preset>)).Deserialize(tr));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occored trying to load presets" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (tr != null)
                tr.Close();
        }
    }

    [Serializable]
    public class Preset
    {
        public string name { get; set; }

        public string programmer;
        public string mcu;
        public string port;
        public string baud;
        public string bitclock;
        public string flashFile;
        public string flashFormat;
        public string flashOp;
        public string EEPROMFile;
        public string EEPROMFormat;
        public string EEPROMOp;
        public bool force;
        public bool disableVerify;
        public bool disableFlashErase;
        public bool eraseFlashAndEEPROM;
        public bool doNotWrite;
        public string lfuse;
        public string hfuse;
        public string efuse;
        public bool setFuses;
        public string lockBits;
        public bool setLock;
        public string additional;
        public byte verbosity;

        public Preset()
        {
        }

        public Preset(Form1 mainForm, string name)
        {
            this.name = name;

            programmer = mainForm.prog;
            mcu = mainForm.mcu;
            port = mainForm.port;
            baud = mainForm.baudRate;
            bitclock = mainForm.bitClock;
            flashFile = mainForm.flashFile;
            flashFormat = mainForm.flashFileFormat;
            flashOp = mainForm.flashFileOperation;
            EEPROMFile = mainForm.EEPROMFile;
            EEPROMFormat = mainForm.EEPROMFileFormat;
            EEPROMOp = mainForm.EEPROMFileOperation;
            force = mainForm.force;
            disableVerify = mainForm.disableVerify;
            disableFlashErase = mainForm.disableFlashErase;
            eraseFlashAndEEPROM = mainForm.eraseFlashAndEEPROM;
            doNotWrite = mainForm.doNotWrite;
            lfuse = mainForm.lowFuse;
            hfuse = mainForm.highFuse;
            efuse = mainForm.exFuse;
            setFuses = mainForm.setFuses;
            lockBits = mainForm.lockSetting;
            setLock = mainForm.setLock;
            additional = mainForm.additionalSettings;
            verbosity = mainForm.verbosity;
        }

        public void load(Form1 mainForm)
        {
            mainForm.prog = programmer;
            mainForm.mcu = mcu;
            mainForm.port = port;
            mainForm.baudRate = baud;
            mainForm.bitClock = bitclock;
            mainForm.flashFile = flashFile;
            mainForm.flashFileFormat = flashFormat;
            mainForm.flashFileOperation = flashOp;
            mainForm.EEPROMFile = EEPROMFile;
            mainForm.EEPROMFileFormat = EEPROMFormat;
            mainForm.EEPROMFileOperation = EEPROMOp;
            mainForm.force = force;
            mainForm.disableVerify = disableVerify;
            mainForm.disableFlashErase = disableFlashErase;
            mainForm.eraseFlashAndEEPROM = eraseFlashAndEEPROM;
            mainForm.doNotWrite = doNotWrite;
            mainForm.lowFuse = lfuse;
            mainForm.highFuse = hfuse;
            mainForm.exFuse = efuse;
            mainForm.setFuses = setFuses;
            mainForm.lockSetting = lockBits;
            mainForm.setLock = setLock;
            mainForm.additionalSettings = additional;
            mainForm.verbosity = verbosity;
        }
    }
}
