using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class RaptorFish : Creature
{
    public RaptorFish() : base("Raptor Fish", 6, 3000, Race.GelFish, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new RaptorFishEffect()));
    }
}
