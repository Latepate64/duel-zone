using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class ExplosiveTrooperZalmez : Creature
{
    public ExplosiveTrooperZalmez() : base("Explosive Trooper Zalmez", 3, 2000,
        Race.Armorloid, Civilization.Fire)
    {
        AddTriggeredAbility(
            new DedreenTheHiddenCorrupterAbility(
                shieldsMaximum: 2, 
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(3000),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OpponentsCards
                )));
    }
}