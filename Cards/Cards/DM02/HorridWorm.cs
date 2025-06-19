using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class HorridWorm : Creature
    {
        public HorridWorm() : base("Horrid Worm", 3, 2000, Engine.Race.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
