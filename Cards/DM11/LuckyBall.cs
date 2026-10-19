using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

sealed class LuckyBall : Creature
{
    public LuckyBall() : base("Lucky Ball", 4, 3000, Race.CyberVirus,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new DedreenTheHiddenCorrupterAbility(
                3, 
                new YouMayDrawCardsEffect(2)));
    }
}