using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM04;

sealed class DoboulgyserGiantRockBeast : EvolutionCreature
{
    public DoboulgyserGiantRockBeast() : base("Doboulgyser, Giant Rock Beast",
        6, 8000, Race.RockBeast, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MaxPowerFilter(3000),
                    source: ZoneType.BattleZone,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}