using Common.Choices;
using System.Windows.Forms;

namespace Client
{
    internal class ChoicePanel : FlowLayoutPanel
    {
        readonly internal Label Label = new();
        readonly internal Button DefaultButton = new() { Text = "Pass", Enabled = false, };
        readonly Client _client;
        readonly TablePage _tablePage;

        internal ChoicePanel(Client client, TablePage tablePage)
        {
            _client = client;
            _tablePage = tablePage;

            BackColor = System.Drawing.Color.Beige;
            FlowDirection = FlowDirection.TopDown;
            Width = 600;
            Height = 200;
            Label.Width = Width;

            DefaultButton.Click += DefaultButtonClick;

            Controls.Add(Label);
            Controls.Add(DefaultButton);

        }

        private void DefaultButtonClick(object sender, System.EventArgs e)
        {
            Decision decision;
            if (_tablePage.CurrentChoice is GuidSelection)
            {
                decision = new GuidDecision { Decision = new System.Collections.Generic.List<System.Guid>() };
            }
            else if (_tablePage.CurrentChoice is YesNoChoice)
            {
                decision = new YesNoDecision { Decision = true };
            }
            else
            {
                throw new System.NotImplementedException();
            }
            _client.WriteAsync(decision);
        }
    }
}
