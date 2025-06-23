namespace Cards.DM02
{
    sealed class CriticalBlade : Spell
    {
        public CriticalBlade() : base("Critical Blade", 2, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect());
        }
    }
}
