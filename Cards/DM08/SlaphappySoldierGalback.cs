using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class SlaphappySoldierGalback : TurboRushCreature
{
    public SlaphappySoldierGalback() : base("Slaphappy Soldier Galback", 4,
        3000, Race.Dragonoid, Civilization.Fire)
    {
        AddTurboRushAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(4000),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OpponentsCards
                )));
    }
}