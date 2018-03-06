using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace Technology.VoIP
{
    public partial class frmCallNotifyExternal : Form, ICallNotify
    {
        private int _persnum;
        private string _lstname;
        private string _fstname;
        private string _scndname;
        private string _phone;
        private int aniDur;
        private ResourceManager resources;
        private CallsEventArgs _callinfo;
        private Rectangle HeaderRect;
        private LinearGradientBrush HeaderGrad;
        private Label lHeaderText;
        private string _headertext;
        private Rectangle _headertextcontainer;
        private LinearGradientBrush _contgrad;
        private Rectangle CancelRct;
        private int posStart;
        private int posStop;
        private Pen cncpen;
        public event EventHandler CloseClick;
        private bool gdiInitialized;
        private Brush brushContent;
        private System.Drawing.Font cncfont;
        private Bitmap imgPhoto;
        private Rectangle _lstnameRect;
        Rectangle RectClose;
        private Brush brushButtonHover;
        private Pen penButtonBorder;
        private Pen penContent;
        private bool _knownperson;
        private SimpleButton Button_Details;
        Stopwatch sw;
        private System.Windows.Forms.Timer anim;
        private SimpleButton Button_TransferCall;
        private CallDirection _direction;
        private CallPersonType _type;

        public frmCallNotifyExternal()
        {
            resources = new System.Resources.ResourceManager(typeof(frmCallNotifyExternal));
            _headertext = "Входящий вызов";
            InitializeComponent();
            //     AllocateGDIObjects();
            InitManualComponents();
            InitEvents();
            Initlocation();
            InitTimers();
            //   posStop = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;

            /*
            NotifyIcon icon = new NotifyIcon(this.components);
            icon.BalloonTipText = "Поступил звонок";
            //  icon.Container.Add(not);
            icon.Icon = SystemIcons.Application;
            icon.Visible = true;
            icon.ShowBalloonTip(1000);
            //  _persnum = PersonNumber;
             * */
        }

        public frmCallNotifyExternal(ICallNotify callinfo)
        {
            resources = new System.Resources.ResourceManager(typeof(frmCallNotifyExternal));
            _headertext = "Входящий вызов";
            InitializeComponent();
            //     AllocateGDIObjects();
            InitManualComponents();
            InitEvents();
            Initlocation();
            InitTimers();
            _callnotifyinfo = callinfo;


        }

        private void InitTimers()
        {
            anim = new System.Windows.Forms.Timer();
            anim.Interval = 10;
            AnimationDuration = 1000;
            anim.Tick += TimerCallback;
            anim.Start();
            sw = new Stopwatch();
            sw.Start();
        }

        private void TimerCallback(object sender, EventArgs e)
        {
            long elapsed = sw.ElapsedMilliseconds;

            int posCurrent = (int)(posStart + ((posStop - posStart) * elapsed / AnimationDuration));
            this.Top = posCurrent;
            bool neg = (posStop - posStart) < 0;
            if ((neg && posCurrent < posStop) ||
                (!neg && posCurrent > posStop))
            {
                posCurrent = posStop;
            }
            if (elapsed > AnimationDuration)
            {
                int posTemp = posStart;
                posStart = posStop;
                posStop = posTemp;
                sw.Reset();
            }


            //      this.Location = new Point(this.Location.X, this.Location.Y - 10);
            //if (this.Top >= posStop)
            //{
            //    anim.Stop();
            //    sw.Stop();
            //}
        }


        private void InitEvents()
        {
            this.MouseUp += Form_MouseUp;
            this.CloseClick += Form_CloseClick;
            this.MouseMove += frmCallNotifyExternal_MouseMove;
            //   this.Button_Details.Click += Button_Details_Click;
        }

        void Button_Details_Click(object sender, EventArgs e)
        {
            if (ShowDetailsClicked != null)
            {
                ShowDetailsClicked(this, new CallsEventArgs() {  });
            }
        }

        void frmCallNotifyExternal_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOnClose = RectClose.Contains(e.X, e.Y);
            //if (Parent.ShowOptionsButton)
            //{
            //    mouseOnOptions = RectOptions.Contains(e.X, e.Y);
            //   }
            //  mouseOnLink = RectContentText.Contains(e.X, e.Y);
            if (mouseOnClose)
                Invalidate();
        }

        void Form_CloseClick(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (RectClose.Contains(e.X, e.Y) && (CloseClick != null))
                {
                    CloseClick(this, EventArgs.Empty);
                }
            }
        }

        private void Initlocation()
        {
            posStart = Screen.PrimaryScreen.WorkingArea.Bottom;
            posStop = Screen.PrimaryScreen.WorkingArea.Bottom - this.ClientSize.Height;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.ClientSize.Width - 1, posStart);
        }

        private void InitManualComponents()
        {
            HeaderRect = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height / 8);
            HeaderGrad = new LinearGradientBrush(HeaderRect, Color.FromArgb(128, 173, 206, 240), Color.FromArgb(128, 173, 206, 240), 0, false);
            //    CancelRct = new Rectangle(this.ClientSize.Width - 15, 1, 15, 15);
            _headertextcontainer = new Rectangle(HeaderRect.Width / 2 - _headertext.Length * (7 / 2), 3, _headertext.Length * 7, this.ClientSize.Height / 8);
            _contgrad = new LinearGradientBrush(_headertextcontainer, Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 255, 255, 255), 0, false);
            // imgPhoto = PhotoPicker.PickPhoto(_persnum);
            _lstnameRect = new Rectangle(80, 20, 100, 15);
            //    RectClose = new Rectangle(this.Width - 16 - 6, HeaderRect.Height + 3, 16, 16);
            RectClose = new Rectangle(this.Width - 16 - 6, HeaderRect.Height - 18, 16, 16);
            Button_Details = new SimpleButton();
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            if (!gdiInitialized)
            {
                AllocateGDIObjects();
                //  InitManualComponents();            
            }

            if (Photo != null)
            {
                e.Graphics.DrawImage(imgPhoto, new Point(20, 30));
            }
            else
            {
                e.Graphics.DrawImage(PhotoPicker.Convert2Photo((Bitmap)resources.GetObject("unknown")), new Point(20, 30));
            }
            e.Graphics.DrawString(_phone, cncfont, brushContent, new PointF(100, 20));
            e.Graphics.DrawString(_lstname, cncfont, brushContent, new PointF(90, 35));
            e.Graphics.DrawString(_fstname, cncfont, brushContent, new PointF(90, 55));
            e.Graphics.DrawString(_scndname, cncfont, brushContent, new PointF(90, 75));
            e.Graphics.FillRectangle(HeaderGrad, HeaderRect);
            e.Graphics.DrawString(_headertext, this.Font, brushContent, _headertextcontainer);
            //    e.Graphics.FillRectangle(HeaderGrad, CancelRct);
            //      e.Graphics.DrawString("x", cncfont, brushContent, CancelRct);

            if (mouseOnClose)
            {
                e.Graphics.FillRectangle(brushButtonHover, RectClose);
                e.Graphics.DrawRectangle(penButtonBorder, RectClose);
            }

            e.Graphics.DrawLine(penContent, RectClose.Left + 4, RectClose.Top + 4, RectClose.Right - 4, RectClose.Bottom - 4);
            e.Graphics.DrawLine(penContent, RectClose.Left + 4, RectClose.Bottom - 4, RectClose.Right - 4, RectClose.Top + 4);
        }

        public void Init()
        {
            if (_knownperson)
            {
                this.Button_Details = new SimpleButton();
                this.Button_Details.Image = (Bitmap)resources.GetObject("clientProfile");
                this.Button_Details.Location = new Point(170, 40);
                this.Button_Details.Size = new Size(40, 35);
                //     this.Button_Details.Text = "Details";
                this.Button_Details.Visible = true;
                this.Button_Details.Click += Button_Details_Click;
                this.Controls.Add(this.Button_Details);
            }

            this.Button_TransferCall = new SimpleButton();
            this.Button_TransferCall.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Button_TransferCall.Image = global::Technology.VoIP.Properties.Resources.phone_transfer;
            this.Button_TransferCall.Location = new System.Drawing.Point(170, 70);
            this.Button_TransferCall.Name = "Button_TransferCall";
            this.Button_TransferCall.Size = new System.Drawing.Size(89, 32);
            this.Button_TransferCall.TabIndex = 7;
            this.Button_TransferCall.Text = "Перевод";
            this.Button_TransferCall.Click += Button_Transfer_Click;
            //this.Button_TransferCall = new SimpleButton();
            //this.Button_TransferCall.Image = (Bitmap)resources.GetObject("phone_transfer");
            //this.Button_TransferCall.Location = new Point(40, 50);
            //this.Button_TransferCall.Size = new Size(40, 35);
            //this.Button_TransferCall.Visible = true;
            //this.Button_TransferCall.Click += Button_Transfer_Click;
            this.Controls.Add(this.Button_TransferCall);
        }

        void Button_Transfer_Click(object sender, EventArgs e)
        {
            if (TransferCallClicked != null)
            {

                //  TransferCallClicked(this, new NotifyFormEventArgs(_index,Phone,_callinfo.CallID));
                TransferCallClicked(this, new CallsEventArgs() { srcPhone = Phone, CallID = CallInfo.CallID });
            }
        }


        /// <summary>
        /// Create all GDI objects used to paint the form.
        /// </summary>
        private void AllocateGDIObjects()
        {
            brushContent = new SolidBrush(this.ForeColor);
            cncfont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            cncpen = new Pen(Color.Black, 1);
            gdiInitialized = true;
            brushButtonHover = new SolidBrush(Color.White);
            penButtonBorder = new Pen(Color.FromArgb(128, 173, 206, 240));
            penContent = new Pen(Color.Black, 2);
            gdiInitialized = true;
        }


        private void DisposeGDIObjects()
        {
            if (gdiInitialized)
            {
                brushContent.Dispose();
                cncfont.Dispose();
                cncpen.Dispose();
                HeaderGrad.Dispose();
                _contgrad.Dispose();
                brushButtonHover.Dispose();
                penButtonBorder.Dispose();
                penContent.Dispose();
                anim.Dispose();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeGDIObjects();
            }
            base.Dispose(disposing);
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        public string LastName
        {
            get
            {
                return _lstname;
            }
            set
            {
                _lstname = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _fstname;
            }
            set
            {
                _fstname = value;
            }
        }

        public string Patronymic
        {
            get
            {
                return _scndname;
            }
            set
            {
                _scndname = value;
            }
        }

        public Bitmap Photo
        {
            get
            {
                return imgPhoto;
            }
            set
            {
                imgPhoto = value;
            }
        }


        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        public bool mouseOnClose { get; set; }


        public bool KnownPerson
        {
            get
            {
                return _knownperson;
            }
            set
            {
                _knownperson = value;
            }
        }
        public event EventHandler<CallsEventArgs> ShowDetailsClicked;
        public event EventHandler<CallsEventArgs> TransferCallClicked;
        private int _index;
        private long AnimationDuration;
        private ICallNotify _callnotifyinfo;


        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }



        public CallsEventArgs CallInfo
        {
            get
            {
                return _callinfo;
            }
            set
            {
                _callinfo = value;
            }
        }


        public event EventHandler<CallsEventArgs> CreateContactClicked;

        public event EventHandler<CallsEventArgs> AddToExistingClicked;


        public event EventHandler<EventArgs> ButtonClicked;


        public void AlertStart()
        {

        }

        public void AlertStop()
        {

        }


        public CallPersonType PersonType
        {
            get
            {
               return _type;
            }
            set
            {
                _type = value;
            }
        }


        public CallDirection Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }


        public ContractInfo ContractInfo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
