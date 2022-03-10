using Engine;

namespace Cards.CardFilters
{
    class BattleZoneMinPowerCreatureFilter : BattleZonePowerCreatureFilter
    {
        public BattleZoneMinPowerCreatureFilter(int power) : base(new PowerFilter(CompareMode.Min, power))
        {
        }
    }
}
