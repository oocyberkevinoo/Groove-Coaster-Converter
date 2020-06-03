namespace Groove_Coaster_Converter
{
    partial class Form_About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_About));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.link_Twitter = new System.Windows.Forms.LinkLabel();
            this.link_Github = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(74, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Groove Coaster Converter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(102, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 100);
            this.label2.TabIndex = 0;
            this.label2.Text = "by Cyberkevin\r\nVersion Alpha 0.2.3\r\n\r\nThis software is still in Alpha.\r\nPlease re" +
    "port any issue.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // link_Twitter
            // 
            this.link_Twitter.AutoSize = true;
            this.link_Twitter.LinkArea = new System.Windows.Forms.LinkArea(0, 7);
            this.link_Twitter.Location = new System.Drawing.Point(361, 202);
            this.link_Twitter.Name = "link_Twitter";
            this.link_Twitter.Size = new System.Drawing.Size(39, 13);
            this.link_Twitter.TabIndex = 1;
            this.link_Twitter.TabStop = true;
            this.link_Twitter.Text = "Twitter";
            this.link_Twitter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Twitter_LinkClicked);
            // 
            // link_Github
            // 
            this.link_Github.AutoSize = true;
            this.link_Github.LinkArea = new System.Windows.Forms.LinkArea(0, 7);
            this.link_Github.Location = new System.Drawing.Point(361, 180);
            this.link_Github.Name = "link_Github";
            this.link_Github.Size = new System.Drawing.Size(39, 17);
            this.link_Github.TabIndex = 1;
            this.link_Github.TabStop = true;
            this.link_Github.Text = "GitHub";
            this.link_Github.UseCompatibleTextRendering = true;
            this.link_Github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Github_LinkClicked);
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(412, 223);
            this.Controls.Add(this.link_Github);
            this.Controls.Add(this.link_Twitter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Shown += new System.EventHandler(this.Form_About_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel link_Twitter;
        private System.Windows.Forms.LinkLabel link_Github;
    }
}