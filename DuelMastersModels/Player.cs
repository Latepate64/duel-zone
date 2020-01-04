using DuelMastersModels.Cards;
using DuelMastersModels.Zones;

namespace DuelMastersModels
{
    /// <summary>
    /// Players are the two people that are participating in the duel. The player during the current turn is known as the "active player" and the other player is known as the "non-active player".
    /// </summary>
    public class Player
    {
        #region Properties
        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Represents the cards the player is going to use in a duel.
        /// </summary>
        public ReadOnlyCardCollection DeckBeforeDuel => new ReadOnlyCardCollection(_deckBeforeDuel);

        #region Zones
        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        public BattleZone BattleZone { get; private set; }

        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        public Deck Deck { get; private set; }

        /// <summary>
        /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
        /// </summary>
        public Graveyard Graveyard { get; private set; }

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        public Hand Hand { get; private set; }

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        public ManaZone ManaZone { get; private set; }

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        public ShieldZone ShieldZone { get; private set; }
        #endregion Zones

        //public Collection<Abilities.Trigger.TriggerAbility> TriggerAbilities { get; } = new Collection<Abilities.Trigger.TriggerAbility>();

        //public ReadOnlyCardCollection UsableShieldTriggers { get; } = new ReadOnlyCardCollection();

        internal ReadOnlyCardCollection ShieldTriggersToUse => new ReadOnlyCardCollection(_shieldTriggersToUse);
        #endregion Properties

        #region Fields
        //private readonly CardCollection _deckBeforeDuel = new CardCollection();
        private ReadOnlyCardCollection _deckBeforeDuel;
        private readonly CardCollection _shieldTriggersToUse = new CardCollection();
        #endregion Fields

        /// <summary>
        /// Creates a player by initializing their zones.
        /// </summary>
        public Player(string name, ReadOnlyCardCollection deckBeforeDuel)
        {
            Name = name;
            _deckBeforeDuel = deckBeforeDuel;
            Deck = new Deck(this, deckBeforeDuel);
            BattleZone = new BattleZone(this);
            Graveyard = new Graveyard(this);
            Hand = new Hand(this);
            ManaZone = new ManaZone(this);
            ShieldZone = new ShieldZone(this);
        }

        //TODO: Try to use only one public method.
        #region Public methods
            /*
        /// <summary>
        /// Sets the cards the player is going to use in a duel.
        /// </summary>
        public void SetDeckBeforeDuel(ReadOnlyCardCollection cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("cards");
            }
            foreach (Card card in cards)
            {
                _deckBeforeDuel.Add(card);
            }
        }*/

        /*
        /// <summary>
        /// Setups the player's deck from the cards they are going to use in a duel.
        /// </summary>
        public void SetupDeck(Duel duel)
        {
            foreach (Card card in DeckBeforeDuel)
            {
                Deck.Add(card, duel);
            }
        }*/
        #endregion Public methods

        #region Internal methods
        /// <summary>
        /// Player shuffles their deck.
        /// </summary>
        internal void ShuffleDeck()
        {
            Deck.Shuffle();
        }

        internal void AddShieldTriggerToUse(Card card)
        {
            _shieldTriggersToUse.Add(card);
        }

        internal void RemoveShieldTriggerToUse(Card card)
        {
            _shieldTriggersToUse.Remove(card);
        }
        #endregion Internal methods
    }
}
