using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableMaxPowerCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter
    {
        public OpponentsBattleZoneChoosableMaxPowerCreatureFilter(int power)
        {
            Power = new PowerFilter(CompareMode.Max, power);
        }
    }
}
