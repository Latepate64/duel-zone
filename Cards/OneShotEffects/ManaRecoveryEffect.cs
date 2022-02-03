using Common;
using Engine;

namespace Cards.OneShotEffects
{
    class ManaRecoveryEffect : CardMovingChoiceEffect
    {
        /// <summary>
        /// Mana Recovery is a term given to cards that return cards in your mana zone to your hand.
        /// </summary>
        public ManaRecoveryEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Hand)
        {
        }
    }
}
