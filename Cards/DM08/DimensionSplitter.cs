using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM08;

public sealed class DimensionSplitter : Creature
{
    public DimensionSplitter(DragonFilterFactory dragonFilterFactory) : base(
        "Dimension Splitter", 3, 1000, Race.BrainJacker, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new YouMayReturnAllCreaturesFromYourGraveyardToYourHandEffect(
                    dragonFilterFactory.Create()
                )));
    }
}
