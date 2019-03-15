/*
 * Project: AVRDUDESS - A GUI for AVRDUDE
 * Author: Zak Kemble, me@zakkemble.co.uk
 * Copyright: (C) 2013 by Zak Kemble
 * License: GNU GPL v3 (see License.txt)
 * Web: http://blog.zakkemble.co.uk/avrdudess-a-gui-for-avrdude/
 */

using System;
using System.Text;

namespace avrdudess
{
    class CmdLine
    {
        private Form1 mainForm;
        private StringBuilder sb = new StringBuilder();

        public CmdLine(Form1 mainForm)
        {
            this.mainForm = mainForm;
        }

        private void generateMain()
        {
            //sb.Clear(); // .NET 4.0+ only
            sb.Length = 0;
            sb.Capacity = 0;

            if (mainForm.prog.Length > 0)
                cmdLineOption("c", mainForm.prog);

            if (mainForm.mcu.Length > 0)
                cmdLineOption("p", mainForm.mcu);

            if (mainForm.port.Length > 0)
                cmdLineOption("P", mainForm.port);

            if (mainForm.baudRate.Length > 0)
                cmdLineOption("b", mainForm.baudRate);

            if (mainForm.bitClock.Length > 0)
                cmdLineOption("B", mainForm.bitClock);

            if (mainForm.force)
                cmdLineOption("F");

            byte verbose = mainForm.verbosity;
            for(byte i=0;i<verbose;i++)
                cmdLineOption("v");
        }

        public string generateReadFuses(string lfuseFile, string hfuseFile, string efuseFile)
        {
            generateMain();

            cmdLineOption("U", "lfuse:r:\"" + lfuseFile + "\":h");
            cmdLineOption("U", "hfuse:r:\"" + hfuseFile + "\":h");
            cmdLineOption("U", "efuse:r:\"" + efuseFile + "\":h");

            return sb.ToString();
        }

        public string generateReadLock(string lockFile)
        {
            generateMain();

            cmdLineOption("U", "lock:r:\"" + lockFile + "\":h");

            return sb.ToString();
        }

        public void generate()
        {
            if (!mainForm.ready)
                return;

            generateMain();

            if (mainForm.disableVerify)
                cmdLineOption("V");

            if (mainForm.disableFlashErase)
                cmdLineOption("D");

            if (mainForm.eraseFlashAndEEPROM)
                cmdLineOption("e");

            if (mainForm.doNotWrite)
                cmdLineOption("n");

            if(mainForm.additionalSettings.Length > 0)
                sb.Append(mainForm.additionalSettings + " ");

            if (mainForm.flashFile.Length > 0)
                cmdLineOption("U", "flash:" + mainForm.flashFileOperation + ":\"" + mainForm.flashFile + "\":" + mainForm.flashFileFormat);

            if (mainForm.EEPROMFile.Length > 0)
                cmdLineOption("U", "eeprom:" + mainForm.EEPROMFileOperation + ":\"" + mainForm.EEPROMFile + "\":" + mainForm.EEPROMFileFormat);

            if (mainForm.setFuses)
            {
                if (mainForm.lowFuse.Length > 0)
                    cmdLineOption("U", "lfuse:w:" + mainForm.lowFuse + ":m");

                if (mainForm.highFuse.Length > 0)
                    cmdLineOption("U", "hfuse:w:" + mainForm.highFuse + ":m");

                if (mainForm.exFuse.Length > 0)
                    cmdLineOption("U", "efuse:w:" + mainForm.exFuse + ":m");
            }

            if(mainForm.setLock && mainForm.lockSetting.Length > 0)
                cmdLineOption("U", "lock:w:" + mainForm.lockSetting + ":m");

            mainForm.cmdBox = sb.ToString();
        }

        private void cmdLineOption(string arg, string val)
        {
            sb.Append("-" + arg + " " + val + " ");
        }

        private void cmdLineOption(string arg)
        {
            sb.Append("-" + arg + " ");
        }
    }
}
