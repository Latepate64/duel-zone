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
        public BattleZone BattleZone { get; set; } = new BattleZone();
        public Deck Deck { get; set; } = new Deck();
        public Graveyard Graveyard { get; set; } = new Graveyard();
        public Hand Hand { get; set; } = new Hand();
        public ManaZone ManaZone { get; set; } = new ManaZone();
        public ShieldZone ShieldZone { get; set; } = new ShieldZone();
        #endregion Zones
        #endregion Properties

        /// <summary>
        /// Sets the cards the player is going to use in a duel.
        /// </summary>
        public void SetDeckBeforeDuel(Collection<Card> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("cards");
            }
            foreach (var card in cards)
            {
                DeckBeforeDuel.Add(card);
            }
        }

        /// <summary>
        /// Setups the player's deck from the cards they are going to use in a duel.
        /// </summary>
        public void SetupDeck()
        {
            foreach (var card in DeckBeforeDuel)
            {
                Deck.Add(card);
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
