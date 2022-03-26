using Cards.OneShotEffects;

namespace Cards.Cards.DM10
{
    class SupersonicJetPack : Spell
    {
        public SupersonicJetPack() : base("Supersonic Jet Pack", 1, Common.Civilization.Fire)
        {
            AddSpellAbilities(new OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect());
        }
    }
}
