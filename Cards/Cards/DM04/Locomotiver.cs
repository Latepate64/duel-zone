using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM04
{
    public class Locomotiver : Creature
    {
        public Locomotiver() : base("Locomotiver", 4, Common.Civilization.Darkness, 1000, Common.Subtype.Hedrian)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, your opponent discards a card at random from his hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
