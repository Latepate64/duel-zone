namespace Cards.Cards.DM01
{
    class CrimsonHammer : Spell
    {
        public CrimsonHammer() : base("Crimson Hammer", 2, Engine.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000));
        }
    }
}
