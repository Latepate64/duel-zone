﻿using Common;
using Common.Choices;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    internal class CardPanel : Panel
    {
        private const double SizeScale = 0.0030875;
        private const double InnerSizeScale = 0.002755;
        private const double FontScale = 0.03;
        private const int CardWidth = 222;
        private const int CardHeight = 307;

        internal static int _fontSize;
        private readonly Client _client;
        private readonly TablePage _tablePage;
        private Label _tapLabel;
        private Label _summoningSicknessLabel;
        private FlowLayoutPanel _inner;
        private TextBox _textBox;

        internal CardPanel(Card card, Client client, TablePage tablePage, int height, bool showTapStatus)
        {
            _client = client;
            _tablePage = tablePage;
            _fontSize = (int)(FontScale * height);
            SetupProperties(card, height);
            SetupInnerPanel(height);
            PaintBackColor(card);
            DrawManaCostAndName(card, height);
            DrawSubtypes(card, height);
            DrawRulesText(card, height);
            DrawSummoningSickness(card, height);
            DrawTapStatus(card, height, showTapStatus);
            DrawPower(card, height);
            SetupClick();
        }

        private void SetupProperties(Card card, int height)
        {
            Name = card.Id.ToString();
            Height = (int)(CardHeight * SizeScale * height);
            Width = (int)(CardWidth * SizeScale * height);
            BackColor = System.Drawing.Color.Black;
        }

        private void SetupInnerPanel(int height)
        {
            _inner = new() { Height = (int)(CardHeight * InnerSizeScale * height), Width = (int)(CardWidth * InnerSizeScale * height) };
            _inner.Left = (Width - _inner.Width) / 2;
            _inner.Top = (Height - _inner.Height) / 2;
            Controls.Add(_inner);
        }

        private void DrawPower(Card card, int height)
        {
            if (card.Power.HasValue)
            {
                _inner.Controls.Add(GetLabel(card.Power.Value.ToString(), height));
            }
        }

        private void DrawTapStatus(Card card, int height, bool showTapStatus)
        {
            if (showTapStatus)
            {
                _tapLabel = GetLabel(card.Tapped ? "Tapped" : "Untapped", height);
                _inner.Controls.Add(_tapLabel);
            }
        }

        private void DrawSummoningSickness(Card card, int height)
        {
            if (card.CardType == CardType.Creature && card.SummoningSickness)
            {
                _summoningSicknessLabel = GetLabel("Summoning sickness", height);
                _inner.Controls.Add(_summoningSicknessLabel);
            }
        }

        private void DrawSubtypes(Card card, int height)
        {
            _inner.Controls.Add(GetLabel(string.Join(" / ", card.Subtypes.Select(x => SplitCamelCase(x.ToString()))), height));
        }

        private void DrawManaCostAndName(Card card, int height)
        {
            _inner.Controls.Add(GetLabel(card.ManaCost.ToString() + " " + card.Name, height));
        }

        private void DrawRulesText(Card card, int height)
        {
            _textBox = new() { Width = (int)(CardWidth * InnerSizeScale * height * 0.95), Height = (int)(CardHeight * InnerSizeScale * height * 0.4), Multiline = true, ReadOnly = true, Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, _fontSize), BorderStyle = BorderStyle.None };
            if (card.ShieldTrigger)
            {
                _textBox.Text = "Shield trigger" + Environment.NewLine + card.RulesText?.Replace("\n", Environment.NewLine);
            }
            else
            {
                _textBox.Text = card.RulesText?.Replace("\n", Environment.NewLine);
            }
            _inner.Controls.Add(_textBox);
        }

        private void PaintBackColor(Card card)
        {
            if (card.Civilizations.Count == 1)
            {
                _inner.BackColor = GetColor(card.Civilizations.First());
            }
            else
            {
                _inner.BackColor = System.Drawing.Color.Gold;
            }
        }

        internal void TapOrUntap(bool tapInsteadOfUntap)
        {
            _tapLabel.Text = tapInsteadOfUntap ? "Tapped" : "Untapped";
        }

        internal void RemoveSummoningSickness()
        {
            _inner.Controls.Remove(_summoningSicknessLabel);
        }

        private void SetupClick()
        {
            Click += CardPanel_Click;
            _inner.Click += CardPanel_Click;
            foreach (Control control in _inner.Controls)
            {
                control.Click += CardPanel_Click;
            }
        }

        private void CardPanel_Click(object sender, EventArgs e)
        {
            if (_tablePage.CurrentChoice is GuidSelection guidSelection)
            {
                if (_tablePage.SelectedCards.Contains(this))
                {
                    BackColor = System.Drawing.Color.Black;
                    _tablePage.SelectedCards.Remove(this);
                }
                else
                {
                    BackColor = System.Drawing.Color.Violet;
                    _tablePage.SelectedCards.Add(this);
                }
                if (guidSelection.MaximumSelection == _tablePage.SelectedCards.Count())
                {
                    var decision = new GuidDecision { Decision = _tablePage.SelectedCards.Select(x => new Guid(x.Name)).ToList() };
                    _tablePage.ClearSelectedAndSelectableCards();
                    _client.WriteAsync(decision);
                }
            }
        }

        private Label GetLabel(string text, int height)
        {
            return new Label { Text = text, Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, _fontSize, System.Drawing.FontStyle.Bold), Width = (int)(CardWidth * InnerSizeScale * height), Height = Height / 10 };
        }

        private static System.Drawing.Color GetColor(Civilization civilization)
        {
            return civilization switch
            {
                Civilization.Light => System.Drawing.Color.Yellow,
                Civilization.Water => System.Drawing.Color.Aqua,
                Civilization.Darkness => System.Drawing.Color.DarkGray,
                Civilization.Fire => System.Drawing.Color.Red,
                Civilization.Nature => System.Drawing.Color.Green,
                _ => throw new NotImplementedException(),
            };
        }

        private static string SplitCamelCase(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }
    }
}