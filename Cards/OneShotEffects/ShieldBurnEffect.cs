using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ShieldBurnEffect : CardMovingChoiceEffect
    {
        public ShieldBurnEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public ShieldBurnEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.ShieldZone, ZoneType.Graveyard)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ShieldBurnEffect(this);
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "Put" : "Your opponent puts")} {GetAmountAsText()} {Filter} into its owner's graveyard.";
        }
    }
}
