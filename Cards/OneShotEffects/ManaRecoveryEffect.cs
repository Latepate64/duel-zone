using Common;
using Engine;

namespace Cards.OneShotEffects
{
    abstract class ManaRecoveryEffect : CardMovingChoiceEffect
    {
        protected ManaRecoveryEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        protected ManaRecoveryEffect(int minimum, int maximum, bool controllerChooses, CardFilter filter) : base(filter, minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Hand)
        {
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "Return" : "Your opponent returns")} {GetAmountAsText()} {Filter} to their owner's hand.";
        }
    }
}
