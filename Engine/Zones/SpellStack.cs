using System.Collections.Generic;

namespace Engine.Zones
{
    public class SpellStack : Zone, ICopyable<SpellStack>
    {
        public SpellStack() : base(ZoneType.SpellStack)
        {
        }

        public SpellStack(IZone zone) : base(zone)
        {
        }

        public override void Add(ICard card, IGame game)
        {
            Cards.Add(card);
        }

        public SpellStack Copy()
        {
            return new SpellStack(this);
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
