using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM08;

public sealed class SolarGrass : TurboRushCreature
{
    const string SolarGrassName = "Solar Grass";

    public SolarGrass() : base(SolarGrassName, 5, 3000, Race.StarlightTree,
        Civilization.Light)
    {
        AddTurboRushAbility(
            new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(
                new UntapAreaOfEffect(
                    filter: new NonNameFilter(SolarGrassName),
                    selectionRange: SelectionRange.OwnCards
                )));
    }
}
