using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class OpponentManaRecoveryEffect : ManaRecoveryEffect
    {
        public OpponentManaRecoveryEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, new CardFilters.OpponentsManaZoneCardFilter())
        {
        }

        public OpponentManaRecoveryEffect(OpponentManaRecoveryEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new OpponentManaRecoveryEffect(this);
        }
    }
}
