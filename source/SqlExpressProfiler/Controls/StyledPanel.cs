using System;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Attech.FlightMonitor.UI.Controls
{
    public class StyledPanel : ScrollableControl
    {
        private BorderStyle _borderStyle = BorderStyle.None;
        private Color _borderColor = Color.Gray;
        private Pen _borderPen = new Pen(Color.Gray);
        private bool _useGradientBackColor = false;
        private LinearGradientMode _gradientMode;
        private Color _gradientColor1;
        private Color _gradientColor2;
        
        public StyledPanel()
        {
            //Double buffer the control
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.DoubleBuffer, true);
        }
        
        [Category("Appearance"), Description("The border style of panel")]
        public BorderStyle BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                _borderStyle = value; 
                this.Invalidate();
            }
        }
        public override Rectangle DisplayRectangle
        {
            get
            {
                if (_borderStyle != System.Windows.Forms.BorderStyle.None)
                    return new Rectangle(1, 1, this.Width-2, this.Height - 2);
                else 
                    return base.DisplayRectangle;
            }
        }

        [Category("Appearance"), Description("The border color of panel")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; _borderPen.Color = value; this.Invalidate();}
        }

        [Browsable(false)]
        public Pen BorderPen
        {
            get { return _borderPen; }
            set { _borderPen = value; this.Invalidate();}
        }

        [Category("Appearance")]
        public bool UseGradientBackColor
        {
            get { return _useGradientBackColor; }
            set { _useGradientBackColor = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        public LinearGradientMode GradientMode
        {
            get { return _gradientMode; }
            set { _gradientMode = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        public Color GradientColor1
        {
            get { return _gradientColor1; }
            set { _gradientColor1 = value; }
        }

        [Category("Appearance")]
        public Color GradientColor2
        {
            get { return _gradientColor2; }
            set { _gradientColor2 = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Draw backcolor
            if(_useGradientBackColor)
            {
                LinearGradientBrush brush = new LinearGradientBrush(e.ClipRectangle, _gradientColor1, _gradientColor2, _gradientMode);
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
            
            //Draw border
            switch(_borderStyle)
            {
                case System.Windows.Forms.BorderStyle.FixedSingle:
                    e.Graphics.DrawRectangle(_borderPen, 0, 0, this.Width - 1, this.Height - 1);
                    break;
                case System.Windows.Forms.BorderStyle.Fixed3D:
                    ControlPaint.DrawBorder3D(e.Graphics, 0, 0, this.Width - 1, this.Height - 1, Border3DStyle.Sunken);
                    break;
                default:
                    break;
            }

            base.OnPaint(e);
        }
    }
}
