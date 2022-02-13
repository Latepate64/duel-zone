using Common.Choices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    internal class ChoicePanel : Panel
    {
        internal Label _label = new() { TextAlign = ContentAlignment.MiddleCenter };
        internal Button _defaultButton = new() { Visible = false };
        internal readonly Button _declineButton = new() { Text = "Decline", Visible = false };
        private readonly Font _font = new(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
        private readonly Panel _buttonPanel = new();
        internal Client _client;
        internal TablePage _tablePage;
        private readonly ComboBox _abilityBox = new() { DropDownStyle = ComboBoxStyle.DropDownList, Visible = false };

        internal ChoicePanel()
        {
            SetupProperties();
            SetupLabel();
            SetupButtonPanel();
            SetupDefaultButton();
            SetupDeclineButton();
            _buttonPanel.Controls.Add(_abilityBox);
            _abilityBox.SelectedValueChanged += AbilityListClick;
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
            _abilityBox.Width = size.Width;
            _abilityBox.Height = size.Height / 2;
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

        private void DeclineButtonClick(object sender, EventArgs e)
        {
            if (_tablePage._currentChoice is YesNoChoice)
            {
                var decision = new YesNoDecision { Decision = false };
                _client.WriteAsync(decision);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void DefaultButtonClick(object sender, EventArgs e)
        {
            Decision decision;
            if (_tablePage._currentChoice is GuidSelection)
            {
                decision = new GuidDecision { Decision = new List<Guid>() };
            }
            else if (_tablePage._currentChoice is YesNoChoice)
            {
                decision = new YesNoDecision { Decision = true };
            }
            else
            {
                throw new NotImplementedException();
            }
            _tablePage.ClearSelectedAndSelectableCards();
            _client.WriteAsync(decision);
        }

        internal void ActivateDefaultButton(string text)
        {
            _defaultButton.Text = text;
            _defaultButton.Visible = true;
        }

        internal void ActivateDeclineButton()
        {
            _declineButton.Visible = true;
            _declineButton.Left = _defaultButton.Right;
        }

        internal void Process(AbilitySelection selection)
        {
            _abilityBox.Items.Clear();
            foreach (var ability in selection.Abilities)
            {
                _abilityBox.Items.Add(ability);
            }
            _abilityBox.Visible = true;
        }

        private void AbilityListClick(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            _client.WriteAsync(new GuidDecision { Decision = new List<Guid> { new Guid((comboBox.SelectedItem as AbilityText).Id.ToString()) } });
            comboBox.Items.Clear();
            comboBox.Visible = false;
        }
    }
}
