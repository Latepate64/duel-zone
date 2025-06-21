namespace Cards.DM10
{
    class SupersonicJetPack : Engine.Spell
    {
        public SupersonicJetPack() : base("Supersonic Jet Pack", 1, Engine.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect());
        }
    }
}
