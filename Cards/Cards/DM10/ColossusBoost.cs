using Common;

namespace Cards.Cards.DM10
{
    class ColossusBoost : Spell
    {
        public ColossusBoost() : base("Colossus Boost", 1, Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsUntilTheEndOfTheTurnEffect(4000));
        }
    }
}
