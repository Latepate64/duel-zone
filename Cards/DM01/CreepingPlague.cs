using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01;

public sealed class CreepingPlague : Spell
{
    public CreepingPlague() : base("Creeping Plague", 1, Civilization.Darkness)
    {
        AddSpellAbilities(
            new WheneverSomethingHappensThisTurnEffect(
                new WheneverSomethingHappensThisTurnAbilityFactory(),
                new WheneverAnyOfYourCreaturesBecomesBlockedItGetsAbilityEffect(
                    new CreaturesGetAbilitiesEffectFactory(),
                    new SlayerAbility(),
                    new UntilEndOfThisTurnDuration()
                ),
                new UntilEndOfThisTurnDuration()
            ));
    }
}
