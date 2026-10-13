using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class Aeropica : Creature
{
    public Aeropica() : base("Aeropica", 7, 4000, Race.SeaHacker,
        Civilization.Water)
    {
        AddAbilities(
            new TapAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.AllCards
        )));
    }
}