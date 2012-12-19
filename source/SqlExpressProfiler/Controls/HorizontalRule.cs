using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AnfiniL.SqlExpressProfiler.VisualStyles;

namespace Attech.FlightMonitor.UI.Controls
{
    public class HorizontalRule : Control
    {
        public HorizontalRule()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.UserPaint |
                            ControlStyles.ResizeRedraw |
                            ControlStyles.OptimizedDoubleBuffer, true);
        }

        private Pen _pen;
        private Brush _brush;
        private int _OFFSET = 5;
        protected override void OnPaint(PaintEventArgs e)
        {
            if(_pen == null)
                _pen = new Pen(VisualStyleUtils.GetColor(VisualStyleElement.Button.GroupBox.Disabled, ColorProperty.EdgeShadowColor, Color.Gray), 1);

            if(_brush == null)
                _brush = new SolidBrush(VisualStyleUtils.GetColor(VisualStyleElement.Button.GroupBox.Normal, ColorProperty.TextColor, SystemColors.ControlText));

            float textSize = e.Graphics.MeasureString(this.Text, this.Font).Width;

            e.Graphics.DrawLine(_pen, 0, this.Height / 2, RightToLeft == RightToLeft.No ? _OFFSET : this.Width - textSize - _OFFSET, this.Height / 2);
            e.Graphics.DrawString(this.Text, this.Font, _brush, RightToLeft == RightToLeft.No ? _OFFSET : this.Width - textSize - _OFFSET, this.Height / 2 - this.Font.Height / 2);
            e.Graphics.DrawLine(_pen, RightToLeft == RightToLeft.No ? _OFFSET  + textSize : this.Width - _OFFSET , this.Height / 2, this.Width, this.Height / 2);
            
            base.OnPaint(e);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }
    }
}
