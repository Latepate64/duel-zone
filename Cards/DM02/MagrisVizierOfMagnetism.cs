using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM02
{
    sealed class MagrisVizierOfMagnetism : Engine.Creature
    {
        public MagrisVizierOfMagnetism() : base("Magris, Vizier of Magnetism", 4, 3000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawCardEffect()));
        }
    }
}
