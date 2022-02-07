using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class ZonePanel : FlowLayoutPanel
    {
        internal const double HeightScale = 0.265;
        internal const double WidthScale = 0.75;
        internal const int DefaultLeft = 270;
        private Point MouseDownLocation;
        public Common.ZoneType ZoneType { get; }

        public ZonePanel(string name, Color color, Common.ZoneType zoneType)
        {
            ZoneType = zoneType;

            Left = DefaultLeft;
            
            Width = 1000;
            BackColor = color;
            AutoScroll = true;
            Visible = false;

            new ToolTip().SetToolTip(this, name);

            MouseDown += ZonePanel_MouseDown;
            MouseMove += ZonePanel_MouseMove;
        }

        internal void SetSize(Size size)
        {
            Height = (int)(HeightScale * size.Height);
            Width = (int)(WidthScale * size.Width);
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

        public override string ToString()
        {
            return $"{Name} {ZoneType}";
        }
    }
}
