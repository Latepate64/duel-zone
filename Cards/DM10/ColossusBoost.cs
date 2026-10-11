using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class ColossusBoost : Spell
{
    public ColossusBoost() : base("Colossus Boost", 1, Civilization.Fire)
    {
        AddSpellAbilities(
            new OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(
                4000, new CreatureFilter()));
    }
}