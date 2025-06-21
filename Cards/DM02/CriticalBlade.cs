namespace Cards.DM02
{
    class CriticalBlade : Engine.Spell
    {
        public CriticalBlade() : base("Critical Blade", 2, Interfaces.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect());
        }
    }
}
