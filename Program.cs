using System;
using System.Windows.Forms;
using CorionisServiceManager.NET.Properties;
using Tulpep.NotificationWindow;

namespace CorionisServiceManager.NET
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CsmContext());
        }
    }

    public class CsmContext : ApplicationContext
    {
        private Config cfg;
        private TheForm form;
        public NotifyIcon trayIcon;

        public CsmContext()
        {
            // Load the configuration from JSON file
            cfg = new Config();
            cfg.Load();

            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.manager_round_bronco,
                ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("&Show", Show),
                    new MenuItem("&Hide", Hide),
                    new MenuItem("-"),
                    new MenuItem("E&xit", Exit)
                }),
                Visible = true
            };

            // Setup the system tray icon
            trayIcon.DoubleClick += DoubleClick;
            trayIcon.Text = cfg.GetProgramTitle();

            // Display the app if configured
            if (cfg.StartMinimized == false)
            {
                Show();
            }
        }

        private void DoubleClick(object Sender, EventArgs e)
        {
            if (form == null || form.Visible == false || form.WindowState == FormWindowState.Minimized)
            {
                Show();
            }
            else
            {
                form.WindowState = FormWindowState.Minimized;
            }
        }

        public void Exit(object sender, EventArgs e)
        {
            // Save size and coordinates
            if (form != null && !form.IsDisposed)
            {
                form.SaveUserPreferences();
                form.Visible = false;
            }

            // Hide tray icon, otherwise it will remain until mouse over
            trayIcon.Visible = false;

            Application.Exit();
        }

        public void Hide(object sender, EventArgs e)
        {
            if (form != null && !form.IsDisposed && form.WindowState != FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Minimized;
            }
        }

        public void Popup(String title, String message)
        {
            if (cfg.DisplayNotifications)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = title;
                popup.ContentText = message;
                popup.Popup();
            }
        }

        public void Show()
        {
            if (form == null)
            {
                form = new TheForm(cfg, this);
            }
            form.ShowForm();
        }
        public void Show(object sender, EventArgs e)
        {
            Show();
        }

    }
}