using Abilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class PhantasmalHorrorGigazald : EvolutionCreature
{
    public PhantasmalHorrorGigazald() : base("Phantasmal Horror Gigazald", 5,
        5000, Race.Chimera, Civilization.Darkness)
    {
        AddStaticAbilities(
            new EachOfYourCreaturesHasAbilityEffect(
                new TapAbility(
                    new OpponentRandomDiscardEffect()),
                new CivilizationCreatureFilter(Civilization.Darkness)));
    }
}