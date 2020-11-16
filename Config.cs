using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace CorionisServiceManager.NET
{
    /// <summary>
    /// Config class.
    /// Holds configuration parameters. Is encoded in JSON to/from the .json file.
    /// </summary>
    public class Config
    {
        #region Constants

        public String Program { get; set; } = "Corionis Service Manager";
        public String Version { get; set; } = "";

        #endregion

        #region Options

        public String FriendlyName { get; set; }
        public bool StartAtLogin { get; set; }
        public bool StartMinimized { get; set; }
        public bool MinimizeOnClose { get; set; }
        public bool HideWhenMinimized { get; set; }
        public bool DisplayNotifications { get; set; }
        public bool DisplayMinimizedNotifications { get; set; }
        public bool ShowGridTooltips { get; set; }
        public bool LogToFile { get; set; }
        public String RunningFore { get; set; }
        public String RunningBack { get; set; }
        public String StoppedFore { get; set; }
        public String StoppedBack { get; set; }
        public String UnknownFore { get; set; }
        public String UnknownBack { get; set; }
        public String SelectFore { get; set; }
        public String SelectBack { get; set; }

        #endregion

        #region Coordinates

        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public bool IsMinified { get; set; }

        public ColumnOrderSize[] MonitorColumns { get; set; }

        public ColumnOrderSize[] SelectColumns { get; set; }

        #endregion

        #region Selected

        public ServiceIdNamePair[] SelectedServiceIds { get; set; }

        #endregion

        // Class for tracking column order and size
        public class ColumnOrderSize
        {
            public String Header { get; set; }
            public int Width { get; set; }
            public int Index { get; set; }
        }

        // Class for each service identifer/name pair where name is editable
        public class ServiceIdNamePair
        {
            public String Identifier { get; set; }
            public String Name { get; set; }
        }

        // Public constructor
        public Config()
        {
            Version = Assembly.GetEntryAssembly()?.GetName().Version.ToString();
            Version = Version.Substring(0, Version.Length - 4); // truncate trailing ".0.0"
        }

        public Color ColorFromHex(String hexColor)
        {
            Color color = System.Drawing.ColorTranslator.FromHtml(hexColor);
            return color;
        }

        public String ColorToHex(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public string GetConfigFilename()
        {
            string file = Assembly.GetEntryAssembly().GetName().Name;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, file); // add filename
            path = path + ".json";
            return path;
        }

        public String GetProgramTitle()
        {
            String result = "";
            if (FriendlyName.Length > 0)
            {
                result = FriendlyName + " : CSM";
            }
            else
            {
                result = Program + " " + Version;
            }

            return result;
        }

        public void Load()
        {
            bool found;
            try
            {
                string json = File.ReadAllText(GetConfigFilename());
                Config data = JsonConvert.DeserializeObject<Config>(json);

                FriendlyName = data.FriendlyName;
                StartAtLogin = data.StartAtLogin;
                StartMinimized = data.StartMinimized;
                MinimizeOnClose = data.MinimizeOnClose;
                HideWhenMinimized = data.HideWhenMinimized;
                DisplayNotifications = data.DisplayNotifications;
                DisplayMinimizedNotifications = data.DisplayMinimizedNotifications;
                ShowGridTooltips = data.ShowGridTooltips;
                LogToFile = data.LogToFile;
                RunningFore = data.RunningFore;
                RunningBack = data.RunningBack;
                StoppedFore = data.StoppedFore;
                StoppedBack = data.StoppedBack;
                UnknownFore = data.UnknownFore;
                UnknownBack = data.UnknownBack;
                SelectFore = data.SelectFore;
                SelectBack = data.SelectBack;
                Left = data.Left;
                Top = data.Top;
                Width = data.Width;
                Height = data.Height;
                IsMinified = data.IsMinified;
                MonitorColumns = data.MonitorColumns;
                SelectColumns = data.SelectColumns;
                SelectedServiceIds = data.SelectedServiceIds;

                found = true;
            }
            catch (DirectoryNotFoundException)
            {
                found = false;
            }
            catch (FileNotFoundException)
            {
                found = false;
            }

            if (!found)
            {
                SetConfigDefaults();
                SelectedServiceIds = new ServiceIdNamePair[] { };
            }
        }

        public void Save()
        {
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(GetConfigFilename(), text);
        }

        public void SetConfigDefaults()
        {
            FriendlyName = "";
            StartAtLogin = true;
            StartMinimized = false;
            MinimizeOnClose = true;
            HideWhenMinimized = true;
            DisplayNotifications = true;
            DisplayMinimizedNotifications = true;
            ShowGridTooltips = true;
            LogToFile = false;
            RunningFore = ColorToHex(Color.Black);
            RunningBack = ColorToHex(Color.LawnGreen);
            StoppedFore = ColorToHex(Color.Black);
            StoppedBack = ColorToHex(Color.Red);
            UnknownFore = ColorToHex(Color.Black);
            UnknownBack = ColorToHex(Color.Yellow);
            SelectFore = ColorToHex(Color.Black);
            SelectBack = "#B2C7FF"; // a personal favorite :)
            Left = 10;
            Top = 10;
            Width = 600;
            Height = 440;
            IsMinified = false;
            // use default order and size
            // don't replace selected services
        }
    }
}