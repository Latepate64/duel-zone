namespace Cards.DM10
{
    sealed class ColossusBoost : Engine.Spell
    {
        public ColossusBoost() : base("Colossus Boost", 1, Interfaces.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(4000));
        }
    }
}
