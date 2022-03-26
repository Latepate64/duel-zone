using Engine;

namespace Cards.OneShotEffects
{
    abstract class SelfManaRecoveryEffect : ManaRecoveryEffect
    {
        /// <summary>
        /// Mana Recovery is a term given to cards that return cards in your mana zone to your hand.
        /// </summary>
        protected SelfManaRecoveryEffect(int minimum, int maximum, bool controllerChooses, CardFilter filter) : base(minimum, maximum, controllerChooses, filter)
        {
        }

        protected SelfManaRecoveryEffect(SelfManaRecoveryEffect effect) : base(effect)
        {
        }
    }
}
