namespace Technology.VoIP
{
    partial class VoIPNotifyUnknown
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddContact = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd2Exist = new DevExpress.XtraEditors.SimpleButton();
            this.btn_minimize = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lLastName = new System.Windows.Forms.Label();
            this.grpNumber = new System.Windows.Forms.GroupBox();
            this.lPhone = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddContact);
            this.groupBox2.Controls.Add(this.btnAdd2Exist);
            this.groupBox2.Controls.Add(this.btn_minimize);
            this.groupBox2.Location = new System.Drawing.Point(35, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 160);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Image = global::Technology.VoIP.Properties.Resources.new1;
            this.btnAddContact.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAddContact.Location = new System.Drawing.Point(5, 110);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(85, 35);
            toolTipItem1.Text = "Создать контакт";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnAddContact.SuperTip = superToolTip1;
            this.btnAddContact.TabIndex = 18;
            this.btnAddContact.Tag = "CreateNew";
            this.btnAddContact.Text = "Создать";
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // btnAdd2Exist
            // 
            this.btnAdd2Exist.Image = global::Technology.VoIP.Properties.Resources.add2Exist;
            this.btnAdd2Exist.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAdd2Exist.Location = new System.Drawing.Point(5, 65);
            this.btnAdd2Exist.Name = "btnAdd2Exist";
            this.btnAdd2Exist.Size = new System.Drawing.Size(85, 35);
            toolTipTitleItem1.Text = "Добавить";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Добавить номер к существующему контакту / клиенту";
            superToolTip2.Items.Add(toolTipTitleItem1);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnAdd2Exist.SuperTip = superToolTip2;
            this.btnAdd2Exist.TabIndex = 9;
            this.btnAdd2Exist.Tag = "Add2Exist";
            this.btnAdd2Exist.Text = "Добавить";
            this.btnAdd2Exist.Click += new System.EventHandler(this.btnAdd2Exist_Click);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Location = new System.Drawing.Point(5, 20);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(85, 35);
            toolTipItem3.Text = "Свернуть";
            superToolTip3.Items.Add(toolTipItem3);
            this.btn_minimize.SuperTip = superToolTip3;
            this.btn_minimize.TabIndex = 3;
            this.btn_minimize.Text = "-->";
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lLastName);
            this.groupBox4.Location = new System.Drawing.Point(136, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(149, 55);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            // 
            // lLastName
            // 
            this.lLastName.AutoSize = true;
            this.lLastName.BackColor = System.Drawing.Color.Transparent;
            this.lLastName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLastName.Location = new System.Drawing.Point(2, 17);
            this.lLastName.Name = "lLastName";
            this.lLastName.Size = new System.Drawing.Size(141, 16);
            this.lLastName.TabIndex = 5;
            this.lLastName.Text = "Неизвестный номер";
            // 
            // grpNumber
            // 
            this.grpNumber.Controls.Add(this.lPhone);
            this.grpNumber.Location = new System.Drawing.Point(136, 81);
            this.grpNumber.Name = "grpNumber";
            this.grpNumber.Size = new System.Drawing.Size(149, 40);
            this.grpNumber.TabIndex = 20;
            this.grpNumber.TabStop = false;
            // 
            // lPhone
            // 
            this.lPhone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPhone.Location = new System.Drawing.Point(2, 13);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(141, 21);
            this.lPhone.TabIndex = 0;
            this.lPhone.Text = "Номер телефона";
            this.lPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(217)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(116)))), ((int)(((byte)(100)))));
            this.btnClose.Location = new System.Drawing.Point(265, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 20);
            this.btnClose.TabIndex = 19;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // VoIPNotifyUnknown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(165)))));
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpNumber);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "VoIPNotifyUnknown";
            this.Size = new System.Drawing.Size(290, 180);
            this.Tag = "";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.grpNumber, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpNumber.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBox2;
        public DevExpress.XtraEditors.SimpleButton btnAddContact;
        public DevExpress.XtraEditors.SimpleButton btnAdd2Exist;
        public DevExpress.XtraEditors.SimpleButton btn_minimize;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label lLastName;
        private System.Windows.Forms.GroupBox grpNumber;
        private System.Windows.Forms.Label lPhone;
     
        public System.Windows.Forms.Button btnClose;

        #endregion
    }
}
