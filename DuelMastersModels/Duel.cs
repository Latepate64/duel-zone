﻿using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.GameActions.StateBasedActions;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
using DuelMastersModels.PlayerActions.OptionalActions;
using DuelMastersModels.PlayerActionResponses;
using DuelMastersModels.Steps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// Represents a duel that is played between two players.
    /// </summary>
    public class Duel : System.ComponentModel.INotifyPropertyChanged
    {
        #region Properties
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        /// <summary>
        /// Player who won the duel.
        /// </summary>
        public Player Winner { get; private set; }

        /// <summary>
        /// Players who lost the duel.
        /// </summary>
        public Collection<Player> Losers { get; } = new Collection<Player>();

        /// <summary>
        /// True if the duel has ended, false otherwise.
        /// </summary>
        public bool Ended { get; private set; }

        /// <summary>
        /// All the turns of the duel that have been or are processed, in order.
        /// </summary>
        public ObservableCollection<Turn> Turns { get; } = new ObservableCollection<Turn>();

        /// <summary>
        /// The turn that is currently being processed.
        /// </summary>
        public Turn CurrentTurn => Turns.Last();

        /// <summary>
        /// The number of shields each player has at the start of a duel. 
        /// </summary>
        public int InitialNumberOfShields { get; set; } = 5;

        /// <summary>
        /// The number of cards each player draw at the start of a duel.
        /// </summary>
        public int InitialNumberOfHandCards { get; set; } = 5;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private PlayerAction _currentPlayerAction;
        public PlayerAction CurrentPlayerAction
        {
            get
            {
                return _currentPlayerAction;
            }
            set
            {
                if (value != _currentPlayerAction)
                {
                    _currentPlayerAction = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        public Collection<Spell> SpellsBeingResolved { get; } = new Collection<Spell>();

        public static Collection<string> NotParsedAbilities { get; } = new Collection<string>();
        #endregion Properties

        #region Public methods
        /// <summary>
        /// Starts a duel.
        /// </summary>
        public PlayerAction StartDuel()
        {
            Player1.ShuffleDeck();
            Player2.ShuffleDeck();
            PutFromTheTopOfDeckIntoShieldZone(Player1, InitialNumberOfShields);
            PutFromTheTopOfDeckIntoShieldZone(Player2, InitialNumberOfShields);
            DrawCards(Player1, InitialNumberOfHandCards);
            DrawCards(Player2, InitialNumberOfHandCards);
            return SetCurrentPlayerAction(StartNewTurn(Player1, Player2));
        }

        /// <summary>
        /// Creates a new turn and starts it.
        /// </summary>
        private PlayerAction StartNewTurn(Player activePlayer, Player nonActivePlayer)
        {
            Turn turn = new Turn(activePlayer, nonActivePlayer, Turns.Count + 1);
            Turns.Add(turn);
            PlayerAction playerAction = turn.Start(this);
            if (playerAction != null)
            {
                return TryToPerformAutomatically(playerAction);
            }
            else
            {
                return Progress();
            }
        }

        /// <summary>
        /// Returns the opponent of a player.
        /// </summary>
        public Player GetOpponent(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            else if (player == Player1)
            {
                return Player2;
            }
            else if (player == Player2)
            {
                return Player1;
            }
            else
            {
                throw new ArgumentOutOfRangeException("player");
            }
        }

        /// <summary>
        /// Ends the duel.
        /// </summary>
        public void End(Player winner)
        {
            Winner = winner;
            Losers.Add(GetOpponent(winner));
            Ended = true;
        }

        /// <summary>
        /// Ends duel in a draw.
        /// </summary>
        public void EndDuelInDraw()
        {
            Losers.Add(Player1);
            Losers.Add(Player2);
            Ended = true;
        }

        /// <summary>
        /// Player draws a card.
        /// </summary>
        public static PlayerAction DrawCard(Player player)
        {
            DrawCards(player, 1);
            return null;
        }

        public PlayerAction Progress(PlayerActionResponse response)
        {
            PlayerAction playerAction = null;
            if (response is CardSelectionResponse cardSelectionResponse)
            {
                if (CurrentPlayerAction is OptionalCardSelection optionalCardSelection)
                {
                    Card card = null;
                    if (cardSelectionResponse.SelectedCards.Count == 1)
                    {
                        card = cardSelectionResponse.SelectedCards.First();
                    }
                    if (optionalCardSelection.Validate(card))
                    {
                        optionalCardSelection.SelectedCard = card;
                        playerAction = optionalCardSelection.Perform(this, card);
                        CurrentTurn.CurrentStep.PlayerActions.Add(optionalCardSelection);
                    }
                    else
                    {
                        return CurrentPlayerAction;
                    }
                }
                else if (CurrentPlayerAction is PayCost payCost)
                {
                    if (payCost.Validate(cardSelectionResponse.SelectedCards, (CurrentTurn.CurrentStep as MainStep).CardToBeUsed))
                    {
                        playerAction = payCost.Perform(this, cardSelectionResponse.SelectedCards);
                    }
                    else
                    {
                        return CurrentPlayerAction;
                    }
                }
                else if (CurrentPlayerAction is MultipleCardSelection multipleCardSelection)
                {
                    if (multipleCardSelection.Validate(cardSelectionResponse.SelectedCards))
                    {
                        foreach (Card card in cardSelectionResponse.SelectedCards)
                        {
                            multipleCardSelection.SelectedCards.Add(card);
                        }
                        playerAction = multipleCardSelection.Perform(this, cardSelectionResponse.SelectedCards);
                        CurrentTurn.CurrentStep.PlayerActions.Add(multipleCardSelection);
                    }
                }
                else if (CurrentPlayerAction is MandatoryCardSelection mandatoryCardSelection)
                {
                    if (cardSelectionResponse.SelectedCards.Count == 1)
                    {
                        Card card = cardSelectionResponse.SelectedCards.First();
                        if (mandatoryCardSelection.Validate(card))
                        {
                            mandatoryCardSelection.SelectedCard = card;
                            playerAction = mandatoryCardSelection.Perform(this, card);
                            CurrentTurn.CurrentStep.PlayerActions.Add(mandatoryCardSelection);
                        }
                        else
                        {
                            throw new InvalidOperationException("mandatoryCardSelection");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("mandatoryCardSelection");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Could not identify current player action.");
                }
            }
            else if (response is CreatureSelectionResponse creatureSelectionResponse)
            {
                if (CurrentPlayerAction is OptionalCreatureSelection optionalCreatureSelection)
                {
                    Creature creature = null;
                    if (creatureSelectionResponse.SelectedCreatures.Count == 1)
                    {
                        creature = creatureSelectionResponse.SelectedCreatures.First();
                    }
                    if (optionalCreatureSelection.Validate(creature))
                    {
                        optionalCreatureSelection.SelectedCreature = creature;
                        playerAction = optionalCreatureSelection.Perform(this, creature);
                        CurrentTurn.CurrentStep.PlayerActions.Add(optionalCreatureSelection);
                    }
                    else
                    {
                        return CurrentPlayerAction;
                    }
                }
                else
                {
                    throw new InvalidOperationException("Could not identify current player action.");
                }
            }
            else if (response is OptionalActionResponse optionalActionResponse)
            {
                if (CurrentPlayerAction is OptionalAction optionalAction)
                {
                    playerAction = optionalAction.Perform(this, optionalActionResponse.TakeAction);
                    CurrentTurn.CurrentStep.PlayerActions.Add(optionalAction);
                }
                else
                {
                    throw new InvalidOperationException("optionalActionResponse");
                }
            }
            /*
            else if (response is DeclareAttackResponse declareAttackResponse)
            {
                DeclareAttack declareAttack = CurrentPlayerAction as DeclareAttack;
                if (declareAttackResponse.Attacker != null)
                {
                    if (declareAttack.Validate(declareAttackResponse.Attacker, declareAttackResponse.TargetOfAttack))
                    {
                        declareAttack.Declare(this, declareAttackResponse.Attacker, declareAttackResponse.TargetOfAttack);
                    }
                    else
                    {
                        return CurrentPlayerAction;
                    }
                }
            }*/
            else
            {
                throw new ArgumentOutOfRangeException("response");
            }
            if (playerAction == null)
            {
                return SetCurrentPlayerAction(Progress());
            }
            else
            {
                return SetCurrentPlayerAction(TryToPerformAutomatically(playerAction));
                //return SetCurrentPlayerAction(Progress(playerAction));
            }
        }

        public void PutFromHandIntoManaZone(Player player, Card card)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            if (card == null)
            {
                throw new ArgumentNullException("card");
            }
            player.Hand.Remove(card);
            player.ManaZone.Add(card);
        }

        /// <summary>
        /// TODO: Handle destruction as a state-based action. 703.4d
        /// </summary>
        public static void Battle(Creature attackingCreature, Creature defendingCreature, Player attackingPlayer, Player defendingPlayer)
        {
            if (attackingCreature == null)
            {
                throw new ArgumentNullException("attackingCreature");
            }
            else if (defendingCreature == null)
            {
                throw new ArgumentNullException("defendingCreature");
            }
            else if (attackingPlayer == null)
            {
                throw new ArgumentNullException("attackingPlayer");
            }
            else if (defendingPlayer == null)
            {
                throw new ArgumentNullException("defendingPlayer");
            }
            else if (attackingCreature.Power > defendingCreature.Power)
            {
                PutFromBattleZoneIntoGraveyard(defendingPlayer, defendingCreature);
            }
            else if (attackingCreature.Power < defendingCreature.Power)
            {
                PutFromBattleZoneIntoGraveyard(attackingPlayer, attackingCreature);
            }
            else
            {
                PutFromBattleZoneIntoGraveyard(attackingPlayer, attackingCreature);
                PutFromBattleZoneIntoGraveyard(defendingPlayer, defendingCreature);
            }
        }

        public Player GetPlayer(int id)
        {
            if (Player1.Id == id)
            {
                return Player1;
            }
            else if (Player2.Id == id)
            {
                return Player2;
            }
            else
            {
                throw new ArgumentOutOfRangeException("id");
            }
        }

        /// <summary>
        /// Checks if a card can be used.
        /// </summary>
        public static bool CanBeUsed(Card card, Collection<Card> manaCards)
        {
            //System.Collections.Generic.IEnumerable<Civilization> manaCivilizations = manaCards.SelectMany(manaCard => manaCard.Civilizations).Distinct();
            //return card.Cost <= manaCards.Count && card.Civilizations.Intersect(manaCivilizations).Count() == 1; //TODO: Add support for multicolored cards.
            return card.Cost <= manaCards.Count && HasCivilizations(manaCards, card.Civilizations);
        }

        public Collection<Creature> GetCreaturesThatCanBlock(Creature attackingCreature)
        {
            return new Collection<Creature>(GetAllBlockersPlayerHasInTheBattleZone(GetOpponent(GetOwner(attackingCreature))).Where(c => !c.Tapped).ToList());
            //TODO: consider situations where abilities of attacking creature matter etc.
        }

        public Collection<Creature> GetCreaturesThatCanAttack(Player player)
        {
            IEnumerable<CannotAttackPlayersEffect> cannotAttackPlayersEffects = GetContinuousEffects().Where(e => e is CannotAttackPlayersEffect).Cast<CannotAttackPlayersEffect>();
            List<Creature> creatures = player.BattleZone.UntappedCreatures.Where(creature => !creature.SummoningSickness).ToList();

            IEnumerable<Creature> creaturesThatCannotAttackPlayers = cannotAttackPlayersEffects.SelectMany(e => e.CreatureFilter.FilteredCreatures).Distinct();
            IEnumerable<Creature> creaturesThatCannotAttack = creaturesThatCannotAttackPlayers.Where(c => GetCreaturesThatCanBeAttacked(player, c).Count == 0);
            /*
            foreach (CreatureContinuousEffect creatureContinuousEffect in cannotAttackPlayersEffects)
            {
                Collection<Creature> creaturesThatCannotAttackPlayers = creatureContinuousEffect.CreatureFilter.FilteredCreatures;
                creatures.RemoveAll(c => creaturesThatCannotAttackPlayers.Contains(c));
            }*/
            creatures.RemoveAll(c => creaturesThatCannotAttack.Contains(c));
            return new Collection<Creature>(creatures);
        }

        public bool CanAttackOpponent(Creature creature)
        {
            IEnumerable<CannotAttackPlayersEffect> cannotAttackPlayersEffects = GetContinuousEffects().Where(e => e is CannotAttackPlayersEffect).Cast<CannotAttackPlayersEffect>();
            IEnumerable<Creature> creaturesThatCannotAttackPlayers = cannotAttackPlayersEffects.SelectMany(e => e.CreatureFilter.FilteredCreatures).Distinct();
            return !creature.SummoningSickness && !creaturesThatCannotAttackPlayers.Contains(creature);
        }

        public Collection<Creature> GetCreaturesThatCanBeAttacked(Player player, Creature attackingCreature)
        {
            Player opponent = GetOpponent(player);
            return opponent.BattleZone.TappedCreatures;
            //TODO: improve
        }

        public bool HasShieldTrigger(Card card)
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

        public PlayerAction PutFromShieldZoneToHand(Player player, Collection<Card> cards)
        {
            Collection<Card> shieldTriggerCards = new Collection<Card>();
            foreach (Card card in cards)
            {
                PutFromShieldZoneToHand(player, card);
                if (HasShieldTrigger(card))
                {
                    shieldTriggerCards.Add(card);
                }
            }
            if (shieldTriggerCards.Count > 0)
            {
                return new DeclareShieldTriggers(player, shieldTriggerCards);
            }
            return null;
        }

        public void PlayCard(Card card, Player player)
        {
            if (card is Creature creature)
            {
                player.BattleZone.Add(card);
            }
            else if (card is Spell spell)
            {
                SpellsBeingResolved.Add(spell);
            }
            else
            {
                throw new InvalidOperationException("mainStep.CardToBeUsed");
            }
        }

        public PlayerAction PutTheTopCardOfYourDeckIntoYourManaZone(Player player)
        {
            player.ManaZone.Add(RemoveTheTopCardOfDeck(player));
            return null;
        }
        #endregion Public methods

        #region Private methods
        ///<summary>
        /// Removes the top cards from a player's deck and puts them into their shield zone.
        ///</summary>
        private static void PutFromTheTopOfDeckIntoShieldZone(Player player, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                player.ShieldZone.Add(RemoveTheTopCardOfDeck(player));
            }
        }

        /// <summary>
        /// Removes the top card from a player's deck and returns it.
        /// </summary>
        private static Card RemoveTheTopCardOfDeck(Player player)
        {
            return player.Deck.RemoveAndGetTopCard();
        }

        /// <summary>
        /// A player draws a number of cards.
        /// </summary>
        private static void DrawCards(Player player, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                player.Hand.Add(RemoveTheTopCardOfDeck(player));
            }
        }

        /// <summary>
        /// 703.3. The game always checks for any of the listed conditions for state-based actions, then performs all applicable state-based actions simultaneously as a single event. If any state-based actions are performed as a result of a check, the check is repeated.
        /// </summary>
        private void CheckStateBasedActions()
        {
            CheckDeckHasCards checkDeckHasCards = new CheckDeckHasCards();
            checkDeckHasCards.Perform(this);
        }

        private PlayerAction TryToPerformAutomatically(PlayerAction playerAction)
        {
            if (playerAction.PerformAutomatically(this))
            {
                CurrentTurn.CurrentStep.PlayerActions.Add(playerAction);
                return Progress();
            }
            else if (playerAction.Player is AIPlayer aiPlayer)
            {
                AIPlayer.PerformPlayerAction(this, playerAction);
                return Progress();
            }
            else
            {
                return playerAction;
            }
        }

        private static void PutFromBattleZoneIntoGraveyard(Player player, Creature creature)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            if (creature == null)
            {
                throw new ArgumentNullException("creature");
            }
            player.BattleZone.Cards.Remove(creature);
            player.Graveyard.Cards.Add(creature);
        }

        /// <summary>
        /// Progresses in the duel.
        /// </summary>
        /// <returns>A player request for a player to perform an action. Returns null if there is nothing left to do in the duel.</returns>
        private PlayerAction Progress()
        {
            if (!Ended)
            {
                CheckStateBasedActions();
                if (!Ended)
                {
                    //TODO: Resolve spell abilities
                    while (SpellsBeingResolved.Count > 0)
                    {
                        Spell spell = SpellsBeingResolved.Last();
                        SpellsBeingResolved.Remove(spell);
                        GetOwner(spell).Graveyard.Add(spell);
                    }

                    if (CurrentTurn.NonActivePlayer.ShieldTriggersToUse.Count > 0)
                    {
                        return SetCurrentPlayerAction(TryToPerformAutomatically(new UseShieldTrigger(CurrentTurn.NonActivePlayer, CurrentTurn.NonActivePlayer.ShieldTriggersToUse)));
                    }

                    /*if (CurrentTurn.ActivePlayer.UsableShieldTriggers.Count > 0)
                    {
                        PlayerAction action = new DeclareShieldTriggers(CurrentTurn.ActivePlayer);
                    }*/

                    //TODO: shield triggers nonactive

                    if (CurrentTurn.ActivePlayer.TriggerAbilities.Count == 1)
                    {
                        TriggerAbility ability = CurrentTurn.ActivePlayer.TriggerAbilities.First();

                        //todo: remove ability from stack after it is has completely resolved
                        CurrentTurn.ActivePlayer.TriggerAbilities.Remove(ability);
                        

                        return SetCurrentPlayerAction(TryToPerformAutomatically(ability.StartResolving(this, CurrentTurn.ActivePlayer)));
                        
                    }
                    else if (CurrentTurn.ActivePlayer.TriggerAbilities.Count > 1)
                    {
                        throw new NotImplementedException("select ability to resolve");
                    }

                    if (CurrentTurn.NonActivePlayer.TriggerAbilities.Count == 1)
                    {
                        TriggerAbility ability = CurrentTurn.NonActivePlayer.TriggerAbilities.First();
                        return SetCurrentPlayerAction(TryToPerformAutomatically(ability.StartResolving(this, CurrentTurn.NonActivePlayer)));
                        //todo: remove ability from stack after it is has completely resolved

                        /*
                        if (ability.Effects.Count == 1)
                        {
                            return ability.StartResolving();
                            //todo: remove ability from stack after it is has completely resolved
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }*/
                    }
                    else if (CurrentTurn.NonActivePlayer.TriggerAbilities.Count > 1)
                    {
                        throw new NotImplementedException("select ability to resolve");
                    }

                    PlayerAction playerAction = CurrentTurn.CurrentStep.PlayerActionRequired(this);
                    if (playerAction != null)
                    {
                        return SetCurrentPlayerAction(TryToPerformAutomatically(playerAction));
                    }
                    else
                    {
                        if (CurrentTurn.ChangeStep())
                        {
                            return SetCurrentPlayerAction(StartNewTurn(CurrentTurn.NonActivePlayer, CurrentTurn.ActivePlayer));
                        }
                        else
                        {
                            PlayerAction action = CurrentTurn.CurrentStep.ProcessTurnBasedActions(this);
                            if (action != null)
                            {
                                return SetCurrentPlayerAction(TryToPerformAutomatically(action));
                            }
                            else
                            {
                                return SetCurrentPlayerAction(Progress());
                            }
                        }
                    }
                }
            }
            return SetCurrentPlayerAction(null);
        }

        private Player GetOwner(Card card)
        {
            if (Player1.DeckBeforeDuel.Select(c => c.GameId).Contains(card.GameId))
            {
                return Player1;
            }
            else if (Player2.DeckBeforeDuel.Select(c => c.GameId).Contains(card.GameId))
            {
                return Player2;
            }
            else
            {
                throw new ArgumentOutOfRangeException("card");
            }
        }

        /// <summary>
        /// Checks if selected mana cards have the required civilizations.
        /// </summary>
        private static bool HasCivilizations(Collection<Card> paymentCards, Collection<Civilization> requiredCivilizations)
        {
            if (paymentCards == null)
            {
                throw new ArgumentNullException("paymentCards");
            }
            else if (requiredCivilizations == null)
            {
                throw new ArgumentNullException("requiredCivilizations");
            }
            else
            {
                List<List<Civilization>> civilizationGroups = new List<List<Civilization>>();
                foreach (Card card in paymentCards)
                {
                    civilizationGroups.Add(card.Civilizations.ToList());
                }
                List<List<Civilization>> testi = GetCivilizationCombinations(civilizationGroups, new List<Civilization>());
                IEnumerable<IEnumerable<Civilization>> combinations = testi.Select(combination => combination.Distinct());
                foreach (IEnumerable<Civilization> combination in combinations)
                {
                    for (int i = 0; i < requiredCivilizations.Count; ++i)
                    {
                        if (!combination.Contains(requiredCivilizations[i]))
                        {
                            break;
                        }
                        else if (requiredCivilizations.Count - 1 == i)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        private static List<List<Civilization>> GetCivilizationCombinations(List<List<Civilization>> civilizationGroups, List<Civilization> knownCivilizations)
        {
            if (civilizationGroups.Count > 0)
            {
                List<Civilization> civilizations = civilizationGroups.First();
                List<List<Civilization>> newCivilizationGroups = new List<List<Civilization>>(civilizationGroups);
                newCivilizationGroups.Remove(civilizations);
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

        private PlayerAction SetCurrentPlayerAction(PlayerAction playerAction)
        {
            CurrentPlayerAction = playerAction;
            return playerAction;
        }

        private Collection<Card> GetAllCards()
        {
            List<Card> cards = Player1.DeckBeforeDuel.ToList();
            cards.AddRange(Player2.DeckBeforeDuel);
            return new Collection<Card>(cards);
        }

        private Collection<ContinuousEffect> GetContinuousEffects()
        {
            List<ContinuousEffect> continuousEffects = new List<ContinuousEffect>();
            foreach (Card card in GetAllCards())
            {
                foreach (StaticAbility staticAbility in card.StaticAbilities)
                {
                    if (staticAbility is StaticAbilityForCreature staticAbilityForCreature)
                    {
                        if (staticAbilityForCreature.ActivityCondition == StaticAbilityForCreatureActivityCondition.Anywhere ||
                            staticAbilityForCreature.ActivityCondition == StaticAbilityForCreatureActivityCondition.WhileThisCreatureIsInTheBattleZone && GetOwner(card).BattleZone.Cards.Contains(card))
                        {
                            continuousEffects.AddRange(staticAbility.ContinuousEffects);
                        }
                        else
                        {
                            throw new InvalidOperationException("staticAbilityForCreature");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("staticAbility");
                    }
                }
            }
            return new Collection<ContinuousEffect>(continuousEffects);
        }

        private Collection<Creature> GetAllBlockersPlayerHasInTheBattleZone(Player player)
        {
            List<Creature> blockers = new List<Creature>();
            IEnumerable<BlockerEffect> blockerEffects = GetContinuousEffects().Where(e => e is BlockerEffect).Cast<BlockerEffect>();
            /*foreach (CreatureContinuousEffect creatureContinuousEffect in blockerEffects)
            {

                blockers.AddRange(player.BattleZone.Creatures.Where( creatureContinuousEffect.CreatureFilter.FilteredCreatures);
            }*/
            foreach (Creature creature in player.BattleZone.Creatures)
            {
                foreach (CreatureContinuousEffect creatureContinuousEffect in blockerEffects)
                {
                    if (creatureContinuousEffect.CreatureFilter.FilteredCreatures.Contains(creature))
                    {
                        blockers.Add(creature);
                    }
                }
            }
            return new Collection<Creature>(blockers);
        }

        private void PutFromShieldZoneToHand(Player player, Card card)
        {
            player.ShieldZone.Remove(card);
            player.Hand.Add(card);
        }

        private bool HasShieldTrigger(Creature creature)
        {
            foreach (CreatureContinuousEffect creatureContinuousEffect in GetContinuousEffects().Where(e => e is CreatureShieldTriggerEffect).Cast<CreatureShieldTriggerEffect>())
            {
                if (creatureContinuousEffect.CreatureFilter.FilteredCreatures.Contains(creature))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasShieldTrigger(Spell spell)
        {
            throw new NotImplementedException();
            /*
            foreach (CreatureContinuousEffect creatureContinuousEffect in GetContinuousEffects().Where(e => e is CreatureShieldTriggerEffect).Cast<CreatureShieldTriggerEffect>())
            {
                if (creatureContinuousEffect.CreatureFilter.FilteredCreatures.Contains(spell))
                {
                    return true;
                }
            }
            return false;
            */
        }
        #endregion Private methods
    }
}