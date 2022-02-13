using Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class ZonePanel : FlowLayoutPanel
    {
        internal ZoneType ZoneType { get; private set; }

        internal const int DefaultLeft = 270;
        private const double HeightScale = 0.26;
        private const double WidthScale = 0.65;

        private Point _mouseDownLocation;

        public ZonePanel(ZoneType zoneType, bool player)
        {
            SetupProperties(zoneType, player);
            new ToolTip().SetToolTip(this, $"{(player ? "Your" : "Your opponents")} {zoneType}");
            SetupEvents();
        }

        private void SetupProperties(ZoneType zoneType, bool player)
        {
            ZoneType = zoneType;
            Left = DefaultLeft;
            Width = 1000;
            BackColor = GetColor(ZoneType);
            AutoScroll = true;
            Visible = zoneType == ZoneType.BattleZone || (zoneType == ZoneType.Hand && player);
        }

        private void SetupEvents()
        {
            MouseDown += ZonePanel_MouseDown;
            MouseMove += ZonePanel_MouseMove;
        }

        private static Color GetColor(ZoneType zoneType)
        {
            return zoneType switch
            {
                ZoneType.BattleZone => Color.PaleVioletRed,
                ZoneType.Deck => Color.SandyBrown,
                ZoneType.Graveyard => Color.Gray,
                ZoneType.Hand => Color.LightBlue,
                ZoneType.ManaZone => Color.LightGreen,
                ZoneType.ShieldZone => Color.LightYellow,
                ZoneType.Anywhere => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
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
                Left = e.X + Left - _mouseDownLocation.X;
                Top = e.Y + Top - _mouseDownLocation.Y;
            }
        }

        private void ZonePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDownLocation = e.Location;
            }
        }

        public override string ToString()
        {
            return $"{Name} {ZoneType}";
        }
    }
}
