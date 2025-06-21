namespace Cards.DM10
{
    class SupersonicJetPack : Engine.Spell
    {
        public SupersonicJetPack() : base("Supersonic Jet Pack", 1, Interfaces.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect());
        }
    }
}
