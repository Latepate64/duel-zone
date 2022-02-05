using Common.Choices;
using System.Windows.Forms;

namespace Client
{
    internal class ChoicePanel : FlowLayoutPanel
    {
        readonly internal Label Label = new();
        readonly internal Button PassButton = new() { Text = "Pass", Enabled = false, };
        Client _client;

        internal ChoicePanel(Client client)
        {
            _client = client;

            BackColor = System.Drawing.Color.Beige;
            FlowDirection = FlowDirection.TopDown;
            Width = 600;
            Height = 200;
            Label.Width = Width;

            PassButton.Click += PassButton_Click;

            Controls.Add(Label);
            Controls.Add(PassButton);

        }

        private void PassButton_Click(object sender, System.EventArgs e)
        {
            var decision = new GuidDecision { Decision = new System.Collections.Generic.List<System.Guid>() };
            _client.WriteAsync(decision);
        }
    }
}
