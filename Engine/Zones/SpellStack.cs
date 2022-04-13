using System.Collections.Generic;

namespace Engine.Zones
{
    public class SpellStack : Zone
    {
        public override void Add(ICard card, IGame game)
        {
            Cards.Add(card);
        }

        public override List<ICard> Remove(ICard card, IGame game)
        {
            Cards.Remove(card);
            return new List<ICard> { card };
        }

        public override string ToString()
        {
            return "spell stack";
        }
    }
}
