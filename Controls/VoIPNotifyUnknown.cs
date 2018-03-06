using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Technology.VoIP
{
    public partial class VoIPNotifyUnknown : VoIPNotifyBase
    {
        public VoIPNotifyUnknown()
            : base()
        {
            InitializeComponent();
            btnAdd2Exist.Enabled = false;
            btnAddContact.Enabled = false;
            base.rmarg = 20;
        }

        public override void Init()
        {
            base.Init();
            lPhone.Text = base.Phone;
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            base.OnButtonClicked(sender, e);
        }

        private void btnAdd2Exist_Click(object sender, EventArgs e)
        {
            base.OnButtonClicked(sender, e);
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            base.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.OnButtonClicked(sender, e);
        }

        public override void AlertStop()
        {
            base.AlertStop();
            btnAddContact.Enabled = true;
            btnAdd2Exist.Enabled = true;
        }
      
    }
}
