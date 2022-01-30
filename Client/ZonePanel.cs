using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class ZonePanel : FlowLayoutPanel
    {
        internal const int DefaultHeight = 250;
        private Point MouseDownLocation;

        public ZonePanel(string name, Color color)
        {
            Left = 270;
            Height = DefaultHeight;
            Width = 1000;
            BackColor = color;
            AutoScroll = true;
            Visible = false;

            new ToolTip().SetToolTip(this, name);

            MouseDown += ZonePanel_MouseDown;
            MouseMove += ZonePanel_MouseMove;
        }

        private void ZonePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left = e.X + Left - MouseDownLocation.X;
                Top = e.Y + Top - MouseDownLocation.Y;
            }
        }

        private void ZonePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
    }
}
