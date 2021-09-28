﻿using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// A zone is an area where cards can be during a game. There are normally eight zones: deck, hand, battle zone, graveyard, mana zone, shield zone, hyperspatial zone and "super gacharange zone". Each player has their own zones except for the battle zone which is shared by each player.
    /// </summary>
    public abstract class Zone : System.IDisposable
    {
        protected Zone(IEnumerable<Card> cards)
        {
            Cards = new List<Card>(cards.ToList());
        }

        public List<Card> Cards { get; private set; }

        public IEnumerable<Card> Creatures => Cards.Where(x => x.CardType == CardType.Creature);

        #region Internal
        #region Properties
        #region ReadOnlyCreatureCollection
        //internal ReadOnlyCreatureCollection NonEvolutionCreatures => Cards.NonEvolutionCreatures;
        //internal ReadOnlyCreatureCollection<IZoneCreature> NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone => new ReadOnlyCreatureCollection<IZoneCreature>(Cards.NonEvolutionCreaturesThatCostTheSameAsOrLessThanTheNumberOfCardsInTheZone.Where(c => c is Card));
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
        public abstract void Add(Card card, Duel duel);

        ///<summary>
        /// Removes a card from the zone.
        ///</summary>
        public abstract void Remove(Card card);
        #endregion Methods
        #endregion Internal

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Cards != null)
            {
                foreach (var card in Cards)
                {
                    card.Dispose();
                }
                Cards = null;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}
