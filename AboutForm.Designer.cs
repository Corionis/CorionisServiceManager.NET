using System.ComponentModel;

namespace CorionisServiceManager.NET
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aboutVersion = new System.Windows.Forms.Label();
            this.linkLabelProject = new System.Windows.Forms.LinkLabel();
            this.okButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabelPublic = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 60);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // aboutVersion
            // 
            this.aboutVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.aboutVersion.Location = new System.Drawing.Point(107, 76);
            this.aboutVersion.Name = "aboutVersion";
            this.aboutVersion.Size = new System.Drawing.Size(165, 23);
            this.aboutVersion.TabIndex = 1;
            this.aboutVersion.Text = "-version goes here-";
            this.aboutVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelProject
            // 
            this.linkLabelProject.Location = new System.Drawing.Point(87, 136);
            this.linkLabelProject.Name = "linkLabelProject";
            this.linkLabelProject.Size = new System.Drawing.Size(292, 23);
            this.linkLabelProject.TabIndex = 2;
            this.linkLabelProject.TabStop = true;
            this.linkLabelProject.Text = "https://github.com/Corionis/CorionisServiceManager.NET";
            this.linkLabelProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.okButton.Location = new System.Drawing.Point(325, 177);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(62, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "&Ok";
            this.okButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "GitHub Project:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "By Todd R. Hill, Corionis, LLC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Public site:";
            // 
            // linkLabelPublic
            // 
            this.linkLabelPublic.AutoSize = true;
            this.linkLabelPublic.Location = new System.Drawing.Point(87, 114);
            this.linkLabelPublic.Name = "linkLabelPublic";
            this.linkLabelPublic.Size = new System.Drawing.Size(272, 13);
            this.linkLabelPublic.TabIndex = 9;
            this.linkLabelPublic.TabStop = true;
            this.linkLabelPublic.Text = "https://corionis.github.io/CorionisServiceManager.NET/";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(399, 212);
            this.Controls.Add(this.linkLabelPublic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.linkLabelProject);
            this.Controls.Add(this.aboutVersion);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelProject;

        private System.Windows.Forms.Button okButton;

        private System.Windows.Forms.Label aboutVersion;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabelPublic;
    }
}