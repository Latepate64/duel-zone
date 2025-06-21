namespace Cards.DM10
{
    class ColossusBoost : Engine.Spell
    {
        public ColossusBoost() : base("Colossus Boost", 1, Engine.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(4000));
        }
    }
}
