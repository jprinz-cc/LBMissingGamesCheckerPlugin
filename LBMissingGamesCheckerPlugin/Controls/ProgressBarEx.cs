using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LBMissingGamesCheckerPlugin.Controls
{
    public class ProgressBarEx : ProgressBar
    {
        private System.Windows.Forms.Timer marqueeTimer;
        private int marqueePosition = 0;
        private const int marqueeSpeed = 20;
        private const int marqueeSegmentWidth = 75;
        private bool disposed = false;

        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeMarquee();
        }

        private void InitializeMarquee()
        {
            marqueeTimer = new System.Windows.Forms.Timer
            {
                Interval = 50
            };
            marqueeTimer.Tick += (s, e) =>
            {
                marqueePosition += marqueeSpeed;
                if (marqueePosition > this.Width) marqueePosition = 0;
                this.Invalidate();
            };
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            const int inset = 2;

            using (Bitmap offscreenBitmap = new Bitmap(this.Width, this.Height))
            using (Graphics offscreen = Graphics.FromImage(offscreenBitmap))
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                if (ProgressBarRenderer.IsSupported)
                    ProgressBarRenderer.DrawHorizontalBar(offscreen, rect);

                rect.Inflate(new Size(-inset, -inset));

                if (this.Style == ProgressBarStyle.Marquee)
                {
                    if (!marqueeTimer.Enabled)
                    {
                        marqueeTimer.Start();
                    }

                    Rectangle marqueeRect = new Rectangle(marqueePosition, inset, marqueeSegmentWidth, rect.Height);
                    using (LinearGradientBrush brush = new LinearGradientBrush(marqueeRect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical))
                    {
                        offscreen.FillRectangle(brush, marqueeRect);
                    }
                }
                else
                {
                    rect.Width = (int)(rect.Width * ((double)this.Value / this.Maximum));
                    if (rect.Width == 0) rect.Width = 1;

                    using (LinearGradientBrush brush = new LinearGradientBrush(rect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical))
                    {
                        offscreen.FillRectangle(brush, inset, inset, rect.Width, rect.Height);
                    }
                }

                e.Graphics.DrawImage(offscreenBitmap, 0, 0);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!this.Visible && marqueeTimer != null)
            {
                marqueeTimer.Stop();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                if (marqueeTimer != null)
                {
                    marqueeTimer.Dispose();
                    marqueeTimer = null;
                }
            }
            disposed = true;
            base.Dispose(disposing);
        }
    }
}
