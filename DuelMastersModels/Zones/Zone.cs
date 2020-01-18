using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// A zone is an area where cards can be during a game. There are normally eight zones: deck, hand, battle zone, graveyard, mana zone, shield zone, hyperspatial zone and "super gacharange zone". Each player has their own zones except for the battle zone which is shared by each player.
    /// </summary>
    public abstract class Zone
    {
        #region Public
        /// <summary>
        /// The cards that are in the zone.
        /// </summary>
        public ReadOnlyCardCollection Cards => new ReadOnlyCardCollection(_cards);

        /// <summary>
        /// Creatures that are in the zone.
        /// </summary>
        public ReadOnlyCreatureCollection Creatures => Cards.Creatures;
        #endregion Public

        #region Internal
        #region Properties
        #region ReadOnlyCardCollection
        internal ReadOnlyCardCollection TappedCards => Cards.TappedCards;
        internal ReadOnlyCardCollection UntappedCards => Cards.UntappedCards;
        #endregion ReadOnlyCardCollection

        #region ReadOnlyCreatureCollection
        internal ReadOnlyCreatureCollection TappedCreatures => Cards.TappedCreatures;
        internal ReadOnlyCreatureCollection UntappedCreatures => Cards.UntappedCreatures;
        //internal ReadOnlyCreatureCollection NonEvolutionCreatures => Cards.NonEvolutionCreatures;
        internal ReadOnlyCreatureCollection NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone => Cards.NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone;
        #endregion ReadOnlyCreatureCollection

        /// <summary>
        /// True if the zone is public, false if it is private.
        /// 400.2a Public zone is a zone where all players can see cards that are not facing downside It is.
        /// 400.2b Private zone is not all players can see the table of cards It is a zone.
        /// </summary>
        internal abstract bool Public { get; }

        /// <summary>
        /// 400.4. The order of the cards in the shield zone or deck will be aligned unless it is effect or rule It can not be changed. Other cards in other zones, as the player wishes You can sort them. However, whether or not you tap it, the card attached to it Something must remain obvious to all players.
        /// </summary>
        internal abstract bool Ordered { get; }
        #endregion Properties

        #region Methods
        ///<summary>
        /// Adds a card to the zone.
        ///</summary>
        internal abstract void Add(Card card, Duel duel);

        ///<summary>
        /// Removes a card from the zone.
        ///</summary>
        internal abstract void Remove(Card card, Duel duel);

        internal void UntapCards()
        {
            foreach (Card card in TappedCards)
            {
                card.Tapped = false;
            }
        }
        #endregion Methods
        #endregion Internal

        private protected Collection<Card> _cards = new Collection<Card>();
    }
}
