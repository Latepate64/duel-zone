using Engine;

namespace Cards.CardFilters
{
    class BattleZonePowerCreatureFilter : BattleZoneCreatureFilter
    {
        public BattleZonePowerCreatureFilter(PowerFilter power)
        {
            Power = power;
        }
    }
}
