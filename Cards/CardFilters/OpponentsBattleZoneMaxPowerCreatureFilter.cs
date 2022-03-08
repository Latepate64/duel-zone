using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneMaxPowerCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneMaxPowerCreatureFilter(int power)
        {
            Power = new PowerFilter(CompareMode.Max, power);
        }
    }
}