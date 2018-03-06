using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Technology.VoIP
{
    /// <summary>
    /// SimpleButton с управлением подсветкой (для эффекта "мигания")
    /// </summary>
    public class CustomSimpleButton : DevExpress.XtraEditors.SimpleButton
    {
        public bool IsHighlighted;
        public CustomSimpleButton() : base() 
        {
          //  this.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
       //     this.Paint += CustomSimpleButton_Paint;
        }

        void CustomSimpleButton_Paint(object sender, PaintEventArgs e)
        {
            CustomSimpleButton sb = (CustomSimpleButton)sender;
            Graphics g = e.Graphics;
            Rectangle borderRectangle = new Rectangle(
                e.ClipRectangle.Location,
                new Size(
                    e.ClipRectangle.Width - 1,
                    e.ClipRectangle.Height - 1));
         //   g.DrawRectangle(new Pen(sb.Appearance.BorderColor), borderRectangle);
            g.DrawRectangle(new Pen(Color.Red), borderRectangle);
        }
        protected override DevExpress.XtraEditors.ViewInfo.BaseStyleControlViewInfo CreateViewInfo()
        {
            return new CustomViewInfo(this);
        }
        /// <summary>
        /// Подсвечиваем
        /// </summary>
        public void Highlight()
        {
            base.ViewInfo.State = DevExpress.Utils.Drawing.ObjectState.Hot;
            base.UpdateViewInfoState();
            IsHighlighted = true;
        }
        /// <summary>
        /// Отключаем подсветку
        /// </summary>
        public void UnHighlight()
        {
            base.ViewInfo.State = DevExpress.Utils.Drawing.ObjectState.Normal;
            base.UpdateViewInfoState();
            IsHighlighted = false;
        }

        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();

            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);

            GraphPath.CloseFigure();
            return GraphPath;
        }

        GraphicsPath GetPolyogonPath(RectangleF Rect,float Margin)
        {   
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddLine(Rect.X, Rect.Y + Margin, Rect.X + Rect.Width, Rect.Y);
            GraphPath.AddLine(Rect.X + Rect.Width, Rect.Y, Rect.X + Rect.Width, Rect.Y + Rect.Height);
            GraphPath.AddLine(Rect.X + Rect.Width, Rect.Y + Rect.Height, Rect.X, Rect.Y+Rect.Height - Margin);
            GraphPath.AddLine(Rect.X, Rect.Y + Rect.Height - Margin, Rect.X, Rect.Y + Margin);
            GraphPath.CloseFigure();
            return GraphPath;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            GraphicsPath GraphPath = GetPolyogonPath(Rect, 8);

            this.Region = new Region(GraphPath);
            using (Pen pen = new Pen(Color.CadetBlue, 1.75f))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, GraphPath);
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }


    }

    class CustomViewInfo : DevExpress.XtraEditors.ViewInfo.SimpleButtonViewInfo
    {
        CustomSimpleButton _owner;
        public CustomViewInfo(SimpleButton owner) : base(owner) { _owner = owner as CustomSimpleButton; }

        protected override DevExpress.Utils.Drawing.ObjectState CalcButtonState(EditorButtonObjectInfoArgs buttonInfo, DevExpress.Utils.Drawing.ObjectState state)
        {
           
            return this.State;
        }
        protected override bool UpdateObjectState()
        {
            return true;
        }
        }
    }
