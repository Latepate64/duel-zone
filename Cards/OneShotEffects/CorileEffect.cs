using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class CorileEffect : CardMovingChoiceEffect
    {
        public CorileEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public CorileEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Deck)
        {
        }

        public override OneShotEffect Copy()
        {
            return new CorileEffect(this);
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "put" : "your opponent puts")} {GetAmountAsText()} of {Filter} on top of its owner's deck.";
        }
    }
}
