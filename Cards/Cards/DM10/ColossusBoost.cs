namespace Cards.Cards.DM10
{
    public class ColossusBoost : Spell
    {
        public ColossusBoost() : base("Colossus Boost", 1, Engine.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(4000));
        }
    }
}
