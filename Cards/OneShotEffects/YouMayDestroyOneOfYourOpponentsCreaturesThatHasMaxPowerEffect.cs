using Cards.CardFilters;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect : OneShotEffects.DestroyEffect
    {
        private readonly int _power;

        public YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(int power) : base(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(power), 0, 1, true)
        {
            _power = power;
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(this);
        }

        public override string ToString()
        {
            return $"You may destroy one of your opponent's creatures that has power {_power} or less.";
        }
    }
}
