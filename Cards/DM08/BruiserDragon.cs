using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class BruiserDragon : Creature
{
    public BruiserDragon() : base("Bruiser Dragon", 5, 5000, Race.ArmoredDragon,
        Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    source: ZoneType.ShieldZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}