using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2Runner
{
    public class NewProgressBar : ProgressBar
    {
        public NewProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;
            Rectangle rec1 = e.ClipRectangle;
            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 1;
            rec1.Width = (int)(rec1.Width * ((double)(Maximum-Value) / Maximum)) - 1;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            rec1.Height = rec1.Height - 4;
            e.Graphics.FillRectangle(new SolidBrush(this.ForeColor), 2, 2, rec.Width, rec.Height);
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), rec.Width, 2, rec1.Width, rec1.Height);
        }
    }
}
