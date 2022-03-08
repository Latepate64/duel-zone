using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneMaxPowerCreatureFilter : OwnersBattleZoneCreatureFilter
    {
        public OwnersBattleZoneMaxPowerCreatureFilter(int power)
        {
            Power = new PowerFilter(CompareMode.Max, power);
        }
    }
}
