using TriggeredAbilities;
using OneShotEffects;
using Interfaces;

namespace Cards.DM02;

sealed class MagrisVizierOfMagnetism : Creature
{
    public MagrisVizierOfMagnetism() : base("Magris, Vizier of Magnetism", 4,
        3000, Race.Initiate, Civilization.Light)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new YouMayDrawCardsEffect(1)));
    }
}