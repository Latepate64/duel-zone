namespace Cards.OneShotEffects
{
    class DestroyMaxPowerAreaOfEffect : DestroyAreaOfEffect
    {
        public DestroyMaxPowerAreaOfEffect(int power) : base(new CardFilters.BattleZoneMaxPowerCreatureFilter(power))
        {
        }
    }
}
