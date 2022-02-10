using Common.Choices;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    internal class ChoicePanel : Panel
    {
        readonly Font _font = new(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
        readonly internal Label Label = new() { TextAlign = ContentAlignment.MiddleCenter };
        readonly internal Button DefaultButton = new() { Text = "Pass", Visible = false };
        readonly internal Button DeclineButton = new() { Text = "Decline", Visible = false };
        readonly private FlowLayoutPanel ButtonPanel = new() { FlowDirection = FlowDirection.LeftToRight };
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

            ButtonPanel.Width = size.Width;
            ButtonPanel.Height = size.Height / 2;

            ButtonPanel.Top = Label.Bottom;

            DefaultButton.Click += DefaultButtonClick;
            DeclineButton.Click += DeclineButtonClick;

            Label.Font = _font;
            DefaultButton.Font = _font;
            DeclineButton.Font = _font;

            DefaultButton.Width = ButtonPanel.Width / 2;
            DefaultButton.Height = ButtonPanel.Height / 2;

            DeclineButton.Width = ButtonPanel.Width / 2;
            DeclineButton.Height = ButtonPanel.Height / 2;
            DeclineButton.Left = DefaultButton.Right;

            ButtonPanel.Controls.Add(DefaultButton);
            ButtonPanel.Controls.Add(DeclineButton);

            Controls.Add(Label);
            Controls.Add(ButtonPanel);
        }

        private void DeclineButtonClick(object sender, System.EventArgs e)
        {
            if (_tablePage.CurrentChoice is YesNoChoice)
            {
                var decision = new YesNoDecision { Decision = false };
                _client.WriteAsync(decision);
            }
            else
            {
                throw new System.NotImplementedException();
            }
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
