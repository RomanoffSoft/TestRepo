using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Technology.VoIP
{
    public partial class VoIPNotifyBase : UserControl, ICallNotify
    {
        bool minimized = false;
        protected Size defsize;
        Size externarea;
        protected Size contentsize;
        Point deflocation; // расчетное расположение контрола 
        Point extarealocation;
        int posStart;
        int AnimationDuration = 500; // длительность анимации (лучше пусть будет 0.5 секунды)
        Size parentsize; //размеры формы - владельца
        Stopwatch swscroll; // для анимации
        private int posStop;
        System.Windows.Forms.Timer scrolltimer; // для анимации "выезжания"
        System.Windows.Forms.Timer flashtimer; //для анимации "мигания"
        private Bitmap _photo; // фото рыла клиента (если есть)
        private string _lstname;
        protected int rmarg; //смещение относительно правого края
        CallDirection type;
        string _calltype;
        Color defbutcolor;
        CallsEventArgs _callinfo;
        Label lcalltype;

        GradientPanel _header;
        LinearGradientBrush _headerbrush;
        SolidBrush _highlightbrush;
        Graphics graph;
      


        public VoIPNotifyBase()
        {
            InitializeComponent();
            initmanualcomponents();
            minimized = true;
            defsize = this.Size;
            _calltype = "Входящий вызов";
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                initsubscriptions();
            }
        }


        private void initlocation()
        {
            //if (minimized)
            //    this.Location = new Point(this.ParentForm.Width - this.externarea.Width - rmarg, (int)(this.ParentForm.Height * 0.3));
            //else
            //    this.Location = new Point(this.ParentForm.Width - this.Width - this.externarea.Width-rmarg, (int)(this.ParentForm.Height * 0.3));

            if (minimized)
                this.Location = new Point(this.parentsize.Width - this.externarea.Width - rmarg, (int)(this.parentsize.Height * 0.3));
            else
                this.Location = new Point(this.parentsize.Width - this.Width - this.externarea.Width - rmarg, (int)(this.parentsize.Height * 0.3));

            if (!minimized)
            {
                deflocation = this.Location;
            }
            else
            {
                deflocation = new Point(this.Location.X - defsize.Width + externarea.Width * 2, this.Location.Y);
            }
            defsize = this.Size;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private void initsubscriptions()
        {
            // content.btnClientDetails.Click += btnClientDetails_Click;
            this.ParentChanged += VoIPNotify_Load;
        }




        protected virtual void initmanualcomponents()
        {
            
            int extheight = 0;

            //foreach (Control control in this.Controls)
            //{
            //    if (control.GetType() != typeof(VoIPControl))
            //    {
            //        extheight = extheight + control.Height;
            //    }
            //}

            //   externarea = new Size(this.Size.Width-this.content.Size.Width,this.Height);
            //   externarea = new Size(this.Size.Width - this.content.Size.Width, extheight);
            //     initsize();
            defsize = this.Size;
            externarea = externButton.Size;
            extarealocation = externButton.Location;
            //   content = new VoIPControl();
            //     this.Controls.Add(content);
            //     this.LocationChanged += VoIPControl_LocationChanged;
            minimized = false;
            contentsize = new System.Drawing.Size(defsize.Width - externarea.Width, defsize.Height);
            //    content.Visible = true;
            defbutcolor = this.externButton.Appearance.BackColor2;
            //_header = new Rectangle(externarea.Width + 5, 0, contentsize.Width, 20);
            //_headerbrush = new LinearGradientBrush(_header, Color.FromArgb(163, 190, 217), Color.FromArgb(179, 204, 230), 90);
            //   rmarg = this.Width - this.contentsize.Width - this.externButton.Width + 15;
            lcalltype = new Label();

        }
        protected virtual void initsize()
        {
            defsize = this.Size;
        }

        private void initcontentzone()
        {

        }


        #region закрытые методы






        private void scrollout()
        {
            scrolltimer = new Timer();
            scrolltimer.Interval = 15;
            scrolltimer.Tick += scrolltimer_out_Tick;
            swscroll = new Stopwatch();
            posStart = this.Location.X;
            posStop = deflocation.X;
            scrolltimer.Start();
            swscroll.Start();
        }

        private void scrollin()
        {
            scrolltimer = new Timer();
            scrolltimer.Interval = 15;
            scrolltimer.Tick += scrolltimer_in_Tick;
            swscroll = new Stopwatch();
            posStart = this.Location.X;
            posStop = deflocation.X + defsize.Width - externarea.Width * 2;
            scrolltimer.Start();
            swscroll.Start();
        }



        void scrolltimer_out_Tick(object sender, EventArgs e)
        {
            long elapsed = swscroll.ElapsedMilliseconds;
            int posCurrent = (int)(posStart - ((-posStop + posStart) * elapsed / AnimationDuration));

            bool neg = (posStop - posStart) < 0;
            if ((neg && posCurrent < posStop) ||
                (!neg && posCurrent > posStop))
            {
                posCurrent = posStop;
            }
            this.Location = new Point(posCurrent, this.Location.Y);
            if (elapsed > AnimationDuration)
            {
                scrolltimer.Stop();
                swscroll.Reset();
                externButton.Visible = false;
            }
        }


        void scrolltimer_in_Tick(object sender, EventArgs e)
        {
            long elapsed = swscroll.ElapsedMilliseconds;
            int posCurrent = (int)(posStart + ((posStop - posStart) * elapsed / AnimationDuration));

            bool neg = (posStop - posStart) < 0;
            if ((neg && posCurrent < posStop) ||
                (!neg && posCurrent > posStop))
            {
                posCurrent = posStop;
            }
            this.Location = new Point(posCurrent, this.Location.Y);
            if (elapsed > AnimationDuration)
            {
                scrolltimer.Stop();
                swscroll.Reset();
                //   this.content.Visible = false;
                this.Size = externarea;
                externButton.Visible = true;
                show_externarea();
                this.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.BackColor = Color.FromArgb(247, 245, 241);
            }
        }


        private void minimize() //Видна только область с кнопкой
        {
            scrollin();
            externButton.Location = new Point(0, extarealocation.Y);
            //     this.Location = new Point(this.Location.X + defsize.Width - externarea.Width, this.Location.Y);
            //       this.Location = new Point(deflocation.X + defsize.Width - externarea.Width, this.Location.Y);

            //      this.content.Visible = false;
            minimized = true;
        }
        private void maximize()  //Разворачиваем содержимое
        {
            this.BackColor = Color.FromArgb(255, 255, 165);
            scrollout();
            this.Size = defsize;
            //    this.Size = new System.Drawing.Size(this.Size.Width - externarea.Width, this.Height);
            //   this.Location = deflocation;           
            externButton.Location = new Point(0, extarealocation.Y);
            //    this.content.Visible = true;
            minimized = false;
            //externButton.Location = new Point()
        }


        private void VoIPNotify_Load(object sender, EventArgs e)
        {
            if (!this.Disposing)
            {
                parentsize = this.Parent.Size;
                this.Parent.SizeChanged += ParentForm_SizeChanged;
                initlocation();
                _header = new GradientPanel();
                _header.Location = new Point(this.externarea.Width, 0);
                _header.Size = new Size(this.Width, 20);
                this.Controls.Add(_header);
                lcalltype.BackColor = Color.Transparent;
                lcalltype.AutoSize = true;
                //  lcalltype.Text = Direction.ToString();
                lcalltype.Location = new Point(this.Width / 2 - this.externarea.Width, 2);
                lcalltype.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Bold);
                _header.Controls.Add(lcalltype);
            }
            //   _header.Controls.Add(lPhone);
        }

        void ParentForm_SizeChanged(object sender, EventArgs e)
        {
            Form Parent = (Form)sender;
            int newX = 0;
            int newY = 0;
            if (parentsize.Width < Parent.Size.Width)
            {
                int upscale = Parent.Size.Width - parentsize.Width;
                if (!minimized)
                {
                    newX = deflocation.X + upscale;
                    newY = (int)(Parent.Height * 0.3);
                    this.Location = new Point(newX, newY);
                }
                else
                {
                    newX = this.Location.X + upscale;
                    this.Location = new Point(newX, this.Location.Y);
                    newX = deflocation.X + upscale;
                }
            }
            else
            {
                int downscale = parentsize.Width - Parent.Size.Width;
                if (!minimized)
                {
                    newX = deflocation.X - downscale;
                }
                else
                {
                    newX = this.Location.X - downscale;
                    this.Location = new Point(newX, this.Location.Y);
                    newX = deflocation.X - downscale; ;
                }

            }
            deflocation = new Point(newX, this.Location.Y);
            parentsize = Parent.Size;

        }


        private void settooltip()
        {

            if (type == CallDirection.Outgoing)
            {
                _calltype = "Исходящий вызов";
            }
            this.externButton.SuperTip = new DevExpress.Utils.SuperToolTip();
            //   this.externButton.SuperTip.Items.Add(_calltype + "\n" + "[" + this.PhoneNumber + "]" + "\n" + "[" + this.LastName + " " + this.FirstName.Substring(0, 1) + ". " + this.Patronymic.Substring(0, 1) + ".]");
        }

        private void show_externarea()
        {
            //  this.Size = defsize;

            //     this.content.Location = new Point(this.content.Location.X + this.externarea.Width, this.content.Location.Y);
            foreach (Control control in this.Controls)
            {
                if (control.Name != "externButton")
                    control.Left = control.Left + this.externarea.Width;
            }
            //   _header.X = _header.X + this.externarea.Width;
            this.externButton.Visible = true;
            _header.Location = new Point(this.externarea.Width, 0);
            //  this.BackColor = SystemColors.Control;
            this.Refresh();

        }

        private void hide_externarea()
        {
            this.Size = new Size(defsize.Width - this.externarea.Width, defsize.Height);
            //   this.content.Location = new Point(this.content.Location.X - this.externarea.Width, this.content.Location.Y);
            foreach (Control control in this.Controls)
            {
                if (control.Name != "externButton")
                    control.Left = control.Left - this.externarea.Width;
            }
            _header.Location = new Point(0, 0);
            //   _header.X = _header.X - this.externarea.Width;
            this.Location = new Point(this.Location.X + this.externarea.Width, this.Location.Y);
            this.externButton.Visible = false;
        }

        void flashtimer_Tick(object sender, EventArgs e)
        {
            if (!this.externButton.IsHighlighted)
            {
                this.externButton.Highlight();
                highlightcontentheader();
            }
            else
            {
                this.externButton.UnHighlight();
                unhighlightcontentheader();
            }


        }

        private void externButton_Click(object sender, EventArgs e)
        {
            Show();
        }

        #endregion

        /// <summary>
        /// Развернуть контрол
        /// </summary>
        public void Show()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            minimizing = false;
            maximize();
            hide_externarea();
            settooltip();
            this.BringToFront();
        }
        /// <summary>
        /// Свернуть
        /// </summary>
        public void Hide()
        {
            minimizing = true;
            minimize();
            //  show_externarea();
        }
        /// <summary>
        /// Начать мигать
        /// </summary>
        public void FlashStart()
        {
            flashtimer = new Timer();
            flashtimer.Interval = 500;
            flashtimer.Tick += flashtimer_Tick;
            flashtimer.Start();
        }


        /// <summary>
        /// Закончить мигать
        /// </summary>
        public void FlashStop()
        {
            flashtimer.Stop();
            this.externButton.BackColor = defbutcolor;
        }


        private void highlightcontentheader()
        {
            //   SolidBrush brush =new SolidBrush(Color.LightYellow);
            //    HighlightHeader();

        }
        private void unhighlightcontentheader()
        {
            //   SolidBrush brush =new SolidBrush(Color.LightYellow);
            //    UnHighlightHeader();

        }

        protected virtual void OnButtonClicked(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = ButtonClicked;
            if (handler != null)
            {
                handler(sender, e);
            }
        }



        #region Свойства




        public string LastName
        {
            set;
            get;
        }

        public string FirstName
        {
            set { _firstname = value; }
            get { return _firstname; }
        }




        #endregion

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



        public string Patronymic
        {
            set;
            get;
        }

        public Bitmap Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
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

        public Size ParentSize
        {
            set
            {
                parentsize = value;
                initlocation();
            }
        }


        private int _index;
        private bool _knownperson;

        public virtual void Init()
        {

        }


        public event EventHandler<EventArgs> ButtonClicked;
        private CallPersonType _persontype;
        private CallDirection _calldirection;
        private string _firstname;
        private string _phone;
        private VoIP.ContractInfo _contractinfo;
        private bool minimizing;

        public void Close()
        {
            this.Dispose();
        }


        public void AlertStart()
        {
            FlashStart();
        }

        public virtual void AlertStop()
        {
            FlashStop();
        }


        public CallPersonType PersonType
        {
            get
            {
                return _persontype;
            }
            set
            {
                _persontype = value;
            }
        }


        public CallDirection Direction
        {
            get
            {
                return _calldirection;
            }
            set
            {
                _calldirection = value;
                switch (value)
                {
                    case CallDirection.Incoming:
                        lcalltype.Text = "Входящий вызов";
                        break;
                    case CallDirection.Outgoing:
                        lcalltype.Text = "Исходящий вызов";
                        break;
                }
            }
        }


        public ContractInfo ContractInfo
        {
            get
            {
                return _contractinfo;
            }
            set
            {
                _contractinfo = value;
            }
        }
    }
}
