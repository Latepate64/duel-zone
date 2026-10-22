using ContinuousEffects.Replacement;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

sealed class RootCharger : Charger
{
    public RootCharger() : base("Root Charger", 3, Civilization.Nature)
    {
        AddSpellAbilities(
            new ContinuousEffectAddingEffect(
                new WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(),
                new UntilEndOfThisTurnDuration()
            ));
    }
}