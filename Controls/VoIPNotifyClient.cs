using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Technology.VoIP
{
    public partial class VoIPNotifyClient : VoIPNotifyBase
    {
        public VoIPNotifyClient()
            : base()
        {
            InitializeComponent();
            base.defsize = this.Size;
            base.rmarg = 20;
            btnClientDetails.Enabled = false;
            btnTransferCall.Enabled = false;
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            base.Hide();
        }

        private void btnClientDetails_Click(object sender, EventArgs e)
        {
            base.OnButtonClicked(sender, e);
        }
        public override void Init()
        {
            base.Init();
            lFirstName.Text = base.FirstName;
            lLastName.Text = base.LastName;
            lPatronymic.Text = base.Patronymic;
            lPhone.Text = base.Phone;
            if (base.ContractInfo != null)
            {
                lTemplate.Text = base.ContractInfo.TemplateName;
                lStopDate.Text = base.ContractInfo.StopDate != null ? base.ContractInfo.StopDate.Value.Date.ToShortDateString() : "";
                lStatus.Text = base.ContractInfo.Status;
            }
            clientPhoto.Image = base.Photo;
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
