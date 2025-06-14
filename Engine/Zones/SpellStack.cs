using System.Collections.Generic;

namespace Engine.Zones
{
    public class SpellStack : Zone, ICopyable<SpellStack>
    {
        public SpellStack() : base(ZoneType.SpellStack)
        {
        }

        public SpellStack(Zone zone) : base(zone)
        {
        }

        internal override void Add(Card card, IGame game)
        {
            Cards.Add(card);
        }

        public SpellStack Copy()
        {
            return new SpellStack(this);
        }

        internal override List<Card> Remove(Card card, IGame game)
        {
            Cards.Remove(card);
            return [card];
        }
    }
}
