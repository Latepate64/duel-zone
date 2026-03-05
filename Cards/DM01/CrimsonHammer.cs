namespace Cards.DM01
{
    sealed class CrimsonHammer : Spell
    {
        public CrimsonHammer() : base("Crimson Hammer", 2, Interfaces.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000));
        }
    }
}
