using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM09;

public sealed class BatDoctorShadowOfUndeath : Creature
{
    public BatDoctorShadowOfUndeath() : base(
        "Bat Doctor, Shadow of Undeath", 3, 2000, Race.Ghost,
            Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCreatures,
                    excludeSource: true
        )));
    }
}
