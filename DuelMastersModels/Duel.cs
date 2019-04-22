using DuelMastersModels.Cards;
using DuelMastersModels.GameActions.StateBasedActions;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActionResponses;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// Represents a duel that is played between two players.
    /// </summary>
    public class Duel
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
        public Turn CurrentTurn
        {
            get
            {
                return Turns.Last();
            }
        }

        /// <summary>
        /// The number of shields each player has at the start of a duel. 
        /// </summary>
        public int InitialNumberOfShields { get; set; } = 5;

        /// <summary>
        /// The number of cards each player draw at the start of a duel.
        /// </summary>
        public int InitialNumberOfHandCards { get; set; } = 5;

        public PlayerAction CurrentPlayerAction { get; set; }
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
            var turn = new Turn(activePlayer, nonActivePlayer, Turns.Count + 1);
            Turns.Add(turn);
            var playerAction = turn.Start(this);
            if (playerAction != null)
            {
                return PerformAutomatically(playerAction);
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
        public static void DrawCard(Player player)
        {
            DrawCards(player, 1);
        }

        private PlayerAction SetCurrentPlayerAction(PlayerAction playerAction)
        {
            CurrentPlayerAction = playerAction;
            return playerAction;
        }

        public PlayerAction Progress(PlayerActionResponse response)
        {
            if (response is CardSelectionResponse cardSelectionResponse)
            {
                Card card = null;
                if (cardSelectionResponse.SelectedCards.Count == 1)
                {
                    card = cardSelectionResponse.SelectedCards.First();
                }
                if (CurrentPlayerAction is OptionalCardSelection optionalCardSelection)
                {
                    optionalCardSelection.Perform(this, card);
                }
                else
                {
                    throw new InvalidOperationException();
                }
                
            }
            else if (response is DeclareAttackResponse declareAttackResponse)
            {
                (CurrentPlayerAction as DeclareAttack).Declare(this, declareAttackResponse.Attacker, declareAttackResponse.TargetOfAttack);
            }
            else
            {
                throw new ArgumentOutOfRangeException("response");
            }
            return SetCurrentPlayerAction(Progress());
        }

        /// <summary>
        /// Progresses in the duel.
        /// </summary>
        /// <returns>A player request for a player to perform an action. Returns null if there is nothing left to do in the duel.</returns>
        public PlayerAction Progress()
        {
            if (!Ended)
            {
                CheckStateBasedActions();
                if (!Ended)
                {
                    var playerAction = CurrentTurn.CurrentStep.PlayerActionRequired(this);
                    if (playerAction != null)
                    {
                        return SetCurrentPlayerAction(PerformAutomatically(playerAction));
                    }
                    else
                    {
                        if (CurrentTurn.ChangeStep())
                        {
                            return SetCurrentPlayerAction(StartNewTurn(CurrentTurn.NonActivePlayer, CurrentTurn.ActivePlayer));
                        }
                        else
                        {
                            var action = CurrentTurn.CurrentStep.ProcessTurnBasedActions(this);
                            if (action != null)
                            {
                                return SetCurrentPlayerAction(PerformAutomatically(action));
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
        #endregion Public methods

        #region Private methods
        ///<summary>
        /// Removes the top cards from a player's deck and puts them into their shield zone.
        ///</summary>
        private static void PutFromTheTopOfDeckIntoShieldZone(Player player, int amount)
        {
            for (var i = 0; i < amount; ++i)
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
            for (var i = 0; i < amount; ++i)
            {
                player.Hand.Add(RemoveTheTopCardOfDeck(player));
            }
        }

        /// <summary>
        /// 703.3. The game always checks for any of the listed conditions for state-based actions, then performs all applicable state-based actions simultaneously as a single event. If any state-based actions are performed as a result of a check, the check is repeated.
        /// </summary>
        private void CheckStateBasedActions()
        {
            var checkDeckHasCards = new CheckDeckHasCards();
            checkDeckHasCards.Perform(this);
        }

        private PlayerAction PerformAutomatically(PlayerAction playerAction)
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
        #endregion Private methods
    }
}
