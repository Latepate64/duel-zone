using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Managers;
using DuelMastersModels.Zones;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// Players are the two people that are participating in the duel. The player during the current turn is known as the "active player" and the other player is known as the "non-active player".
    /// </summary>
    public class Player : IPlayer
    {
        #region Public
        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Represents the cards the player is going to use in a duel.
        /// </summary>
        public IEnumerable<ICard> DeckBeforeDuel => new ReadOnlyCollection<ICard>(_deckBeforeDuel.ToList());
        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        public BattleZone BattleZone { get; private set; }

        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        public IDeck Deck { get; set; }

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

        public Player() { }

        /// <summary>
        /// Creates a player by initializing their zones.
        /// </summary>
        public Player(string name, IEnumerable<ICard> deckBeforeDuel)
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
        #endregion Public

        #region Internal
        public IEnumerable<IHandCard> ShieldTriggersToUse => _shieldTriggerManager.ShieldTriggersToUse;

        public IEnumerable<ICard> CardsInAllZones
        {
            get
            {
                List<ICard> cards = new List<ICard>();
                cards.AddRange(BattleZone.Cards);
                cards.AddRange(Deck.Cards);
                cards.AddRange(Graveyard.Cards);
                cards.AddRange(Hand.Cards);
                cards.AddRange(ManaZone.Cards);
                cards.AddRange(ShieldZone.Cards);
                return cards;
            }
        }

        /// <summary>
        /// Player shuffles their deck.
        /// </summary>
        public void ShuffleDeck()
        {
            Deck.Shuffle();
        }

        public void AddShieldTriggerToUse(IHandCard card)
        {
            _shieldTriggerManager.AddShieldTriggerToUse(card);
        }

        public void RemoveShieldTriggerToUse(IHandCard card)
        {
            _shieldTriggerManager.RemoveShieldTriggerToUse(card);
        }

        public ReadOnlyContinuousEffectCollection GetContinuousEffectsGeneratedByStaticAbility(ICard card, IStaticAbility staticAbility)
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

        public bool AnyZoneContains(ICard card)
        {
            return CardsInAllZones.Contains(card);
        }
        #endregion Internal

        #region Private
        private readonly IEnumerable<ICard> _deckBeforeDuel;
        private readonly ShieldTriggerManager _shieldTriggerManager = new ShieldTriggerManager();
        #endregion Private
    }
}
