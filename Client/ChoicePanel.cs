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
        internal Client _client;
        internal TablePage _tablePage;

        internal ChoicePanel()
        {
            SetupProperties();
            SetupLabel();
            SetupButtonPanel();
            SetupDefaultButton();
            SetupDeclineButton();
        }

        internal void UpdateSize(Size size)
        {
            Width = size.Width;
            Height = size.Height;
            _label.Width = size.Width;
            _label.Height = size.Height / 2;
            _buttonPanel.Width = size.Width;
            _buttonPanel.Height = size.Height / 2;
            _declineButton.Width = size.Width / 2;
            _declineButton.Height = size.Height / 2;
            _defaultButton.Width = size.Width / 2;
            _defaultButton.Height = size.Height / 2;
            _declineButton.Left = _defaultButton.Right;
            _buttonPanel.Top = _label.Bottom;
        }

        private void SetupButtonPanel()
        {
            Controls.Add(_buttonPanel);
        }

        private void SetupDeclineButton()
        {
            _declineButton.Click += DeclineButtonClick;
            _declineButton.Font = _font;
            _buttonPanel.Controls.Add(_declineButton);
        }

        private void SetupDefaultButton()
        {
            _defaultButton.Click += DefaultButtonClick;
            _defaultButton.Font = _font;
            _buttonPanel.Controls.Add(_defaultButton);
        }

        private void SetupProperties()
        {
            BackColor = Color.Beige;
        }

        private void SetupLabel()
        {
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
