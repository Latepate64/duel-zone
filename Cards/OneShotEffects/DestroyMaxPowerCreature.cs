using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyMaxPowerCreature : DestroyEffect
    {
        private readonly int _power;

        public DestroyMaxPowerCreature(int power) : base(new CardFilters.BattleZoneChoosableMaxPowerCreatureFilter(power), 1, 1, true)
        {
            _power = power;
        }

        public DestroyMaxPowerCreature(DestroyMaxPowerCreature effect) : base(effect)
        {
            _power = effect._power;
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyMaxPowerCreature(this);
        }

        public override string ToString()
        {
            return $"Destroy a creature that has power {_power} or less.";
        }
    }
}
