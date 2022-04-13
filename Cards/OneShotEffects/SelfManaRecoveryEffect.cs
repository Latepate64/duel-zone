namespace Cards.OneShotEffects
{
    abstract class SelfManaRecoveryEffect : ManaRecoveryEffect
    {
        /// <summary>
        /// Mana Recovery is a term given to cards that return cards in your mana zone to your hand.
        /// </summary>
        protected SelfManaRecoveryEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses)
        {
        }

        protected SelfManaRecoveryEffect(SelfManaRecoveryEffect effect) : base(effect)
        {
        }
    }
}
