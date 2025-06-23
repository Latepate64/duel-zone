using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class SparkChemistShadowOfWhim : Creature
{
    public SparkChemistShadowOfWhim() : base(
        "Spark Chemist, Shadow of Whim", 2, 3000, Race.Ghost, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SparkChemistShadowOfWhimEffect()));
    }
}
