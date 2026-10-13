using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM03;

public sealed class MuramasaDukeOfBlades : Creature
{
    public MuramasaDukeOfBlades() : base("Muramasa, Duke of Blades", 6, 3000,
        Race.Human, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(2000),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}
