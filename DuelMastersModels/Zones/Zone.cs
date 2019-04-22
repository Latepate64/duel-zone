using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Zones
{
    public abstract class Zone
    {
        #region Properties
        /// <summary>
        /// The cards that are in the zone.
        /// </summary>
        public Collection<Card> Cards { get; } = new Collection<Card>();

        public Collection<Creature> Creatures
        {
            get
            {
                return new Collection<Creature>(Cards.Where(card => card is Creature).Cast<Creature>().ToList());
            }
        }

        public Collection<Card> TappedCards
        {
            get
            {
                return new Collection<Card>(Cards.Where(card => card.Tapped).ToList());
            }
        }

        public Collection<Creature> TappedCreatures
        {
            get
            {
                return new Collection<Creature>(Creatures.Where(creature => creature.Tapped).ToList());
            }
        }

        public Collection<Card> UntappedCards
        {
            get
            {
                return new Collection<Card>(Cards.Where(card => !card.Tapped).ToList());
            }
        }

        public Collection<Creature> UntappedCreatures
        {
            get
            {
                return new Collection<Creature>(Creatures.Where(creature => !creature.Tapped).ToList());
            }
        }

        public Collection<Creature> CreaturesThatCanAttack
        {
            get
            {
                return new Collection<Creature>(UntappedCreatures.Where(creature => !creature.SummoningSickness).ToList());
            }
        }

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
        #endregion Properties

        #region Methods
        ///<summary>
        /// Adds a card to the zone.
        ///</summary>
        public abstract void Add(Card card);

        ///<summary>
        /// Removes a card from the zone.
        ///</summary>
        public abstract void Remove(Card card);

        public Collection<Card> UntappedCardsWithCivilizations(Collection<Civilization> civilizations)
        {
            return new Collection<Card>(UntappedCards.Where(card => card.Civilizations.Intersect(civilizations).Count() > 0).ToList());
        }

        public void UntapCards()
        {
            foreach (var card in TappedCards)
            {
                card.Tapped = false;
            }
        }

        public Card GetCard(int gameId)
        {
            return Cards.First(card => card.GameId == gameId);
        }
        #endregion Methods
    }
}
