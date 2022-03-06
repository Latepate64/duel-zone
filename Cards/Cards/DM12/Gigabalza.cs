using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM12
{
    class Gigabalza : Creature
    {
        public Gigabalza() : base("Gigabalza", 4, 1000, Common.Subtype.Chimera, Common.Civilization.Darkness)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, your opponent discards a card at random from his hand.
            AddAbilities(new PutIntoPlayAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
