using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Factories;
using DuelMastersModels.Managers;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// Players are the two people that are participating in the duel. The player during the current turn is known as the "active player" and the other player is known as the "non-active player".
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        public IBattleZone BattleZone { get; private set; }

        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        public IDeck Deck { get; set; }

        /// <summary>
        /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
        /// </summary>
        public IGraveyard Graveyard { get; private set; }

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        public IHand Hand { get; private set; }

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        public IManaZone ManaZone { get; private set; }

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        public IShieldZone ShieldZone { get; private set; }

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

        public IPlayer Opponent { get; set; }

        public ITurnManager TurnManager { get; set; }

        public IDuel Duel { get; set; }

        public Player() { }

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

        public IPlayerAction ChargeMana(IHandCard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            else if (TurnManager.CurrentTurn.CurrentStep is Steps.ChargeStep chargeStep)
            {
                if (this == chargeStep.ActivePlayer)
                {
                    PutFromHandIntoManaZone(card);
                    return Duel.Progress();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IPlayerAction Use(IHandCard card, IEnumerable<IManaZoneCard> manaCards)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            else if (manaCards == null)
            {
                throw new ArgumentNullException(nameof(manaCards));
            }
            else if (TurnManager.CurrentTurn.CurrentStep is Steps.MainStep mainStep)
            {
                if (this == mainStep.ActivePlayer)
                {
                    return Duel.Progress();
                    throw new NotImplementedException("Consider mana payment");
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
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
                throw new InvalidOperationException();
            }
        }

        public void PutFromBattleZoneIntoGraveyard(IBattleZoneCard card)
        {
            BattleZone.Remove(card);
            Graveyard.Add(CardFactory.GenerateGraveyardCard(card));
        }

        /// <summary>
        /// Player puts target card from their hand into their mana zone.
        /// </summary>
        /// <param name="card"></param>
        public void PutFromHandIntoManaZone(IHandCard card)
        {
            Hand.Remove(card);
            ManaZone.Add(CardFactory.GenerateManaZoneCard(card));
        }

        ///<summary>
        /// Removes the top cards from a player's deck and puts them into their shield zone.
        ///</summary>
        public void PutFromTopOfDeckIntoShieldZone(int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                ShieldZone.Add(CardFactory.GenerateShieldZoneCard(RemoveTopCardOfDeck(), false));
            }
        }

        /// <summary>
        /// Removes the top card from a player's deck and returns it.
        /// </summary>
        public ICard RemoveTopCardOfDeck()
        {
            return Deck.RemoveAndGetTopCard();
        }

        /// <summary>
        /// Creates a new turn and starts it.
        /// </summary>
        public IPlayerAction TakeTurn(IDuel duel)
        {
            IPlayerAction playerAction = duel.TurnManager.StartTurn(this, duel);
            return playerAction != null ? duel.TryToPerformAutomatically(playerAction) : duel.Progress();
        }

        /// <summary>
        /// Player draws a number of cards.
        /// </summary>
        public void DrawCards(int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                ICard drawnCard = RemoveTopCardOfDeck();
                IHandCard handCard = CardFactory.GenerateHandCard(drawnCard);
                Hand.Add(handCard);

                //TODO: Uncomment
                //DuelEventOccurred?.Invoke(this, new DuelEventArgs(new DrawCardEvent(this, handCard)));
            }
        }

        private readonly ShieldTriggerManager _shieldTriggerManager = new ShieldTriggerManager();
    }
}
