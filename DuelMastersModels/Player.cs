﻿using Combinatorics.Collections;
using DuelMastersModels.Choices;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// Players are the two people that are participating in the duel. The player during the current turn is known as the "active player" and the other player is known as the "non-active player".
    /// </summary>
    public class Player : IAttackable, IDisposable
    {
        #region Properties
        public Guid Id { get; }

        public string Name { get; set; }

        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        public Deck Deck { get; set; }

        /// <summary>
        /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
        /// </summary>
        public Graveyard Graveyard { get; private set; } = new Graveyard(new List<Card>());

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        public Hand Hand { get; private set; } = new Hand(new List<Card>());

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        public ManaZone ManaZone { get; private set; } = new ManaZone(new List<Card>());

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        public ShieldZone ShieldZone { get; private set; } = new ShieldZone(new List<Card>());

        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        public BattleZone BattleZone { get; set; } = new BattleZone(new List<Card>());

        public IEnumerable<Card> CardsInNonsharedZones
        {
            get
            {
                List<Card> cards = new List<Card>();
                cards.AddRange(Deck.Cards);
                cards.AddRange(Graveyard.Cards);
                cards.AddRange(Hand.Cards);
                cards.AddRange(ManaZone.Cards);
                cards.AddRange(ShieldZone.Cards);
                return cards;
            }
        }

        public IEnumerable<Card> AllCards
        {
            get
            {
                List<Card> cards = CardsInNonsharedZones.ToList();
                cards.AddRange(BattleZone.Cards);
                return cards;
            }
        }
        #endregion Properties

        private static readonly Random _random = new Random();

        #region Methods
        public Player()
        {
            Id = Guid.NewGuid();
        }

        public Player(Player player)
        {
            Id = player.Id;
            Name = player.Name;
            Deck = player.Deck.Copy();
            Graveyard = player.Graveyard.Copy();
            Hand = player.Hand.Copy();
            ManaZone = player.ManaZone.Copy();
            ShieldZone = player.ShieldZone.Copy();
            BattleZone = player.BattleZone.Copy();
        }

        public override string ToString()
        {
            return Name;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                BattleZone?.Dispose();
                BattleZone = null;
                Deck?.Dispose();
                Deck = null;
                Graveyard?.Dispose();
                Graveyard = null;
                Hand?.Dispose();
                Hand = null;
                ManaZone?.Dispose();
                ManaZone = null;
                ShieldZone?.Dispose();
                ShieldZone = null;
            }
        }

        public void ShuffleDeck(Duel duel)
        {
            Deck.Shuffle();
            var eve = new DeckShuffledEvent(new Player(this));
            if (duel.Turns.Any())
            {
                duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(eve);
            }
            else
            {
                duel.PreGameEvents.Enqueue(eve);
            }
        }

        public void PutFromBattleZoneIntoGraveyard(Card permanent, Duel duel)
        {
            Move(duel, permanent, BattleZone, Graveyard);
        }

        public Choice PutFromManaZoneIntoBattleZone(Card card, Duel duel)
        {
            ManaZone.Remove(card);
            return BattleZone.Add(card, duel);
        }

        public void PutFromTopOfDeckIntoShieldZone(int amount, Duel duel)
        {
            for (int i = 0; i < amount; ++i)
            {
                var card = RemoveTopCardOfDeck();
                _ = ShieldZone.Add(card, duel);
                var eve = new TopDeckCardPutIntoShieldZoneEvent(new Player(this), new Card(card, true));
                if (duel.Turns.Any())
                {
                    duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(eve);
                }
                else
                {
                    duel.PreGameEvents.Enqueue(eve);
                }
            }
        }

        internal Choice Summon(Card card, Duel duel)
        {
            Hand.Remove(card);
            duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new CreatureSummonedEvent(new Player(this), new Card(card, true)));
            return BattleZone.Add(card, duel);
        }

        /// <summary>
        /// Removes the top card from a player's deck and returns it. Returns null if no cards are left in deck.
        /// </summary>
        public Card RemoveTopCardOfDeck()
        {
            return Deck.RemoveAndGetTopCard();
        }

        public void DrawCards(int amount, Duel duel)
        {
            for (int i = 0; i < amount; ++i)
            {
                Card drawnCard = RemoveTopCardOfDeck();
                if (drawnCard != null)
                {
                    _ = Hand.Add(drawnCard, duel);
                    var cardDrawnEvent = new CardDrawnEvent(new Player(this), new Card(drawnCard, true));
                    if (duel.Turns.Any())
                    {
                        duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(cardDrawnEvent);
                    }
                    else
                    {
                        duel.PreGameEvents.Enqueue(cardDrawnEvent);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public Choice UntapCardsInBattleZoneAndManaZone()
        {
            BattleZone.UntapCards();
            ManaZone.UntapCards();
            return null; //TODO: Could require choice (eg. Silent Skill)
        }

        internal IEnumerable<IGrouping<Guid, IEnumerable<IEnumerable<Guid>>>> GetUsableCardsWithPaymentInformation()
        {
            return Hand.Cards.Distinct(new CardComparer()).
                Where(card => card.ManaCost <= ManaZone.UntappedCards.Count()).
                GroupBy(
                    card => card.Id,
                    card => new Combinations<Card>(ManaZone.UntappedCards, card.ManaCost, GenerateOption.WithoutRepetition).Where(x => HasCivilizations(x, card.Civilizations)).Select(x => x.Select(y => y.Id)));
        }

        private static bool HasCivilizations(IEnumerable<Card> manas, IEnumerable<Civilization> civs)
        {
            if (!civs.Any())
            {
                return true;
            }
            else if (!manas.Any())
            {
                return false;
            }
            else
            {
                return manas.First().Civilizations.Any(x => HasCivilizations(manas.Skip(1), civs.Where(c => c != x)));
            }
        }

        public void PutFromShieldZoneToHand(Card card, Duel duel, bool canUseShieldTrigger)
        {
            PutFromShieldZoneToHand(new List<Card> { card }, duel, canUseShieldTrigger);
        }

        public void PutFromShieldZoneToHand(IEnumerable<Card> cards, Duel duel, bool canUseShieldTrigger)
        {
            for (int i = 0; i < cards.Count(); ++i)
            {
                var card = cards.ElementAt(i);
                Move(duel, card, ShieldZone, Hand);
                if (canUseShieldTrigger && card.ShieldTrigger)
                {
                    card.ShieldTriggerPending = true;
                }
            }
        }

        public void PutFromTopOfDeckIntoManaZone(Duel duel)
        {
            var card = RemoveTopCardOfDeck();
            _ = ManaZone.Add(card, duel);
            duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new TopDeckCardPutIntoManaZoneEvent(new Player(this), new Card(card, true)));
        }

        internal void Cast(Card spell, Duel duel)
        {
            Hand.Remove(spell);
            spell.RevealedTo = duel.Players.Select(x => x.Id).ToList();
            duel.ResolvingSpells.Push(spell);
            duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new SpellCastEvent(new Player(this), new Card(spell, true)));
        }

        public void Discard(List<Card> cards, Duel duel)
        {
            for (int i = 0; i < cards.Count; ++i)
            {
                Discard(cards.ElementAt(i), duel);
            }
        }

        public void Discard(Card card, Duel duel)
        {
            Move(duel, card, Hand, Graveyard);
        }

        public void DiscardAtRandom(Duel duel)
        {
            if (Hand.Cards.Any())
            {
                Discard(Hand.Cards[_random.Next(Hand.Cards.Count)], duel);
            }
        }

        public void PutFromBattleZoneOnTopOfDeck(Card permanent, Duel duel)
        {
            BattleZone.Remove(permanent);
            _ = Deck.Add(new Card(permanent, false), duel);
            duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new PermanentPutIntoTopDeckEvent(new Player(this), new Card(permanent, true)));
        }

        public void Reveal(Duel duel, Card card)
        {
            var opponent = duel.GetOpponent(this);
            card.RevealedTo.Add(opponent.Id);
            duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new CardRevealedEvent(new Player(this), new Card(card, true)));
        }

        public void Move(Duel duel, Card card, Zone source, Zone destination)
        {
            source.Remove(card);

            // 400.7. An object that moves from one zone to another becomes a new object with no memory of, or relation to, its previous existence.
            var newObject = new Card(card, false);
            _ = destination.Add(newObject, duel);
            duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new CardMovedEvent(this, card, source, destination));
        }
        #endregion Methods
    }
}
