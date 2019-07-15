using DuelMastersModels.Cards;
using DuelMastersModels.Zones;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels
{
    public class Player
    {
        #region Properties
        /// <summary>
        /// The identifier of the player.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the cards the player is going to use in a duel.
        /// </summary>
        public Collection<Card> DeckBeforeDuel { get; } = new Collection<Card>();

        #region Zones
        public BattleZone BattleZone { get; set; }
        public Deck Deck { get; set; }
        public Graveyard Graveyard { get; set; }
        public Hand Hand { get; set; }
        public ManaZone ManaZone { get; set; }
        public ShieldZone ShieldZone { get; set; }
        #endregion Zones

        //public Collection<Abilities.Trigger.TriggerAbility> TriggerAbilities { get; } = new Collection<Abilities.Trigger.TriggerAbility>();

        //public Collection<Card> UsableShieldTriggers { get; } = new Collection<Card>();

        public Collection<Card> ShieldTriggersToUse { get; } = new Collection<Card>();
        #endregion Properties

        public Player()
        {
            BattleZone = new BattleZone(this);
            Deck = new Deck(this);
            Graveyard = new Graveyard(this);
            Hand = new Hand(this);
            ManaZone = new ManaZone(this);
            ShieldZone = new ShieldZone(this);
        }

        /// <summary>
        /// Sets the cards the player is going to use in a duel.
        /// </summary>
        public void SetDeckBeforeDuel(Collection<Card> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("cards");
            }
            foreach (Card card in cards)
            {
                DeckBeforeDuel.Add(card);
            }
        }

        /// <summary>
        /// Setups the player's deck from the cards they are going to use in a duel.
        /// </summary>
        public void SetupDeck(Duel duel)
        {
            foreach (Card card in DeckBeforeDuel)
            {
                Deck.Add(card, duel);
            }
        }

        /// <summary>
        /// Player shuffles their deck.
        /// </summary>
        public void ShuffleDeck()
        {
            Deck.Shuffle();
        }
    }
}
