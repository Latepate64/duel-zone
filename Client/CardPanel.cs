using Common;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    class CardPanel : FlowLayoutPanel
    {
        const double SizeScale = 0.7;
        const int CardWidth = 222;
        const int CardHeight = 307;
        readonly Label _tapLabel;
        readonly Label _summoningSicknessLabel;

        public CardPanel(Card card)
        {
            Name = card.Id.ToString();

            Height = (int)(CardHeight * SizeScale);
            Width = (int)(CardWidth * SizeScale);

            if (card.Civilizations.Count == 1)
            {
                BackColor = GetColor(card.Civilizations.First());
            }
            else
            {
                BackColor = System.Drawing.Color.Gold;
            }

            Controls.Add(GetLabel(card.Name));
            Controls.Add(GetLabel(card.ManaCost.ToString()));
            _tapLabel = GetLabel(card.Tapped ? "Tapped" : "Untapped");
            Controls.Add(_tapLabel);
            if (card.ShieldTrigger)
            {
                Controls.Add(GetLabel("Shield trigger"));
            }

            if (card.CardType == CardType.Creature)
            {
                if (card.Subtypes.Any())
                {
                    Controls.Add(GetLabel(string.Join(" / ", card.Subtypes)));
                }
                if (card.Power.HasValue)
                {
                    Controls.Add(GetLabel(card.Power.Value.ToString()));
                }
                if (card.SummoningSickness)
                {
                    _summoningSicknessLabel = GetLabel("Summoning sickness");
                    Controls.Add(_summoningSicknessLabel);
                }
            }
        }

        private static Label GetLabel(string text)
        {
            return new Label { Text = text, Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 5, System.Drawing.FontStyle.Bold), Width = (int)(CardWidth * SizeScale) };
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
            Controls.Remove(_summoningSicknessLabel);
        }
    }
}