using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class SteamRumblerKain : Creature
{
    public SteamRumblerKain() : base("Steam Rumbler Kain", 4, 5000,
        Race.Armorloid, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
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