﻿using DuelMastersModels.Abilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Managers;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DuelMastersModels.Zones;

namespace DuelMastersModels
{
    public class Duel
    {
        public Player StartingPlayer { get; set; }

        /// <summary>
        /// Player who won the duel.
        /// </summary>
        public Player Winner { get; private set; }

        /// <summary>
        /// Determines the state of the duel.
        /// </summary>
        public DuelState State { get; set; } = DuelState.Setup;

        /// <summary>
        /// The number of shields each player has at the start of a duel. 
        /// </summary>
        public int InitialNumberOfShields { get; set; } = 5;

        /// <summary>
        /// The number of cards each player draw at the start of a duel.
        /// </summary>
        public int InitialNumberOfHandCards { get; set; } = 5;

        public Turn CurrentTurn => _turns.Last();

        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        public BattleZone BattleZone { get; private set; }

        /// <summary>
        /// Players who lost the duel.
        /// </summary>
        private readonly Collection<Player> _losers = new Collection<Player>();

        /// <summary>
        /// Spells that are being resolved.
        /// </summary>
        private readonly Collection<Spell> _spellsBeingResolved = new Collection<Spell>();

        private readonly AbilityManager _abilityManager = new AbilityManager();

        private readonly ContinuousEffectManager _continuousEffectManager;

        /// <summary>
        /// All the turns of the duel that have been or are processed, in order.
        /// </summary>
        private readonly Collection<Turn> _turns = new Collection<Turn>();

        public Duel()
        {
            _continuousEffectManager = new ContinuousEffectManager(this, _abilityManager);
        }

        /// <summary>
        /// Starts the duel.
        /// </summary>
        /// <returns>Action a player is expected to perform.</returns>
        public Choice Start()
        {
            if (State != DuelState.Setup)
            {
                throw new InvalidOperationException($"Could not start the duel as state was {State} instead of {DuelState.Setup}.");
            }
            State = DuelState.InProgress;

            // 103.2. After the starting player has been determined, each player shuffles their deck so that the cards are in a random order.
            StartingPlayer.ShuffleDeck();
            StartingPlayer.Opponent.ShuffleDeck();

            StartingPlayer.PutFromTopOfDeckIntoShieldZone(InitialNumberOfShields);
            StartingPlayer.Opponent.PutFromTopOfDeckIntoShieldZone(InitialNumberOfShields);

            StartingPlayer.DrawCards(InitialNumberOfHandCards);
            StartingPlayer.Opponent.DrawCards(InitialNumberOfHandCards);

            return StartNewTurn(StartingPlayer);
            //return StartingPlayer.TakeTurn(this);
        }

        public Choice StartNewTurn(Player activePlayer)
        {
            Turn turn = new Turn(activePlayer, _turns.Count + 1);
            _turns.Add(turn);
            return turn.Start(BattleZone, this);
        }
        
        public Choice Continue(Choice choice) {
            return CurrentTurn.CurrentStep.Proceed(choice, this);
        }

        /// <summary>
        /// Ends the duel.
        /// </summary>
        public void End(Player winner)
        {
            Winner = winner;
            _losers.Add(winner.Opponent);
            State = DuelState.Over;
        }

        /// <summary>
        /// Manages a battle between two creatures.
        /// </summary>
        /// <param name="attackingCreature">Creature which initiated the attack.</param>
        /// <param name="defendingCreature">Creature which the attack was directed at.</param>
        public void Battle(Creature attackingCreature, Creature defendingCreature)
        {
            int attackingCreaturePower = GetPower(attackingCreature);
            int defendingCreaturePower = GetPower(defendingCreature);
            //TODO: Handle destruction as a state-based action. 703.4d
            if (attackingCreaturePower > defendingCreaturePower)
            {
                defendingCreature.Owner.PutFromBattleZoneIntoGraveyard(defendingCreature, BattleZone);
            }
            else if (attackingCreaturePower < defendingCreaturePower)
            {
                attackingCreature.Owner.PutFromBattleZoneIntoGraveyard(attackingCreature, BattleZone);
            }
            else
            {
                attackingCreature.Owner.PutFromBattleZoneIntoGraveyard(attackingCreature, BattleZone);
                defendingCreature.Owner.PutFromBattleZoneIntoGraveyard(defendingCreature, BattleZone);
            }
        }

