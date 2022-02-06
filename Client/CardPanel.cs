using Common;
using Common.Choices;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    class CardPanel : Panel
    {
        const double SizeScale = 0.00065;//0.7; // 0.7/1080 = x
        const double InnerSizeScale = 0.00058;//0.63;
        const int CardWidth = 222;
        const int CardHeight = 307;
        readonly Label _tapLabel;
        readonly Label _summoningSicknessLabel;
        readonly FlowLayoutPanel _inner;
        readonly Client _client;
        readonly TablePage _tablePage;
        readonly TextBox _textBox;
        internal static int FontSize;
        const double FontScale = 0.005;

        public CardPanel(Card card, Client client, TablePage tablePage, int windowHeight)
        {
            FontSize = (int)(FontScale * windowHeight);
            _inner = new() { Height = (int)(CardHeight * InnerSizeScale * windowHeight), Width = (int)(CardWidth * InnerSizeScale * windowHeight) };

            _client = client;
            _tablePage = tablePage;

            Name = card.Id.ToString();

            Height = (int)(CardHeight * SizeScale * windowHeight);
            Width = (int)(CardWidth * SizeScale * windowHeight);
            BackColor = System.Drawing.Color.Black;
            _inner.Left = (Width - _inner.Width) / 2;
            _inner.Top = (Height - _inner.Height) / 2;

            Controls.Add(_inner);
            _inner.Anchor = AnchorStyles.None;

            if (card.Civilizations.Count == 1)
            {
                _inner.BackColor = GetColor(card.Civilizations.First());
            }
            else
            {
                _inner.BackColor = System.Drawing.Color.Gold;
            }

            _inner.Controls.Add(GetLabel(card.ManaCost.ToString() + " " + card.Name, windowHeight));
            _inner.Controls.Add(GetLabel(string.Join(" / ", card.Subtypes), windowHeight));

            _textBox = new() { Width = (int)(CardWidth * InnerSizeScale * windowHeight * 0.95), Height = (int)(CardHeight * InnerSizeScale * windowHeight * 0.6), Multiline = true, ReadOnly = true, Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, FontSize) };
            if (card.ShieldTrigger)
            {
                _textBox.Text = "Shield trigger" + Environment.NewLine + card.RulesText;
            }
            else
            {
                _textBox.Text = card.RulesText;
            }
            _inner.Controls.Add(_textBox);

            if (card.CardType == CardType.Creature && card.SummoningSickness)
            {
                _summoningSicknessLabel = GetLabel("Summoning sickness", windowHeight);
                _inner.Controls.Add(_summoningSicknessLabel);
            }
            _tapLabel = GetLabel(card.Tapped ? "Tapped" : "Untapped", windowHeight);
            _inner.Controls.Add(_tapLabel);

            if (card.Power.HasValue)
            {
                _inner.Controls.Add(GetLabel(card.Power.Value.ToString(), windowHeight));
            }

            _inner.Click += CardPanel_Click;
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
                    foreach (var card in _tablePage.SelectedCards)
                    {
                        card.BackColor = System.Drawing.Color.Black;
                    }
                    _tablePage.SelectedCards.Clear();
                    foreach (var card in _tablePage.SelectableCards)
                    {
                        card.BackColor = System.Drawing.Color.Black;
                    }
                    _tablePage.SelectableCards.Clear();
                    _client.WriteAsync(decision);
                }
            }
        }

        private static Label GetLabel(string text, int windowHeight)
        {
            return new Label { Text = text, Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, FontSize, System.Drawing.FontStyle.Bold), Width = (int)(CardWidth * InnerSizeScale * windowHeight) };
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

        internal void TapOrUntap(bool tapInsteadOfUntap)
        {
            _tapLabel.Text = tapInsteadOfUntap ? "Tapped" : "Untapped";
        }

        internal void RemoveSummoningSickness()
        {
            _inner.Controls.Remove(_summoningSicknessLabel);
        }
    }
}