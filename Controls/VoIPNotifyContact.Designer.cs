namespace Technology.VoIP {
    partial class VoIPNotifyContact
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
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lLastName = new System.Windows.Forms.Label();
            this.lFirstName = new System.Windows.Forms.Label();
            this.lPatronymic = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClientDetails = new DevExpress.XtraEditors.SimpleButton();
            this.btnTransferCall = new DevExpress.XtraEditors.SimpleButton();
            this.btn_minimize = new DevExpress.XtraEditors.SimpleButton();
            this.groupNumber = new System.Windows.Forms.GroupBox();
            this.lPhone = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lLastName);
            this.groupBox4.Controls.Add(this.lFirstName);
            this.groupBox4.Controls.Add(this.lPatronymic);
            this.groupBox4.Location = new System.Drawing.Point(140, 58);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 107);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            // 
            // lLastName
            // 
            this.lLastName.AutoSize = true;
            this.lLastName.BackColor = System.Drawing.Color.Transparent;
            this.lLastName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLastName.Location = new System.Drawing.Point(23, 20);
            this.lLastName.Name = "lLastName";
            this.lLastName.Size = new System.Drawing.Size(68, 16);
            this.lLastName.TabIndex = 5;
            this.lLastName.Text = "Фамилия";
            // 
            // lFirstName
            // 
            this.lFirstName.AutoSize = true;
            this.lFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lFirstName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lFirstName.Location = new System.Drawing.Point(23, 46);
            this.lFirstName.Name = "lFirstName";
            this.lFirstName.Size = new System.Drawing.Size(34, 16);
            this.lFirstName.TabIndex = 6;
            this.lFirstName.Text = "Имя";
            // 
            // lPatronymic
            // 
            this.lPatronymic.AutoSize = true;
            this.lPatronymic.BackColor = System.Drawing.Color.Transparent;
            this.lPatronymic.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPatronymic.Location = new System.Drawing.Point(23, 71);
            this.lPatronymic.Name = "lPatronymic";
            this.lPatronymic.Size = new System.Drawing.Size(70, 16);
            this.lPatronymic.TabIndex = 7;
            this.lPatronymic.Text = "Отчество";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClientDetails);
            this.groupBox2.Controls.Add(this.btnTransferCall);
            this.groupBox2.Controls.Add(this.btn_minimize);
            this.groupBox2.Location = new System.Drawing.Point(35, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(99, 107);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // btnClientDetails
            // 
            this.btnClientDetails.Image = global::Technology.VoIP.Properties.Resources.clientProfile;
            this.btnClientDetails.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClientDetails.Location = new System.Drawing.Point(6, 65);
            this.btnClientDetails.Name = "btnClientDetails";
            this.btnClientDetails.Size = new System.Drawing.Size(83, 35);
            toolTipItem4.Text = "Перейти к клиенту";
            superToolTip4.Items.Add(toolTipItem4);
            this.btnClientDetails.SuperTip = superToolTip4;
            this.btnClientDetails.TabIndex = 9;
            this.btnClientDetails.Tag = "ShowClient";
            this.btnClientDetails.Click += new System.EventHandler(this.btnClientDetails_Click);
            // 
            // btnTransferCall
            // 
            this.btnTransferCall.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTransferCall.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTransferCall.Location = new System.Drawing.Point(6, 110);
            this.btnTransferCall.Name = "btnTransferCall";
            this.btnTransferCall.Size = new System.Drawing.Size(83, 35);
            toolTipItem5.Text = "Переадресация";
            superToolTip5.Items.Add(toolTipItem5);
            this.btnTransferCall.SuperTip = superToolTip5;
            this.btnTransferCall.TabIndex = 8;
            this.btnTransferCall.Visible = false;
            // 
            // btn_minimize
            // 
            this.btn_minimize.Location = new System.Drawing.Point(6, 20);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(82, 35);
            toolTipItem6.Text = "Свернуть";
            superToolTip6.Items.Add(toolTipItem6);
            this.btn_minimize.SuperTip = superToolTip6;
            this.btn_minimize.TabIndex = 3;
            this.btn_minimize.Text = "-->";
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // groupNumber
            // 
            this.groupNumber.Controls.Add(this.lPhone);
            this.groupNumber.Location = new System.Drawing.Point(140, 20);
            this.groupNumber.Name = "groupNumber";
            this.groupNumber.Size = new System.Drawing.Size(230, 32);
            this.groupNumber.TabIndex = 20;
            this.groupNumber.TabStop = false;
            // 
            // lPhone
            // 
            this.lPhone.AutoSize = true;
            this.lPhone.BackColor = System.Drawing.Color.Transparent;
            this.lPhone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPhone.Location = new System.Drawing.Point(23, 10);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(51, 16);
            this.lPhone.TabIndex = 0;
            this.lPhone.Text = "Номер";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(217)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(116)))), ((int)(((byte)(100)))));
            this.btnClose.Location = new System.Drawing.Point(381, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 20);
            this.btnClose.TabIndex = 21;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // VoIPNotifyContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(165)))));
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupNumber);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "VoIPNotifyContact";
            this.Size = new System.Drawing.Size(406, 200);
            this.Tag = "";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupNumber, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupNumber.ResumeLayout(false);
            this.groupNumber.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label lLastName;
        public System.Windows.Forms.Label lFirstName;
        public System.Windows.Forms.Label lPatronymic;
        private System.Windows.Forms.GroupBox groupBox2;
        public DevExpress.XtraEditors.SimpleButton btnClientDetails;
        public DevExpress.XtraEditors.SimpleButton btnTransferCall;
        public DevExpress.XtraEditors.SimpleButton btn_minimize;
        private System.Windows.Forms.GroupBox groupNumber;
        private System.Windows.Forms.Label lPhone;
        public System.Windows.Forms.Button btnClose;
        #endregion
    }
}
