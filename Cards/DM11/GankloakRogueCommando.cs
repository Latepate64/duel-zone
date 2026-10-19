using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class GankloakRogueCommando : SilentSkillCreature
{
    public GankloakRogueCommando(
        EachOfYourCreaturesGetsAbilityEffectFactory oneShotEffectFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory,
        CivilizationCreatureFilterFactory creatureFilterFactory,
        ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffectFactory continuousEffectFactory
    ) : base("Gankloak, Rogue Commando", 3, 2000, Race.Human,
        Civilization.Fire)
    {
        AddSilentSkillAbility(
            oneShotEffectFactory.Create(
                creatureFilterFactory.Create(Civilization.Fire),
                continuousEffectFactory,
                new UntilEndOfThisTurnDuration(),
                doubleBreakerAbilityFactory.Create()
            )
        );
    }
}
