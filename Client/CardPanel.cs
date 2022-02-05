using Common;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    class CardPanel : FlowLayoutPanel
    {
        const double SizeScale = 0.7;

        public CardPanel(Card card)
        {
            Name = card.Id.ToString();

            Height = (int)(307 * SizeScale);
            Width = (int)(222 * SizeScale);

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
            
            if (card.Tapped)
            {
                Controls.Add(GetLabel("Tapped"));
            }
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
                    Controls.Add(GetLabel("Summoning sickness"));
                }
            }
        }

        private static Label GetLabel(string text)
        {
            return new Label { Text = text, Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 5, System.Drawing.FontStyle.Bold) };
        }

        private static System.Drawing.Color GetColor(Civilization civilization)
        {
            switch (civilization)
            {
                case Civilization.Light:
                    return System.Drawing.Color.Yellow;
                case Civilization.Water:
                    return System.Drawing.Color.Aqua;
                case Civilization.Darkness:
                    return System.Drawing.Color.DarkGray;
                case Civilization.Fire:
                    return System.Drawing.Color.Red;
                case Civilization.Nature:
                    return System.Drawing.Color.Green;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}