using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace CSM
{
    public class Config
    {
        #region Constants
        public String Program { get; set; } = "Corionis Service Manager";
        public String Version { get; set; } = "2020.1";
        #endregion

        #region Options
        public String FriendlyName { get; set; }
        public bool StartAtLogin { get; set; }
        public bool StartMinimized { get; set; }
        public bool MinimizeOnClose { get; set; }
        public bool HideWhenMinimized { get; set; }
        public bool DisplayNotifications { get; set; }
        public bool DisplayMinimizedNotifications { get; set; }
        #endregion

        #region Coordinates
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion

        #region Selected
        public ServiceIdNamePair[] SelectedServiceIds { get; set; }
        #endregion

        // Class for each service identifer/name pair where name is editable
        public class ServiceIdNamePair
        {
            public String Identifier { get; set; }
            public String Name { get; set; }
        }

        // Public constructor
        public Config()
        {
        }

        private string GetConfigFilename()
        {
            string path = Assembly.GetEntryAssembly().Location;
            path = path.Replace(".exe", ".json");
            return path;
        }

        public void Load()
        {
            try
            {
                string json = File.ReadAllText(GetConfigFilename());
                Config data = JsonConvert.DeserializeObject<Config>(json);

                this.DisplayNotifications = data.DisplayNotifications;
                this.FriendlyName = data.FriendlyName;
                this.MinimizeOnClose = data.MinimizeOnClose;
                this.StartAtLogin = data.StartAtLogin;
                this.StartMinimized = data.StartMinimized;
                this.HideWhenMinimized = data.HideWhenMinimized;
                this.DisplayMinimizedNotifications = data.DisplayMinimizedNotifications;
                this.Left = data.Left;
                this.Top = data.Top;
                this.Width = data.Width;
                this.Height = data.Height;
                this.SelectedServiceIds = data.SelectedServiceIds;
            }
            catch (FileNotFoundException )
            {
                this.DisplayNotifications = true;
                this.DisplayMinimizedNotifications = true;
                this.FriendlyName = "A friendly name";
                this.MinimizeOnClose = true;
                this.StartAtLogin = false;
                this.StartMinimized = false;
                this.HideWhenMinimized = true;
                this.Left = 100;
                this.Top = 100;
                this.Width = 820;
                this.Height = 490;
                this.SelectedServiceIds = new ServiceIdNamePair[] {};
            }
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

        public void Save()
        {
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(GetConfigFilename(), text);
        }

    }
}
