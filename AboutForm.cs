using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CorionisServiceManager.NET
{
    public partial class AboutForm : Form
    {
        private Form myParent;

        public AboutForm(Form theParent, Config theCfg)
        {
            InitializeComponent();

            myParent = theParent;

            aboutVersion.Text = "Version: " + theCfg.Version;

            linkLabelDocumentation.Click += EventLinkLabelDocumentation;
            linkLabelProject.Click += EventLinkLabelProject;

            okButton.Click += EventOkButton;
            okButton.KeyPress += EventKeyPress;

            AcceptButton = okButton;
            CancelButton = okButton;
            KeyDown += EventKeyDown;
            KeyPress += EventKeyPress;

            Show();
            okButton.Focus();
        }

        private void EventKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
                okButton.PerformClick();
        }

        private void EventKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
                okButton.PerformClick();
        }

        private void EventLinkLabelDocumentation(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Corionis/CorionisServiceManager.NET/wiki");
        }

        private void EventLinkLabelProject(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Corionis/CorionisServiceManager.NET");
        }

        private void EventOkButton(object sender, EventArgs e)
        {
            Close();
            myParent.Focus();
        }
    }
}
