using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM07;

sealed class AstronautSkyterror : Creature
{
    public AstronautSkyterror(
        ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffectFactory factory,
        PowerAttackerAbilityFactory powerAttackerFactory,
        DoubleBreakerAbilityFactory doubleBreakerFactory)
        : base("Astronaut Skyterror", 5, 4000, Race.ArmoredWyvern, Civilization.Fire)
    {
        AddStaticAbilities(
            factory.Create(
                powerAttackerFactory,
                doubleBreakerFactory,
                4000));
    }
}