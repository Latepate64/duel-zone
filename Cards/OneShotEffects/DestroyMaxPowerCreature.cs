namespace Cards.OneShotEffects
{
    class DestroyMaxPowerCreature : DestroyEffect
    {
        public DestroyMaxPowerCreature(int power) : base(new CardFilters.BattleZoneChoosableMaxPowerCreatureFilter(power), 1, 1, true)
        {
        }
    }
}
