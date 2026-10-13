using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class SabermaskScarab : Creature
{
    public SabermaskScarab() : base("Sabermask Scarab", 4, 4000,
        Race.GiantInsect, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    source: ZoneType.ManaZone,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCards
        )));
    }
}