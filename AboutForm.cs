using System;
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

            AcceptButton = okButton;
            CancelButton = okButton;
            KeyPress += EventKeyDown;

            okButton.Focus();
            okButton.Click += EventOkButton;
            okButton.KeyPress += EventKeyDown;


            Show();
        }

        private void EventKeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Keys.Enter) || e.KeyChar == 32)
                okButton.PerformClick();
        }

        private void EventOkButton(object sender, EventArgs e)
        {
            Close();
            myParent.Focus();
        }
    }
}
