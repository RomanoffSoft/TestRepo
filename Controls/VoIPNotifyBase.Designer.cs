namespace Technology.VoIP
{
    partial class VoIPNotifyBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.externButton = new Technology.VoIP.CustomSimpleButton();
            this.SuspendLayout();
            // 
            // externButton
            // 
            this.externButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.externButton.Image = global::Technology.VoIP.Properties.Resources.telephone5_24;
            this.externButton.Location = new System.Drawing.Point(0, 0);
            this.externButton.Name = "externButton";
            this.externButton.Size = new System.Drawing.Size(30, 140);
            this.externButton.TabIndex = 0;
            this.externButton.Click += new System.EventHandler(this.externButton_Click);
            // 
            // VoIPNotifyBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.externButton);
            this.Name = "VoIPNotifyBase";
            this.Size = new System.Drawing.Size(292, 197);
            this.ResumeLayout(false);

        }

        private CustomSimpleButton externButton;
        #endregion
    }
}
