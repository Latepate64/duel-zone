using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    public class ManaRecoveryEffect : CardMovingChoiceEffect
    {
        /// <summary>
        /// Mana Recovery is a term given to cards that return cards in your mana zone to your hand.
        /// </summary>
        public ManaRecoveryEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Hand)
        {
        }

        public ManaRecoveryEffect(ManaRecoveryEffect effect) : base(effect)
        {
        }

        //you may return a creature from your mana zone to your hand
        public override string ToString()
        {
            return $"{(ControllerChooses ? "return" : "your opponent returns")} {GetAmountAsText()} {Filter} to their owner's hand.";
        }

        public override OneShotEffect Copy()
        {
            return new ManaRecoveryEffect(this);
        }
    }
}
