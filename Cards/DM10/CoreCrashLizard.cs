using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class CoreCrashLizard : Creature
{
    public CoreCrashLizard() : base("Core-Crash Lizard", 7, 6000,
        Race.MeltWarrior, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ShieldBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}