        /// <summary>
        /// Card is used based on its type: A creature is put into the battle zone; A spell is put into your graveyard.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        public void UseCard(Player player, Card card)
        {
            if (card is Creature creature)
            {
                BattleZone.Add(creature);
            }
            else if (card is Spell spell)
            {
                CastSpell(spell);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Player adds a card from their hand to their shields face down.
        /// </summary>
        /// <param name="card"></param>
        public void AddFromYourHandToYourShieldsFaceDown(Card card)
        {
            card.Owner.Hand.Remove(card);
            card.Owner.ShieldZone.Add(card);
        }

        public void EndContinuousEffects<T>()
        {
            _continuousEffectManager.EndContinuousEffects<T>();
        }

        public void AddContinuousEffect(ContinuousEffect continuousEffect)
        {
            _continuousEffectManager.AddContinuousEffect(continuousEffect);
        }

        public void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(Creature creature)
        {
            _abilityManager.TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(creature);
        }

        public void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(Creature excludedCreature)
        {
            _abilityManager.TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(new ReadOnlyCollection<Creature>(BattleZone.Creatures.Except(new List<Creature> { excludedCreature }).ToList()));
        }

        public void SetPendingAbilityToBeResolved(NonStaticAbility ability)
        {
            _abilityManager.RemovePendingAbility(ability);
            _abilityManager.SetAbilityBeingResolved(ability);
        }

        /// <summary>
        /// Checks if a card can be used.
        /// </summary>
        internal static bool CanBeUsed(Card card, IEnumerable<Card> manaCards)
        {
            //TODO: Remove static keyword after usability is checked with continuous effects considered.
            //System.Collections.Generic.IEnumerable<Civilization> manaCivilizations = manaCards.SelectMany(manaCard => manaCard.Civilizations).Distinct();
            //return card.Cost <= manaCards.Count && card.Civilizations.Intersect(manaCivilizations).Count() == 1; //TODO: Add support for multicolored cards.
            return card.Cost <= manaCards.Count() && HasCivilizations(manaCards, card.Civilizations);
        }

        public bool CanAttackOpponent(Creature creature)
        {
            IEnumerable<Creature> creaturesThatCannotAttackPlayers = _continuousEffectManager.GetCreaturesThatCannotAttackPlayers();
            return !AffectedBySummoningSickness(creature) && !creaturesThatCannotAttackPlayers.Contains(creature);
        }

        public bool AttacksIfAble(Creature creature)
        {
            return _continuousEffectManager.AttacksIfAble(creature);
        }

        public IEnumerable<Creature> GetCreaturesThatCanBlock(Creature attackingCreature)
        {
            return new ReadOnlyCollection<Creature>(GetAllBlockersPlayerHasInTheBattleZone(attackingCreature.Owner.Opponent).Where(c => !c.Tapped).ToList());
            //TODO: consider situations where abilities of attacking creature matter etc.
        }

        public IEnumerable<Creature> GetCreaturesThatCanAttack(Player player)
        {
            IEnumerable<Creature> creaturesThatCannotAttack = _continuousEffectManager.GetCreaturesThatCannotAttack(player);
            return new ReadOnlyCollection<Creature>(BattleZone.GetUntappedCreatures(player).Where(creature => !AffectedBySummoningSickness(creature) && !creaturesThatCannotAttack.Contains(creature)).ToList());
        }

        public IEnumerable<Creature> GetCreaturesThatCanBeAttacked(Player player)
        {
            return BattleZone.GetTappedCreatures(player.Opponent);
            //TODO: Consider attacking creature
        }

        /// <summary>
        /// Player draws a card.
        /// </summary>
        public Choice DrawCard(Player player)
        {
            player.DrawCards(1);
            return null;
            //TODO: remove
            /*
            if (cards.Count == 1)
            {
                drawnCard = cards.First();
                return null;
            }
            else
            {
                throw new InvalidOperationException("drawnCard");
            }*/
        }

        public Choice PutFromShieldZoneToHand(Player player, Card card, bool canUseShieldTrigger)
        {
            return PutFromShieldZoneToHand(player, new List<Card>() { card }, canUseShieldTrigger);
        }

        public Choice PutFromShieldZoneToHand(Player player, IEnumerable<Card> cards, bool canUseShieldTrigger)
        {
            Collection<Card> shieldTriggerCards = new Collection<Card>();
            for (int i = 0; i < cards.Count(); ++i)
            {
                Card handCard = PutFromShieldZoneToHand(player, cards.ElementAt(i));
                if (canUseShieldTrigger && HasShieldTrigger(handCard))
                {
                    shieldTriggerCards.Add(handCard);
                }
            }
            throw new NotImplementedException();
            //return shieldTriggerCards.Any() ? new DeclareShieldTriggers(player, new ReadOnlyCollection<Card>(shieldTriggerCards)) : null;
        }

        public Choice PutTheTopCardOfYourDeckIntoYourManaZone(Player player)
        {
            player.ManaZone.Add(player.RemoveTopCardOfDeck());
            return null;
        }

        public Choice ReturnFromBattleZoneToHand(Creature creature)
        {
            BattleZone.Remove(creature);
            creature.Owner.Hand.Add(creature);
            return null;
        }

        public Choice PutFromBattleZoneIntoOwnersManazone(Creature creature)
        {
            BattleZone.Remove(creature);
            creature.Owner.ManaZone.Add(creature);
            return null;
        }

        public Choice PutFromManaZoneIntoTheBattleZone(Creature creature)
        {
            creature.Owner.ManaZone.Remove(creature);
            BattleZone.Add(creature);
            return null;
        }

        public Choice AddTheTopCardOfYourDeckToYourShieldsFaceDown(Player player)
        {
            player.PutFromTopOfDeckIntoShieldZone(1);
            return null;
        }

        public int GetPower(Creature creature)
        {
            return _continuousEffectManager.GetPower(creature);
        }

        public IEnumerable<Card> GetAllCards()
        {
            List<Card> cards = CurrentTurn.ActivePlayer.CardsInNonsharedZones.ToList();
            cards.AddRange(CurrentTurn.NonActivePlayer.CardsInNonsharedZones);
            cards.AddRange(BattleZone.Cards);
            return cards;
        }

        private Card PutFromShieldZoneToHand(Player player, Card card)
        {
            player.ShieldZone.Remove(card);
            player.Hand.Add(card);
            return card;
        }

        /// <summary>
        /// Checks if selected mana cards have the required civilizations.
        /// </summary>
        private static bool HasCivilizations(IEnumerable<Card> paymentCards, IEnumerable<Civilization> requiredCivilizations)
        {
            List<List<Civilization>> civilizationGroups = new List<List<Civilization>>();
            foreach (Card card in paymentCards)
            {
                civilizationGroups.Add(card.Civilizations.ToList());
            }
            foreach (IEnumerable<Civilization> combination in GetCivilizationCombinations(civilizationGroups, new List<Civilization>()).Select(combination => combination.Distinct()))
            {
                for (int i = 0; i < requiredCivilizations.Count(); ++i)
                {
                    if (!combination.Contains(requiredCivilizations.ElementAt(i)))
                    {
                        break;
                    }
                    else if (requiredCivilizations.Count() - 1 == i)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool HasShieldTrigger(Creature creature)
        {
            return _continuousEffectManager.HasShieldTrigger(creature);
        }

        private bool HasShieldTrigger(Spell spell)
        {
            return _continuousEffectManager.HasShieldTrigger(spell);
        }

        private bool HasShieldTrigger(Card card)
        {
            if (card is Creature creature)
            {
                return HasShieldTrigger(creature);
            }
            else if (card is Spell spell)
            {
                return HasShieldTrigger(spell);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private bool HasSpeedAttacker(Creature creature)
        {
            return _continuousEffectManager.HasSpeedAttacker(creature);
        }

        private bool AffectedBySummoningSickness(Creature creature)
        {
            return creature.SummoningSickness && !HasSpeedAttacker(creature);
        }

        private static List<List<Civilization>> GetCivilizationCombinations(List<List<Civilization>> civilizationGroups, List<Civilization> knownCivilizations)
        {
            if (civilizationGroups.Count > 0)
            {
                List<Civilization> civilizations = civilizationGroups.First();
                List<List<Civilization>> newCivilizationGroups = new List<List<Civilization>>(civilizationGroups);
                _ = newCivilizationGroups.Remove(civilizations);
                List<List<Civilization>> output = new List<List<Civilization>>();
                foreach (Civilization civilization in civilizations)
                {
                    List<Civilization> newKnownCivilizations = new List<Civilization>(knownCivilizations) { civilization };

                    output.AddRange(
                        GetCivilizationCombinations(
                            newCivilizationGroups,
                            newKnownCivilizations));
                }
                return output;
            }
            else
            {
                List<Civilization> copyOfKnownCivilizations = new List<Civilization>(knownCivilizations);
                return new List<List<Civilization>> { copyOfKnownCivilizations };
            }
        }

        private IEnumerable<Creature> GetAllBlockersPlayerHasInTheBattleZone(Player player)
        {
            return _continuousEffectManager.GetAllBlockersPlayerHasInTheBattleZone(player);
        }

        private void CastSpell(Spell spell)
        {
            _spellsBeingResolved.Add(spell);
            _abilityManager.TriggerWheneverAPlayerCastsASpellAbilities(BattleZone.Creatures);
        }

        //private void RandomizeStartingPlayer(out Player activePlayer, out Player nonActivePlayer)
        //{
        //    activePlayer = Player1;
        //    nonActivePlayer = Player2;
        //    if (StartingPlayerMethod == StartingPlayerMethod.Random)
        //    {
        //        const int RandomMax = 100;
        //        int randomNumber = new Random().Next(0, RandomMax);
        //        StartingPlayerMethod = (randomNumber % 2 == 0) ? StartingPlayerMethod.Player1 : StartingPlayerMethod.Player2;
        //    }

        //    if (StartingPlayerMethod == StartingPlayerMethod.Player2)
        //    {
        //        activePlayer = Player2;
        //        nonActivePlayer = Player1;
        //    }
        //    else if (StartingPlayerMethod != StartingPlayerMethod.Player1)
        //    {
        //        throw new InvalidOperationException();
        //    }
        //}
    }
}
