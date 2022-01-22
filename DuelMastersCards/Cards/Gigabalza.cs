using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Gigabalza : Creature
    {
        public Gigabalza() : base("Gigabalza", 4, Civilization.Darkness, 1000, Subtype.Chimera)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, your opponent discards a card at random from his hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
