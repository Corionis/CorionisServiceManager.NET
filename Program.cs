using System;
using System.Windows.Forms;
using CorionisServiceManager.NET.Properties;
using Microsoft.Win32;
using Tulpep.NotificationWindow;

namespace CorionisServiceManager.NET
{
    /// <summary>
    /// Corionis Service Manager.
    /// Monitor and manage selected Windows services.
    /// </summary>
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
        private ProgramForm form;
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
                    new MenuItem(cfg.GetProgramTitle()), // faux title
                    new MenuItem("-"),
                    new MenuItem("&Show", Show),
                    new MenuItem("&Hide", Hide),
                    new MenuItem("-"),
                    new MenuItem("E&xit", Exit)
                }),
                Visible = true
            };

            // Setup the system tray icon
            trayIcon.Text = cfg.GetProgramTitle();
            trayIcon.DoubleClick += DoubleClick;
            trayIcon.ContextMenu.MenuItems[0].Enabled = false; // disable content menu faux title

            // Display the app if configured
            if (cfg.StartMinimized == false)
            {
                Show(null, null);
            }
        }

        private void DoubleClick(object Sender, EventArgs e)
        {
            if (form == null || form.Visible == false || form.WindowState == FormWindowState.Minimized)
            {
                Show(null, null);
            }
            else
            {
                form.WindowState = FormWindowState.Minimized;
            }
        }

        public void Exit(object sender, EventArgs e)
        {
            form.logger.Write("Exit");

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
                popup.BodyColor = cfg.ColorFromHex("#ffb44a");
                popup.ShowCloseButton = true;
                popup.Popup();
            }
        }

        public void Show(object sender, EventArgs e)
        {
            if (form == null)
            {
                form = new ProgramForm(cfg, this);
            }

            form.ShowForm();
        }
    }
}