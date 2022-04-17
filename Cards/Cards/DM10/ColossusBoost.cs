namespace Cards.Cards.DM10
{
    class ColossusBoost : Spell
    {
        public ColossusBoost() : base("Colossus Boost", 1, Engine.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsUntilTheEndOfTheTurnEffect(4000));
        }
    }
}
