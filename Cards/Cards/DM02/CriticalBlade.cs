namespace Cards.Cards.DM02
{
    class CriticalBlade : Engine.Spell
    {
        public CriticalBlade() : base("Critical Blade", 2, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect());
        }
    }
}
