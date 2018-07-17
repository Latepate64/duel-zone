using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Zones
{
    public abstract class Zone
    {
        /// <summary>
        /// The cards that are in the zone.
        /// </summary>
        public Collection<Card> Cards { get; } = new Collection<Card>();

        /// <summary>
        /// True if the zone is public, false if it is private.
        /// 400.2a Public zone is a zone where all players can see cards that are not facing downside It is.
        /// 400.2b Private zone is not all players can see the table of cards It is a zone.
        /// </summary>
        public abstract bool Public { get; }

        /// <summary>
        /// 400.4. The order of the cards in the shield zone or deck will be aligned unless it is effect or rule It can not be changed. Other cards in other zones, as the player wishes You can sort them. However, whether or not you tap it, the card attached to it Something must remain obvious to all players.
        /// </summary>
        public abstract bool Ordered { get; }

        #region Methods
        ///<summary>
        /// Adds a card to the zone.
        ///</summary>
        public abstract void Add(Card card);

        ///<summary>
        /// Removes a card from the zone.
        ///</summary>
        public abstract void Remove(Card card);
        #endregion Methods
    }
}
