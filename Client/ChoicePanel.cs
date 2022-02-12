using Common.Choices;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    internal class ChoicePanel : Panel
    {
        internal Label _label = new() { TextAlign = ContentAlignment.MiddleCenter };
        internal Button _defaultButton = new() { Text = "Pass", Visible = false };
        internal readonly Button _declineButton = new() { Text = "Decline", Visible = false };
        private readonly Font _font = new(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
        private readonly FlowLayoutPanel _buttonPanel = new() { FlowDirection = FlowDirection.LeftToRight };
        private readonly Client _client;
        private readonly TablePage _tablePage;

        internal ChoicePanel(Client client, TablePage tablePage, Size size)
        {
            _client = client;
            _tablePage = tablePage;
            SetupProperties(size);
            SetupLabel(size);
            SetupButtonPanel(size);
            SetupDefaultButton();
            SetupDeclineButton();
        }

        private void SetupButtonPanel(Size size)
        {
            _buttonPanel.Width = size.Width;
            _buttonPanel.Height = size.Height / 2;
            _buttonPanel.Top = _label.Bottom;
            Controls.Add(_buttonPanel);
        }

        private void SetupDeclineButton()
        {
            _declineButton.Click += DeclineButtonClick;
            _declineButton.Font = _font;
            _declineButton.Width = _buttonPanel.Width / 2;
            _declineButton.Height = _buttonPanel.Height / 2;
            _declineButton.Left = _defaultButton.Right;
            _buttonPanel.Controls.Add(_declineButton);
        }

        private void SetupDefaultButton()
        {
            _defaultButton.Click += DefaultButtonClick;
            _defaultButton.Font = _font;
            _defaultButton.Width = _buttonPanel.Width / 2;
            _defaultButton.Height = _buttonPanel.Height / 2;
            _buttonPanel.Controls.Add(_defaultButton);
        }

        private void SetupProperties(Size size)
        {
            BackColor = Color.Beige;
            Width = size.Width;
            Height = size.Height;
        }

        private void SetupLabel(Size size)
        {
            _label.Width = size.Width;
            _label.Height = size.Height / 2;
            _label.Font = _font;
            Controls.Add(_label);
        }

        private void DeclineButtonClick(object sender, System.EventArgs e)
        {
            if (_tablePage._currentChoice is YesNoChoice)
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
            if (_tablePage._currentChoice is GuidSelection)
            {
                decision = new GuidDecision { Decision = new System.Collections.Generic.List<System.Guid>() };
            }
            else if (_tablePage._currentChoice is YesNoChoice)
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
