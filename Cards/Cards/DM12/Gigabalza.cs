using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM12
{
    public class Gigabalza : Creature
    {
        public Gigabalza() : base("Gigabalza", 4, Common.Civilization.Darkness, 1000, Common.Subtype.Chimera)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, your opponent discards a card at random from his hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
