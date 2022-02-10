using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DiscardEffect : CardMovingChoiceEffect
    {
        public DiscardEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public DiscardEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.Hand, ZoneType.Graveyard)
        {
        }

        public override OneShotEffect Copy()
        {
            return new DiscardEffect(this);
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "Discard" : "Your opponent discards")} {GetAmountAsText()} {Filter}.";
        }
    }
}
