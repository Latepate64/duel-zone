using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class ZonePanel : FlowLayoutPanel
    {
        private Point MouseDownLocation;

        public ZonePanel(string name, int top, Color color)
        {
            Left = 50;
            Top = top;
            Height = 75;
            Width = 1000;
            BackColor = color;

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
