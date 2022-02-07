using Common.Choices;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    internal class ChoicePanel : Panel
    {
        readonly Font _font = new(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
        readonly internal Label Label = new() { TextAlign = ContentAlignment.MiddleCenter };
        readonly internal Button DefaultButton = new() { Text = "Pass", Enabled = false };
        readonly Client _client;
        readonly TablePage _tablePage;

        internal ChoicePanel(Client client, TablePage tablePage, Size size)
        {
            _client = client;
            _tablePage = tablePage;

            BackColor = Color.Beige;
            Width = size.Width;
            Height = size.Height;

            Label.Width = size.Width;
            Label.Height = size.Height / 2;

            DefaultButton.Width = size.Width;
            DefaultButton.Height = size.Height / 2;

            DefaultButton.Top = Label.Bottom;

            DefaultButton.Click += DefaultButtonClick;

            Label.Font = _font;
            DefaultButton.Font = _font;

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
            _tablePage.ClearSelectedAndSelectableCards();
            _client.WriteAsync(decision);
        }
    }
}
