using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyMaxPowerAreaOfEffect : DestroyAreaOfEffect
    {
        private readonly int _power;

        public DestroyMaxPowerAreaOfEffect(int power) : base(new CardFilters.BattleZoneMaxPowerCreatureFilter(power))
        {
            _power = power;
        }

        public DestroyMaxPowerAreaOfEffect(DestroyMaxPowerAreaOfEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyMaxPowerAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Destroy all creatures that have power {_power} or less.";
        }
    }
}
