namespace Cards.Cards.DM02
{
    class CriticalBlade : Spell
    {
        public CriticalBlade() : base("Critical Blade", 2, Common.Civilization.Darkness)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect());
        }
    }
}
