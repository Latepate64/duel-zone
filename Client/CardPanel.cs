using System.Windows.Forms;

namespace Client
{
    class CardPanel : FlowLayoutPanel
    {
        const double SizeScale = 0.3;

        public CardPanel(string text)
        {
            Height = (int)(307 * SizeScale);
            Width = (int)(222 * SizeScale);
            BackColor = System.Drawing.Color.Blue;

            Controls.Add(new Label { Text = text });
        }
    }
}
