using TriggeredAbilities;
using OneShotEffects;
using StaticAbilities;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class ExplosiveFighterUcarn : Creature
{
    public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, 9000,
        Race.Dragonoid, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                    minimum: 2,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    source: ZoneType.ManaZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OwnCards
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}