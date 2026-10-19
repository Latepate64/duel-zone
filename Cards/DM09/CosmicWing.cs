using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

sealed class CosmicWing : Spell
{
    public CosmicWing() : base("Cosmic Wing", 3, Civilization.Light)
    {
        AddSpellAbilities(
            new YourChosenCreaturesCannotBeBlockedThisTurnEffect(
                minimum: 1,
                maximum: 1,
                filter: new CreatureFilter(),
                factory: new ChosenCreaturesCannotBeBlockedThisTurnEffectFactory(),
                new UntilEndOfThisTurnDuration()
            ));
    }
}