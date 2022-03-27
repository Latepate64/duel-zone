namespace Cards.OneShotEffects
{
    abstract class OpponentManaRecoveryEffect : ManaRecoveryEffect
    {
        protected OpponentManaRecoveryEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, new CardFilters.OpponentsManaZoneCardFilter())
        {
        }

        protected OpponentManaRecoveryEffect(OpponentManaRecoveryEffect effect) : base(effect)
        {
        }
    }
}
