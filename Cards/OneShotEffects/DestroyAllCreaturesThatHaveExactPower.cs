using Cards.CardFilters;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyAllCreaturesThatHaveExactPower : DestroyAreaOfEffect
    {
        private readonly int _power;

        public DestroyAllCreaturesThatHaveExactPower(int power) : base(new BattleZoneExactPowerCreatureFilter(1000))
        {
        }

        public DestroyAllCreaturesThatHaveExactPower(DestroyAllCreaturesThatHaveExactPower effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyAllCreaturesThatHaveExactPower(this);
        }

        public override string ToString()
        {
            return $"Destroy all creatures that have power {_power}.";
        }
    }
}
