namespace Cards.Cards.DM02
{
    class CriticalBlade : Spell
    {
        public CriticalBlade() : base("Critical Blade", 2, Common.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect());
        }
    }
}
