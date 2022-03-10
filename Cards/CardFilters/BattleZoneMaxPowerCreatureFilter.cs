using Engine;

namespace Cards.CardFilters
{
    class BattleZoneMaxPowerCreatureFilter : BattleZonePowerCreatureFilter
    {
        public BattleZoneMaxPowerCreatureFilter(int power) : base(new PowerFilter(CompareMode.Max, power))
        {
        }
    }
}
