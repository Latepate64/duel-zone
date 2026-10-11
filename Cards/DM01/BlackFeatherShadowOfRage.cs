using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class BlackFeatherShadowOfRage : Creature
{
    public BlackFeatherShadowOfRage() : base("Black Feather, Shadow of Rage", 1,
        3000, Race.Ghost, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OwnCreatures
                )));
    }
}