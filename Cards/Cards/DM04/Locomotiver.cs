using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM04
{
    class Locomotiver : Creature
    {
        public Locomotiver() : base("Locomotiver", 4, 1000, Common.Subtype.Hedrian, Common.Civilization.Darkness)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, your opponent discards a card at random from his hand.
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
