using Common;
using Common.Choices;
using System;
using System.Drawing;
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

        internal static int FontSize;

        private readonly Client _client;
        private readonly TablePage _tablePage;
        private Label _tapLabel;
        private Label _summoningSicknessLabel;
        private FlowLayoutPanel _inner;
        private TextBox _textBox;
        private Label _combatLabel;

        internal CardPanel(ICard card, Client client, TablePage tablePage, int height, bool showTapStatus)
        {
            _client = client;
            _tablePage = tablePage;
            FontSize = (int)(FontScale * height);
            SetupProperties(card, height);
            if (string.IsNullOrEmpty(card.Name))
            {
                BackgroundImage = Image.FromFile(Properties.Settings.Default.CardBack);
                BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                SetupInnerPanel(height);
                PaintBackColor(card);
                DrawInformation(card, height, showTapStatus);
                SetupClick();
            }
            _combatLabel = GetLabel("", height);
        }

        private void DrawInformation(ICard card, int height, bool showTapStatus)
        {
            DrawManaCostAndName(card, height);
            DrawSubtypes(card, height);
            DrawRulesText(card, height);
            DrawSummoningSickness(card, height);
            DrawTapStatus(card, height, showTapStatus);
            DrawPower(card, height);
        }

        private void SetupProperties(ICard card, int height)
        {
            Name = card.Id.ToString();
            Height = (int)(CardHeight * SizeScale * height);
            Width = (int)(CardWidth * SizeScale * height);
            BackColor = Color.Black;
        }

        private void SetupInnerPanel(int height)
        {
            _inner = new() { Height = (int)(CardHeight * InnerSizeScale * height), Width = (int)(CardWidth * InnerSizeScale * height) };
            _inner.Left = (Width - _inner.Width) / 2;
            _inner.Top = (Height - _inner.Height) / 2;
            Controls.Add(_inner);
        }

        private void DrawPower(ICard card, int height)
        {
            if (card.Power.HasValue)
            {
                _inner.Controls.Add(GetLabel(card.Power.Value.ToString(), height));
            }
        }

        private void DrawTapStatus(ICard card, int height, bool showTapStatus)
        {
            if (showTapStatus)
            {
                _tapLabel = GetLabel(card.Tapped ? "Tapped" : "Untapped", height);
                _inner.Controls.Add(_tapLabel);
            }
        }

        private void DrawSummoningSickness(ICard card, int height)
        {
            throw new NotImplementedException();
            //if (card.CardType == CardType.Creature && card.SummoningSickness)
            //{
            //    _summoningSicknessLabel = GetLabel("Summoning sickness", height);
            //    _inner.Controls.Add(_summoningSicknessLabel);
            //}
        }

        private void DrawSubtypes(ICard card, int height)
        {
            throw new NotImplementedException();
            //_inner.Controls.Add(GetLabel(string.Join(" / ", card.Subtypes.Select(x => SplitCamelCase(x.ToString()))), height));
        }

        private void DrawManaCostAndName(ICard card, int height)
        {
            _inner.Controls.Add(GetLabel(card.ManaCost.ToString() + " " + card.Name, height));
        }

        private void DrawRulesText(ICard card, int height)
        {
            _textBox = new() { Width = (int)(CardWidth * InnerSizeScale * height * 0.95), Height = (int)(CardHeight * InnerSizeScale * height * 0.4), Multiline = true, ReadOnly = true, Font = new Font(FontFamily.GenericSansSerif, FontSize), BorderStyle = BorderStyle.None };
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

        private void PaintBackColor(ICard card)
        {
            throw new NotImplementedException();
            //if (card.Civilizations.Count == 1)
            //{
            //    _inner.BackColor = GetColor(card.Civilizations.First());
            //}
            //else
            //{
            //    _inner.BackColor = Color.Gold;
            //}
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
            if (_tablePage._currentChoice is BoundedGuidSelection guidSelection)
            {
                if (_tablePage._selectedCards.Contains(this))
                {
                    Unselect();
                }
                else
                {
                    MarkSelected();
                }
                CheckSelectedCards(guidSelection);
            }
        }

        private void CheckSelectedCards(BoundedGuidSelection guidSelection)
        {
            if (guidSelection.MaximumSelection == _tablePage._selectedCards.Count())
            {
                var decision = new GuidDecision { Decision = _tablePage._selectedCards.Select(x => new Guid(x.Name)).ToList() };
                _tablePage.ClearSelectedAndSelectableCards();
                _client.WriteAsync(decision);
            }
        }

        private void MarkSelected()
        {
            BackColor = Color.Violet;
            _tablePage._selectedCards.Add(this);
        }

        private void Unselect()
        {
            BackColor = Color.Black;
            _tablePage._selectedCards.Remove(this);
        }

        private Label GetLabel(string text, int height)
        {
            return new Label { Text = text, Font = new Font(FontFamily.GenericSansSerif, FontSize, FontStyle.Bold), Width = (int)(CardWidth * InnerSizeScale * height), Height = Height / 10 };
        }

        //private static Color GetColor(Civilization civilization)
        //{
        //    return civilization switch
        //    {
        //        Civilization.Light => Color.Yellow,
        //        Civilization.Water => Color.Aqua,
        //        Civilization.Darkness => Color.DarkGray,
        //        Civilization.Fire => Color.Red,
        //        Civilization.Nature => Color.Green,
        //        _ => throw new NotImplementedException(),
        //    };
        //}

        private static string SplitCamelCase(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }

        internal void DrawCombat(string text)
        {
            _combatLabel.Text = text;
            _inner.Controls.Add(_combatLabel);
        }

        internal void RemoveCombat()
        {
            _inner.Controls.Remove(_combatLabel);
        }
    }
}