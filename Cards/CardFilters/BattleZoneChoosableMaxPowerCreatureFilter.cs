using Engine;

namespace Cards.CardFilters
{
    class BattleZoneChoosableMaxPowerCreatureFilter : BattleZoneChoosableCreatureFilter
    {
        public BattleZoneChoosableMaxPowerCreatureFilter(int power)
        {
            Power = new PowerFilter(CompareMode.Max, power);
        }
    }
}
