using Common;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    class CardPanel : Panel
    {
        const double SizeScale = 0.7;
        const double InnerSizeScale = 0.63;
        const int CardWidth = 222;
        const int CardHeight = 307;
        readonly Label _tapLabel;
        readonly Label _summoningSicknessLabel;
        readonly FlowLayoutPanel _inner = new() { Height = (int)(CardHeight * InnerSizeScale), Width = (int)(CardWidth * InnerSizeScale) };

        public CardPanel(Card card)
        {
            Name = card.Id.ToString();

            Height = (int)(CardHeight * SizeScale);
            Width = (int)(CardWidth * SizeScale);
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

            _inner.Controls.Add(GetLabel(card.Name));
            _inner.Controls.Add(GetLabel(card.ManaCost.ToString()));
            _tapLabel = GetLabel(card.Tapped ? "Tapped" : "Untapped");
            _inner.Controls.Add(_tapLabel);
            if (card.ShieldTrigger)
            {
                _inner.Controls.Add(GetLabel("Shield trigger"));
            }

            if (card.CardType == CardType.Creature)
            {
                if (card.Subtypes.Any())
                {
                    _inner.Controls.Add(GetLabel(string.Join(" / ", card.Subtypes)));
                }
                if (card.Power.HasValue)
                {
                    _inner.Controls.Add(GetLabel(card.Power.Value.ToString()));
                }
                if (card.SummoningSickness)
                {
                    _summoningSicknessLabel = GetLabel("Summoning sickness");
                    _inner.Controls.Add(_summoningSicknessLabel);
                }
            }
        }

        private static Label GetLabel(string text)
        {
            return new Label { Text = text, Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 5, System.Drawing.FontStyle.Bold), Width = (int)(CardWidth * InnerSizeScale) };
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