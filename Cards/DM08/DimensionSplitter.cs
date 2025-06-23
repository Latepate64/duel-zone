using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class DimensionSplitter : Creature
{
    public DimensionSplitter() : base("Dimension Splitter", 3, 1000, Race.BrainJacker, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DimensionSplitterEffect()));
    }
}
