/*
 * Project: AVRDUDESS - A GUI for AVRDUDE
 * Author: Zak Kemble, me@zakkemble.co.uk
 * Copyright: (C) 2013 by Zak Kemble
 * License: GNU GPL v3 (see License.txt)
 * Web: http://blog.zakkemble.co.uk/avrdudess-a-gui-for-avrdude/
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace avrdudess
{
    class Avrdude
    {
        private const string FILE_AVRDUDE = "avrdude";

        private Form1 mainForm;
        private Process p;
        private FormConsoleView consoleView = new FormConsoleView();
        private Action<object> onFinish;
        private object param;
        private string avrdudeBinary;

        public Avrdude(Form1 mainForm)
        {
            if (!searchForAVRDUDE())
                MessageBox.Show(FILE_AVRDUDE + " is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.mainForm = mainForm;

            Thread t = new Thread(new ThreadStart(tConsoleUpdate));
            t.IsBackground = true;
            t.Start();
        }

        private bool searchForAVRDUDE()
        {
            char pathSplit;
            string binaryName = FILE_AVRDUDE;

            // Get char that is used to split PATH entries
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                case PlatformID.MacOSX:
                    pathSplit = ':';
                    break;
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                case PlatformID.Xbox:
                    pathSplit = ';';
                    binaryName += ".exe";
                    break;
                default:
                    pathSplit = ';';
                    break;
            }

            // File exists in application directory (mainly for Windows)
            string app = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, binaryName);
            if (File.Exists(app))
            {
                avrdudeBinary = app;
                return true;
            }

            // Search PATHs
            var paths = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in paths.Split(new char[] {pathSplit}, StringSplitOptions.RemoveEmptyEntries))
            {
                var fullPath = Path.Combine(path, binaryName);
                if (File.Exists(fullPath))
                {
                    avrdudeBinary = fullPath;
                    return true;
                }
            }

            return false;
        }

        public void showConsole()
        {
            consoleView.Show();
            consoleView.Location = new Point(mainForm.Location.X + mainForm.Size.Width, mainForm.Location.Y);
        }

        public void launch(string arg, Action<object> onFinish, object param)
        {
            this.onFinish = onFinish;
            this.param = param;
            launch(arg);
        }

        public void launch(string args)
        {
            if (p != null && !p.HasExited) // Another process is active
                return;
            else if (!File.Exists(avrdudeBinary)) // avrdude is missing
            {
                consoleView.add(FILE_AVRDUDE + " is missing!" + Environment.NewLine);
                return;
            }

            if (args.Trim().Length > 0)
                args = "-u " + args;

            consoleView.add("~~~~~~~~~~~~~~~~~~" + Environment.NewLine);
            Process tmp = new Process();
            tmp.StartInfo.FileName = avrdudeBinary;
            tmp.StartInfo.Arguments = args;
            tmp.StartInfo.CreateNoWindow = true;
            tmp.StartInfo.UseShellExecute = false;
            tmp.StartInfo.RedirectStandardOutput = true;
            tmp.StartInfo.RedirectStandardError = true;
            tmp.EnableRaisingEvents = true;
            //tmp.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            //tmp.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            tmp.Exited += new EventHandler(p_Exited);
            mainForm.avrdudeStatus = "AVRDUDE is running...";
            tmp.Start();
            p = tmp;
            //p.BeginOutputReadLine();
            //p.BeginErrorReadLine();
        }

        private void tConsoleUpdate()
        {
            while (true)
            {
                Thread.Sleep(25);
                try
                {
                    if (p != null)
                    {
                        char[] buff = new char[256];
                        if (p.StandardError.Read(buff, 0, buff.Length) > 0)
                        {
                            string s = new string(buff);
                            consoleView.BeginInvoke(new MethodInvoker(() =>
                            {
                                consoleView.add(s);
                            }));
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void p_Exited(object sender, EventArgs e)
        {
            mainForm.avrdudeStatus = "Ready";
            if (onFinish != null)
                onFinish(param);
            onFinish = null;
        }
        /*
        // Progress bars don't work using async output, since it only fires when a new line is received
        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            consoleView.BeginInvoke(new MethodInvoker(() =>
            {
                consoleView.add(e.Data ?? string.Empty);
            }));
        }
        */
        public void kill()
        {
            if (p != null && !p.HasExited)
            {
                p.Kill();
                consoleView.add(Environment.NewLine + "AVRDUDE killed" + Environment.NewLine);
            }
        }

        public void waitForExit()
        {
            if (p != null && !p.HasExited)
                p.WaitForExit();
        }
    }
}
