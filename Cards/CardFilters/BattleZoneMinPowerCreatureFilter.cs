namespace Cards.CardFilters
{
    class BattleZoneMinPowerCreatureFilter : BattleZonePowerCreatureFilter
    {
        public BattleZoneMinPowerCreatureFilter(int power) : base(new PowerFilter(PowerMode.Min, power))
        {
        }
    }
}
