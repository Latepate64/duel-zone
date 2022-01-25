using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM04
{
    public class Locomotiver : Creature
    {
        public Locomotiver() : base("Locomotiver", 4, Civilization.Darkness, 1000, Subtype.Hedrian)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, your opponent discards a card at random from his hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
