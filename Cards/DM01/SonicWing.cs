using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class SonicWing : Spell
{
    public SonicWing() : base("Sonic Wing", 3, Civilization.Light)
    {
        AddSpellAbilities(
            new YourChosenCreaturesCannotBeBlockedThisTurnEffect(
                minimum: 1,
                maximum: 1,
                filter: new CreatureFilter(),
                factory: new ChosenCreaturesCannotBeBlockedThisTurnEffectFactory()
            ));
    }
}
