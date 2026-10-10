using TriggeredAbilities;
using Interfaces;
using ContinuousEffects.Unblockable;
using Abilities.Static;
using CardFilters;
using OneShotEffects;

namespace Cards.DM12;

sealed class CruelNagaAvatarOfFate : VortexEvolutionCreature
{
    public CruelNagaAvatarOfFate() : base("Cruel Naga, Avatar of Fate", 6,
        9000, Civilization.Water, Civilization.Darkness, Race.Naga,
        Race.Merfolk, Race.Chimera)
    {
        AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(new WhenThisCreatureLeavesBattleZoneAbility(
            new DestroyAllCreaturesEffect(new CreatureFilter())));
    }
}