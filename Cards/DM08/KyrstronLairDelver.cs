using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM08;

sealed class KyrstronLairDelver : Creature
{
    public KyrstronLairDelver(DragonFilterFactory dragonFilterFactory) : base(
        "Kyrstron, Lair Delver", 5, 1000, Race.Dragonoid, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 0,
                    controllerChooses: true,
                    filter: dragonFilterFactory.Create(),
                    source: ZoneType.Hand,
                    destination: ZoneType.BattleZone,
                    selectionRange: SelectionRange.OwnCards
                )));
    }
}
