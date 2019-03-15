/*
 * Project: AVRDUDESS - A GUI for AVRDUDE
 * Author: Zak Kemble, me@zakkemble.co.uk
 * Copyright: (C) 2013 by Zak Kemble
 * License: GNU GPL v3 (see License.txt)
 * Web: http://blog.zakkemble.co.uk/avrdudess-a-gui-for-avrdude/
 */

using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace avrdudess
{
    public class UpdateCheck
    {
        private const string UPDATE_ADDR = "http://versions.zakkemble.co.uk/avrdudess.xml";
        private const string FILE_LAST_CHECK = "lastupdatecheck";

        private Form1 mainForm;
        private string lastCheck_loc;
        private long now;

        public UpdateCheck(Form1 mainForm)
        {
            this.mainForm = mainForm;
            lastCheck_loc = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILE_LAST_CHECK);
            now = (long)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);

            // Check once a day
            try
            {
                if (!File.Exists(lastCheck_loc))
                    checkNow();
                else
                {
                    long lastUpdate;
                    if (!long.TryParse(File.ReadAllText(lastCheck_loc), out lastUpdate))
                        lastUpdate = 0;

                    if (now - lastUpdate > 86400)
                        checkNow();
                }
            }
            catch (Exception)
            {

            }
        }

        private void checkNow()
        {
            Thread t = new Thread(new ThreadStart(tUpdate));
            t.IsBackground = true;
            t.Start();
        }

        public void disable()
        {
            saveTime(long.MaxValue);
        }

        private void saveTime(long time)
        {
            try
            {
                File.WriteAllText(lastCheck_loc, time.ToString());
            }
            catch (Exception)
            {

            }
        }

        private void tUpdate()
        {
            Thread.Sleep(500);

            try
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                Version currentVersion = new Version(version.Major, version.Minor);

                int major = 0;
                int minor = 0;
                long date = 0;
                string updateAddr = "";
                //string updateInfo = "";

                var request         = (HttpWebRequest)WebRequest.Create(UPDATE_ADDR);
                request.UserAgent = "Mozilla/5.0 (compatible; AVRDUDESS VERSION CHECKER " + version.Major + "." + version.Minor + ")";
                request.ReadWriteTimeout = 30000;
                request.Timeout = 30000;
                request.KeepAlive = false;
                //request.Proxy = null;
                var responseStream  = request.GetResponse().GetResponseStream();
                var reader          = XmlReader.Create(responseStream);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "major")
                        {
                            reader.Read();
                            major = reader.ReadContentAsInt();
                        }
                        else if (reader.Name == "minor")
                        {
                            reader.Read();
                            minor = reader.ReadContentAsInt();
                        }
                        else if (reader.Name == "date")
                        {
                            reader.Read();
                            date = reader.ReadContentAsLong();
                        }
                        else if (reader.Name == "updateAddr")
                        {
                            reader.Read();
                            updateAddr = reader.ReadContentAsString();
                        }
                        /*else if (reader.Name == "updateInfo")
                        {
                            reader.Read();
                            updateInfo = reader.ReadContentAsString();
                        }*/
                    }
                }

                reader.Close();
                responseStream.Close();

                Version newVersion = new Version(major, minor);

                // Notify of new update
                if (currentVersion.CompareTo(newVersion) < 0)
                {
                    string msg = "Update available" + Environment.NewLine + Environment.NewLine +
                        "Current version: " + currentVersion.Major + "." + currentVersion.Minor + Environment.NewLine +
                        "New version: " + newVersion.Major + "." + newVersion.Minor + " (" + new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(date).ToLocalTime().ToShortDateString() + ")";

                    mainForm.BeginInvoke(new MethodInvoker(() =>
                    {
                        mainForm.showUpdateMsg(msg, updateAddr);
                    }));
                }

                saveTime(now);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
