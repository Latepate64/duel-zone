﻿
using DuelMastersModels.Cards;
using DuelMastersModels.Managers;
using DuelMastersModels.Choices;
using DuelMastersModels.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// Players are the two people that are participating in the duel. The player during the current turn is known as the "active player" and the other player is known as the "non-active player".
    /// </summary>
    public class Player : DuelObject, IAttackable
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
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
        public BattleZone BattleZone { get; private set; } = new BattleZone(new List<Card>());

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

        public Player(string name, Deck deck)
        {
            Name = name;
            Deck = deck;
        }

        /// <summary>
        /// Player shuffles their deck.
        /// </summary>
        public void ShuffleDeck()
        {
            Deck.Shuffle();
        }

        public void AddShieldTriggerToUse(Card card)
        {
            _shieldTriggerManager.AddShieldTriggerToUse(card);
        }

        public static Choice Use(Card card, IEnumerable<Card> manaCards)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            else if (manaCards == null)
            {
                throw new ArgumentNullException(nameof(manaCards));
            }
            //return Duel.Progress();
            throw new NotImplementedException(); // Mana payment
        }

        public void RemoveShieldTriggerToUse(Card card)
        {
            _shieldTriggerManager.RemoveShieldTriggerToUse(card);
        }

        public void PutFromBattleZoneIntoGraveyard(Card card, Duel duel)
        {
            BattleZone.Remove(card);
            Graveyard.Add(card, duel);
        }

        /// <summary>
        /// Player puts target card from their hand into their mana zone.
        /// </summary>
        public void PutFromHandIntoManaZone(Card card, Duel duel)
        {
            Hand.Remove(card);
            ManaZone.Add(card, duel);
        }

        ///<summary>
        /// Removes the top cards from a player's deck and puts them into their shield zone.
        ///</summary>
        public void PutFromTopOfDeckIntoShieldZone(int amount, Duel duel)
        {
            for (int i = 0; i < amount; ++i)
            {
                ShieldZone.Add(RemoveTopCardOfDeck(), duel);
            }
        }

        /// <summary>
        /// Removes the top card from a player's deck and returns it. Returns null if no cards are left in deck.
        /// </summary>
        public Card RemoveTopCardOfDeck()
        {
            return Deck.RemoveAndGetTopCard();
        }

        /// <summary>
        /// Player draws a number of cards.
        /// </summary>
        public void DrawCards(int amount, Duel duel)
        {
            for (int i = 0; i < amount; ++i)
            {
                Card drawnCard = RemoveTopCardOfDeck();
                if (drawnCard != null)
                {
                    Hand.Add(drawnCard, duel);
                }
                else
                {
                    break;
                }

                //TODO: Uncomment
                //DuelEventOccurred?.Invoke(this, new DuelEventArgs(new DrawCardEvent(this, handCard)));
            }
        }

        public Choice UntapCardsInBattleZoneAndManaZone()
        {
            BattleZone.UntapCards();
            ManaZone.UntapCards();
            return null; //TODO: Could require choice (eg. Silent Skill)
        }

        private readonly ShieldTriggerManager _shieldTriggerManager = new ShieldTriggerManager();

        //TODO: This probably will not be needed
        private static IEnumerable<IEnumerable<Civilization>> GetCivilizationSubsequences(IEnumerable<Card> cards, IEnumerable<Civilization> civs)
        {
            if (!cards.Any())
            {
                return new List<IEnumerable<Civilization>> { civs.Distinct() };
            }
            else
            {
                return cards.First().Civilizations.Select(x => civs.Append(x)).SelectMany(x => GetCivilizationSubsequences(cards.Skip(1), x)).Distinct();
            }
        }

        internal IEnumerable<IGrouping<Guid, IEnumerable<IEnumerable<Guid>>>> GetUsableCardsWithPaymentInformation()
        {
            return Hand.Cards.Distinct(new CardComparer()).
                Where(card => card.Cost <= ManaZone.UntappedCards.Count()).
                GroupBy(
                    card => card.Id,
                    card => GetCardsThatCanBeUsedInPayment(card.Cost, card.Civilizations, new List<Card>(), ManaZone.UntappedCards).Select(x => x.Select(y => y.Id))
            );
        }

        private static IEnumerable<IEnumerable<Card>> GetCardsThatCanBeUsedInPayment(int remainingCost, IEnumerable<Civilization> remainingCivs, IEnumerable<Card> locked, IEnumerable<Card> unlocked)
        {
            if (remainingCost == 0)
            {
                if (!remainingCivs.Any())
                {
                    return new List<IEnumerable<Card>> { locked.Select(x => x) };
                }
                else
                {
                    return new List<IEnumerable<Card>>();
                }
            }
            else
            {
                return unlocked.SelectMany(u =>
                    u.Civilizations.SelectMany(civ =>
                        GetCardsThatCanBeUsedInPayment(remainingCost - 1, remainingCivs.Where(c => c != civ), locked.Append(u), unlocked.Where(c => c != u))
                    )
                ).Distinct(new CardsComparer());
            }
        }

        public Player(Player player) : base(player)
        {
            Name = player.Name;
            Deck = player.Deck.Copy();
            Graveyard = player.Graveyard.Copy();
            Hand = player.Hand.Copy();
            ManaZone = player.ManaZone.Copy();
            ShieldZone = player.ShieldZone.Copy();
            BattleZone = player.BattleZone.Copy();
        }

        public Choice PutFromShieldZoneToHand(Card card, Duel duel)//, bool canUseShieldTrigger)
        {
            return PutFromShieldZoneToHand(new List<Card> { card }, duel);//, canUseShieldTrigger);
        }

        public Choice PutFromShieldZoneToHand(IEnumerable<Card> cards, Duel duel)//, bool canUseShieldTrigger)
        {
            //List<Card> shieldTriggerCards = new List<Card>();
            for (int i = 0; i < cards.Count(); ++i)
            {
                var card = cards.ElementAt(i);
                ShieldZone.Remove(card);
                Hand.Add(card, duel);
                //if (canUseShieldTrigger && HasShieldTrigger(handCard))
                //{
                //    shieldTriggerCards.Add(handCard);
                //}
            }
            return null;
            //throw new NotImplementedException();
            //return shieldTriggerCards.Any() ? new DeclareShieldTriggers(player, new ReadOnlyCollection<Card>(shieldTriggerCards)) : null;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
