using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CorionisServiceManager.NET
{
    /// <summary>
    /// Log class.
    /// Handles logging to the Log tab and optional log file
    /// </summary>
    public class Log
    {
        private Config cfg;
        public String logBuffer { get; set; } = "";
        private TextBox parent;

        public Log(Config theCfg, TextBox theParent)
        {
            cfg = theCfg;
            parent = theParent;
        }

        public void Clear()
        {
            logBuffer = "";
            parent.Text = logBuffer;
        }

        public string GetLogFilename()
        {
            string file = Assembly.GetEntryAssembly().GetName().Name;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            // path = Path.Combine(path, file); // add directory
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, file); // add filename
            path = path + ".log";
            return path;
        }

        public void Save()
        {
            File.WriteAllText(GetLogFilename(), logBuffer);
        }

        public void Write(String line)
        {
            // keep the logBuffer from overflowing
            if (logBuffer.Length > 2145000000)
            {
                String replacement = logBuffer.Substring(1072500);
                logBuffer = String.Copy(replacement);
            }

            var entry = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + line + "\r\n";

            logBuffer += entry;
            parent.Text = logBuffer;

            if (cfg.LogToFile == true)
            {
                File.AppendAllText(GetLogFilename(), entry);
            }
        }
    }
}