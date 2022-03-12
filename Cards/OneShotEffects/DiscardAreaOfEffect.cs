using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DiscardAreaOfEffect : CardMovingAreaOfEffect
    {
        public DiscardAreaOfEffect(CardFilter filter) : base(ZoneType.Hand, ZoneType.Graveyard, filter)
        {
        }

        public DiscardAreaOfEffect(DiscardAreaOfEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new DiscardAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Discard {Filter}.";
        }
    }
}