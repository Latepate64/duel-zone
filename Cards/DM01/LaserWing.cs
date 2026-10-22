using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class LaserWing : Spell
{
    public LaserWing() : base("Laser Wing", 5, Civilization.Light)
    {
        AddSpellAbilities(
            new YourChosenCreaturesCannotBeBlockedEffect(
                minimum: 0,
                maximum: 2,
                filter: new CreatureFilter(),
                factory: new ChosenCreaturesCannotBeBlockedEffectFactory(),
                new UntilEndOfThisTurnDuration()
            ));
    }
}
