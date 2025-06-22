using TriggeredAbilities;
using Interfaces;

namespace Cards.DM11;

public sealed class DiamondiaTheBlizzardRider : EvolutionCreature
{
    public DiamondiaTheBlizzardRider() : base(
        "Diamondia, the Blizzard Rider", 3, 5000, Race.SnowFaerie, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DiamondiaTheBlizzardRiderEffect()));
    }
}
