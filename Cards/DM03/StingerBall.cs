using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM03;

sealed class StingerBall : Creature
{
    public StingerBall() : base("Stinger Ball", 3, 1000, Race.CyberVirus,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new LookEffect(0, 1)));
    }
}