using OneShotEffects;
using Abilities.Triggered;

namespace Cards.Cards.DM02
{
    class HorridWorm : Engine.Creature
    {
        public HorridWorm() : base("Horrid Worm", 3, 2000, Engine.Race.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
