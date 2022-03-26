using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect : DestroyEffect
    {
        private readonly int _power;

        public DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(int power) : base(new CardFilters.OpponentsBattleZoneChoosableMaxPowerCreatureFilter(power), 1, 1, true)
        {
            _power = power;
        }

        public DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(this);
        }

        public override string ToString()
        {
            return $"Destroy one of your opponent's creatures that has power {_power} or less.";
        }
    }
}
