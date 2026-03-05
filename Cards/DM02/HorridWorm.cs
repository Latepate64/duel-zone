using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02
{
    sealed class HorridWorm : Creature
    {
        public HorridWorm() : base("Horrid Worm", 3, 2000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
