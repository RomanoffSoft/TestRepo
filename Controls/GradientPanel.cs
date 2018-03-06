using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Technology.VoIP
{
    public class GradientPanel : Panel
    {
        public GradientPanel()
        {
            this.ResizeRedraw = true;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(this.ClientRectangle,
                       Color.FromArgb(163, 190, 217), Color.FromArgb(179, 204, 230), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();
            base.OnScroll(se);
        }
    }
}
