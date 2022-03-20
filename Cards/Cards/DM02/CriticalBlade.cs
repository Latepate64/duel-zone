namespace Cards.Cards.DM02
{
    class CriticalBlade : Spell
    {
        public CriticalBlade() : base("Critical Blade", 2, Common.Civilization.Darkness)
        {
            ShieldTrigger = true;

            // Destroy one of your opponent's creatures that has "blocker."
            AddSpellAbilities(new OneShotEffects.DestroyEffect(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 1, 1, true));
        }
    }
}
