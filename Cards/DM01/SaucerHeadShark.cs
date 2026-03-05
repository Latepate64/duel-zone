using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class SaucerHeadShark : Creature
{
    public SaucerHeadShark() : base("Saucer-Head Shark", 5, 3000, Race.GelFish, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SaucerHeadSharkEffect()));
    }
}
