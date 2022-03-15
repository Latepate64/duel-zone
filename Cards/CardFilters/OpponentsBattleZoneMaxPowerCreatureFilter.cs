using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneMaxPowerCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneMaxPowerCreatureFilter(int power) : base()
        {
            Power = new PowerFilter(CompareMode.Max, power);
        }

        public OpponentsBattleZoneMaxPowerCreatureFilter(OpponentsBattleZoneMaxPowerCreatureFilter filter) : base(filter)
        {
        }
    }
}