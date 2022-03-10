using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneMaxPowerCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneMaxPowerCreatureFilter(int power, params Common.Civilization[] civilizations) : base(civilizations)
        {
            Power = new PowerFilter(CompareMode.Max, power);
        }
    }
}