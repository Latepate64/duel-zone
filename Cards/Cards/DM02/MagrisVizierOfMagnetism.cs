using Abilities.Triggered;
using OneShotEffects;

namespace Cards.Cards.DM02
{
    class MagrisVizierOfMagnetism : Engine.Creature
    {
        public MagrisVizierOfMagnetism() : base("Magris, Vizier of Magnetism", 4, 3000, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawCardEffect()));
        }
    }
}
