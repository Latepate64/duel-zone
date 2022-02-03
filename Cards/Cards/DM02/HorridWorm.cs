using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    public class HorridWorm : Creature
    {
        public HorridWorm() : base("Horrid Worm", 3, Common.Civilization.Darkness, 2000, Common.Subtype.ParasiteWorm)
        {
            // Whenever this creature attacks, your opponent discards a card at random from his hand.
            Abilities.Add(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
