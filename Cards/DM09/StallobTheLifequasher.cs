using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class StallobTheLifequasher : Creature
{
    public StallobTheLifequasher() : base("Stallob, the Lifequasher", 8, 6000, Race.DemonCommand, Civilization.Darkness)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(
            new DestroyAllCreaturesEffect(new CreatureFilter())));
    }
}