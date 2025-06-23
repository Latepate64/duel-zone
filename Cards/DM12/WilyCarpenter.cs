using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class WilyCarpenter : Creature
{
    public WilyCarpenter() : base("Wily Carpenter", 3, 1000, Race.Merfolk, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new WilyCarpenterEffect()));
    }
}
