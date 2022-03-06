using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class HorridWorm : Creature
    {
        public HorridWorm() : base("Horrid Worm", 3, 2000, Common.Subtype.ParasiteWorm, Common.Civilization.Darkness)
        {
            // Whenever this creature attacks, your opponent discards a card at random from his hand.
            Abilities.Add(new AttackAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
