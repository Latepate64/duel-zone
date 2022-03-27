namespace Cards.Cards.DM10
{
    class SupersonicJetPack : Spell
    {
        public SupersonicJetPack() : base("Supersonic Jet Pack", 1, Common.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(new StaticAbilities.SpeedAttackerAbility()));
        }
    }
}
