using TriggeredAbilities;
using Interfaces;

namespace Cards.DM08;

public sealed class SolarGrass : TurboRushCreature
{
    public SolarGrass() : base("Solar Grass", 5, 3000, Race.StarlightTree, Civilization.Light)
    {
        AddTurboRushAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(
            new SolarGrassEffect()));
    }
}
