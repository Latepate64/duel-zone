using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM08;

public class DimensionSplitter : Creature
{
    public DimensionSplitter() : base("Dimension Splitter", 3, 1000, Race.BrainJacker, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DimensionSplitterEffect()));
    }
}
