using Technology.VoIP.Properties;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Technology.VoIP
{
    public class CallButton : RepositoryItemButtonEdit
    {
        public CallButton()
            : base()
        {
            this.Buttons[0].Kind = ButtonPredefines.Glyph;
            //  this.Buttons[0].Image = Resources.phone_small;
            this.Buttons[0].Image = Resources.phone_verysmall;
            this.Buttons[0].ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //  this.Buttons[0].Caption = "Позвонить";
        }

     
      
        
    }
}
