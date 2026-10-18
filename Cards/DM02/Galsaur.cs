using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM02;

sealed class Galsaur : Creature
{
    public Galsaur(
        ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffectFactory factory,
        PowerAttackerAbilityFactory powerAttackerFactory,
        DoubleBreakerAbilityFactory doubleBreakerFactory)
        : base("Galsaur", 5, 4000, Race.RockBeast, Civilization.Fire)
    {
        AddStaticAbilities(
            factory.Create(
                powerAttackerFactory,
                doubleBreakerFactory,
                4000));
    }
}
