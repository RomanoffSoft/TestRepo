using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Technology.VoIP
{
    public partial class VoIPNotifyContact : VoIPNotifyBase
    {
       
        public VoIPNotifyContact():base ()
        {
            InitializeComponent();          
            base.rmarg = 15;
            base.defsize = this.Size;
            btnClientDetails.Enabled = false;
            btnTransferCall.Enabled = false;
        }

        public override void Init()
        {
            base.Init();
            lFirstName.Text = base.FirstName;
            lLastName.Text = base.LastName;
            lPatronymic.Text = base.Patronymic;
            lPhone.Text = base.Phone;
        }
        
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            base.Hide();
        }

        private void btnClientDetails_Click(object sender, EventArgs e)
        {
            base.OnButtonClicked(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.OnButtonClicked(sender, e);
        }
        public override void AlertStop()
        {
            base.AlertStop();
            btnClientDetails.Enabled = true;
            btnTransferCall.Enabled = true;
        }
    }
}
