namespace Cards.CardFilters
{
    class BattleZoneExactPowerCreatureFilter : BattleZonePowerCreatureFilter
    {
        public BattleZoneExactPowerCreatureFilter(int power) : base(new PowerFilter(PowerMode.Exact, power))
        {
        }
    }
}
