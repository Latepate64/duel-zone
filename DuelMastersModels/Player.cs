using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Zones;

namespace DuelMastersModels
{
    /// <summary>
    /// Players are the two people that are participating in the duel. The player during the current turn is known as the "active player" and the other player is known as the "non-active player".
    /// </summary>
    public class Player : IPlayer
    {
        #region Properties
        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Represents the cards the player is going to use in a duel.
        /// </summary>
        public ReadOnlyCardCollection<ICard> DeckBeforeDuel => new ReadOnlyCardCollection<ICard>(_deckBeforeDuel);

        #region Zones
        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        internal BattleZone BattleZone { get; private set; }

        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        internal Deck Deck { get; private set; }

        /// <summary>
        /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
        /// </summary>
        internal Graveyard Graveyard { get; private set; }

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        internal Hand Hand { get; private set; }

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        internal ManaZone ManaZone { get; private set; }

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        internal ShieldZone ShieldZone { get; private set; }
        #endregion Zones

        //public Collection<Abilities.Trigger.TriggerAbility> TriggerAbilities { get; } = new Collection<Abilities.Trigger.TriggerAbility>();

        //public ReadOnlyCardCollection UsableShieldTriggers { get; } = new ReadOnlyCardCollection();

        internal ReadOnlyCardCollection<IHandCard> ShieldTriggersToUse => new ReadOnlyCardCollection<IHandCard>(_shieldTriggersToUse);
        #endregion Properties

        #region Fields
        //private readonly CardCollection _deckBeforeDuel = new CardCollection();
        private readonly ReadOnlyCardCollection<ICard> _deckBeforeDuel;
        private readonly CardCollection<IHandCard> _shieldTriggersToUse = new CardCollection<IHandCard>();
        #endregion Fields

        /// <summary>
        /// Creates a player by initializing their zones.
        /// </summary>
        public Player(string name, ReadOnlyCardCollection<ICard> deckBeforeDuel)
        {
            Name = name;
            _deckBeforeDuel = deckBeforeDuel ?? throw new System.ArgumentNullException(nameof(deckBeforeDuel));
            Deck = new Deck(deckBeforeDuel);
            BattleZone = new BattleZone();
            Graveyard = new Graveyard();
            Hand = new Hand();
            ManaZone = new ManaZone();
            ShieldZone = new ShieldZone();
        }

        #region Internal methods
        /// <summary>
        /// Player shuffles their deck.
        /// </summary>
        internal void ShuffleDeck()
        {
            Deck.Shuffle();
        }

        internal void AddShieldTriggerToUse(IHandCard card)
        {
            _shieldTriggersToUse.Add(card);
        }

        internal void RemoveShieldTriggerToUse(IHandCard card)
        {
            _shieldTriggersToUse.Remove(card);
        }

        internal ReadOnlyContinuousEffectCollection GetContinuousEffectsGeneratedByStaticAbility(ICard card, StaticAbility staticAbility)
        {
            if (staticAbility is StaticAbilityForCreature staticAbilityForCreature)
            {
                return staticAbilityForCreature.EffectActivityCondition == EffectActivityConditionForCreature.Anywhere ||
                    (staticAbilityForCreature.EffectActivityCondition == EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone && card is IBattleZoneCard battleZoneCard && BattleZone.Cards.Contains(battleZoneCard)) ||
                    (staticAbilityForCreature.EffectActivityCondition == EffectActivityConditionForCreature.WhileThisCreatureIsInYourHand && card is IHandCreature handCreature && Hand.Cards.Contains(handCreature))
                    ? staticAbilityForCreature.ContinuousEffects
                    : new ReadOnlyContinuousEffectCollection();
            }
            else if (staticAbility is StaticAbilityForSpell staticAbilityForSpell)
            {
                return staticAbilityForSpell.EffectActivityCondition == StaticAbilityForSpellActivityCondition.WhileThisSpellIsInYourHand && card is IHandSpell handSpell && Hand.Cards.Contains(handSpell)
                    ? staticAbilityForSpell.ContinuousEffects
                    : new ReadOnlyContinuousEffectCollection();
            }
            else
            {
                throw new System.InvalidOperationException();
            }
        }
        #endregion Internal methods
    }
}
