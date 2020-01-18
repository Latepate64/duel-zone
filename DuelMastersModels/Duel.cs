using DuelMastersModels.Abilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.GameActions.StateBasedActions;
using DuelMastersModels.Managers;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActionResponses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// Specifies the player who goes first in the duel.
    /// </summary>
    public enum StartingPlayer
    {
        /// <summary>
        /// Player who goes first is randomized.
        /// </summary>
        Random = 0,

        /// <summary>
        /// Player 1 goes first.
        /// </summary>
        Player1 = 1,

        /// <summary>
        /// Player 2 goes first.
        /// </summary>
        Player2 = 2,
    }

    /// <summary>
    /// Represents the state of a duel.
    /// </summary>
    public enum DuelState
    {
        /// <summary>
        /// Duel has not started yet.
        /// </summary>
        Setup,

        /// <summary>
        /// Duel is in progress.
        /// </summary>
        InProgress,

        /// <summary>
        /// Duel is over.
        /// </summary>
        Over,
    }

    /// <summary>
    /// Represents a duel that is played between two players.
    /// </summary>
    public class Duel
    {
        /// <summary>
        /// Event which is raised whenever an important event during the duel occurs.
        /// </summary>
        public event EventHandler<DuelEventArgs> DuelEventOccurred;

        #region Properties
        #region Public
        /// <summary>
        /// A player that participates in duel against player 2.
        /// </summary>
        public Player Player1 => _playerManager.Player1;

        /// <summary>
        /// A player that participates in duel against player 1.
        /// </summary>
        public Player Player2 => _playerManager.Player2;

        /// <summary>
        /// Player who won the duel.
        /// </summary>
        public Player Winner { get; private set; }

        /// <summary>
        /// Determines the state of the duel.
        /// </summary>
        public DuelState State { get; private set; } = DuelState.Setup;

        /// <summary>
        /// The number of shields each player has at the start of a duel. 
        /// </summary>
        public int InitialNumberOfShields { get; set; } = 5;

        /// <summary>
        /// The number of cards each player draw at the start of a duel.
        /// </summary>
        public int InitialNumberOfHandCards { get; set; } = 5;

        /// <summary>
        /// Determines which player goes first in the duel.
        /// </summary>
        public StartingPlayer StartingPlayer { get; set; } = StartingPlayer.Random;
        #endregion Public

        #region Internal
        /// <summary>
        /// All creatures that are in the battle zone.
        /// </summary>
        internal ReadOnlyCreatureCollection CreaturesInTheBattleZone
        {
            get
            {
                List<Creature> creatures = Player1.BattleZone.Creatures.ToList();
                creatures.AddRange(Player2.BattleZone.Creatures);
                return new ReadOnlyCreatureCollection(creatures);
            }
        }

        /// <summary>
        /// The turn that is currently being processed.
        /// </summary>
        internal Turn CurrentTurn => _turnManager.CurrentTurn;
        #endregion Internal
        #endregion Properties

        #region Fields
        /// <summary>
        /// Players who lost the duel.
        /// </summary>
        private readonly Collection<Player> _losers = new Collection<Player>();

        /// <summary>
        /// Spells that are being resolved.
        /// </summary>
        private readonly SpellCollection _spellsBeingResolved = new SpellCollection();

        private readonly AbilityManager _abilityManager = new AbilityManager();

        private readonly ContinuousEffectManager _continuousEffectManager = new ContinuousEffectManager();

        private readonly PlayerActionManager _playerActionManager = new PlayerActionManager();

        private readonly PlayerManager _playerManager;

        private readonly TurnManager _turnManager = new TurnManager();
        #endregion Fields

        /// <summary>
        /// Creates a duel.
        /// </summary>
        /// <param name="player1">One of the two playes.</param>
        /// <param name="player2">Another one of the two players.</param>
        public Duel(Player player1, Player player2)
        {
            _playerManager = new PlayerManager(player1 ?? throw new ArgumentNullException(nameof(player1)), player2 ?? throw new ArgumentNullException(nameof(player2)));
            _abilityManager.InstantiateAbilities(Player1);
            _abilityManager.InstantiateAbilities(Player2);
        }

        #region Public methods
        /// <summary>
        /// Starts the duel.
        /// </summary>
        /// <returns>Action a player is expected to perform.</returns>
        public PlayerAction Start()
        {
            if (State != DuelState.Setup)
            {
                throw new InvalidOperationException($"Could not start duel as state was {State.ToString()} instead of setup.");
            }
            State = DuelState.InProgress;
            Player activePlayer = Player1;
            Player nonActivePlayer = Player2;

            if (StartingPlayer == StartingPlayer.Random)
            {
                const int RandomMax = 100;
                int randomNumber = new Random().Next(0, RandomMax);
                StartingPlayer = (randomNumber % 2 == 0) ? StartingPlayer.Player1 : StartingPlayer.Player2;
            }

            if (StartingPlayer == StartingPlayer.Player2)
            {
                activePlayer = Player2;
                nonActivePlayer = Player1;
            }
            else if (StartingPlayer != StartingPlayer.Player1)
            {
                throw new InvalidOperationException();
            }

            activePlayer.ShuffleDeck();
            nonActivePlayer.ShuffleDeck();
            PutFromTheTopOfDeckIntoShieldZone(activePlayer, InitialNumberOfShields);
            PutFromTheTopOfDeckIntoShieldZone(nonActivePlayer, InitialNumberOfShields);

            //TODO: Animation
            DrawCards(activePlayer, InitialNumberOfHandCards);
            DrawCards(nonActivePlayer, InitialNumberOfHandCards);

            return SetCurrentPlayerAction(StartNewTurn(activePlayer, nonActivePlayer));
        }

        /// <summary>
        /// Tries to progress in the duel based on the latest player action, and returns new player action for a player to take.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public PlayerAction Progress(PlayerActionResponse response)
        {
            if (State != DuelState.InProgress)
            {
                throw new InvalidOperationException($"Could not progress in duel duel as state was {State.ToString()} instead of in progress.");
            }
            PlayerAction playerAction = _playerActionManager.Progress(response, this);
            return playerAction == null ? SetCurrentPlayerAction(Progress()) : SetCurrentPlayerAction(TryToPerformAutomatically(playerAction));
        }
        #endregion Public methods

        #region Internal methods
        #region Player
        /// <summary>
        /// Returns the opponent of a player.
        /// </summary>
        internal Player GetOpponent(Player player)
        {
            return _playerManager.GetOpponent(player);
        }

        /// <summary>
        /// Returns the player who owns target card.
        /// </summary>
        /// <param name="card">Card whose owner is queried.</param>
        /// <returns>Player who owns the card.</returns>
        internal Player GetOwner(Card card)
        {
            return _playerManager.GetOwner(card);
        }
        #endregion Player

        #region void
        /// <summary>
        /// Ends the duel.
        /// </summary>
        internal void End(Player winner)
        {
            Winner = winner;
            _losers.Add(GetOpponent(winner));
            State = DuelState.Over;
        }

        /// <summary>
        /// Ends duel in a draw.
        /// </summary>
        internal void EndDuelInDraw()
        {
            _losers.Add(Player1);
            _losers.Add(Player2);
            State = DuelState.Over;
        }

        /// <summary>
        /// Target player puts target card from their hand into their mana zone.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        internal void PutFromHandIntoManaZone(Player player, Card card)
        {
            player.Hand.Remove(card, this);
            player.ManaZone.Add(card, this);
        }

        /// <summary>
        /// Manages a battle between two creatures.
        /// </summary>
        /// <param name="attackingCreature">Creature which initiated the attack.</param>
        /// <param name="defendingCreature">Creature which the attack was directed at.</param>
        /// <param name="attackingPlayer"></param>
        /// <param name="defendingPlayer"></param>
        internal void Battle(Creature attackingCreature, Creature defendingCreature, Player attackingPlayer, Player defendingPlayer)
        {
            int attackingCreaturePower = GetPower(attackingCreature);
            int defendingCreaturePower = GetPower(defendingCreature);
            //TODO: Handle destruction as a state-based action. 703.4d
            if (attackingCreaturePower > defendingCreaturePower)
            {
                PutFromBattleZoneIntoGraveyard(defendingPlayer, defendingCreature);
            }
            else if (attackingCreaturePower < defendingCreaturePower)
            {
                PutFromBattleZoneIntoGraveyard(attackingPlayer, attackingCreature);
            }
            else
            {
                PutFromBattleZoneIntoGraveyard(attackingPlayer, attackingCreature);
                PutFromBattleZoneIntoGraveyard(defendingPlayer, defendingCreature);
            }
        }

        /// <summary>
        /// Card is used based on its type: A creature is put into the battle zone; A spell is put into your graveyard.
        /// </summary>
        /// <param name="card"></param>
        internal void UseCard(ICard card)
        {
            if (card is Creature creature)
            {
                GetOwner(creature).BattleZone.Add(creature, this);
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
        internal void AddFromYourHandToYourShieldsFaceDown(Card card)
        {
            Player owner = GetOwner(card);
            owner.Hand.Remove(card, this);
            owner.ShieldZone.Add(card, this);
        }

        internal void EndContinuousEffects<T>()
        {
            _continuousEffectManager.EndContinuousEffects<T>();
        }

        internal void AddContinuousEffect(ContinuousEffect continuousEffect)
        {
            _continuousEffectManager.AddContinuousEffect(continuousEffect);
        }

        internal void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(Creature creature)
        {
            _abilityManager.TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(creature);
        }

        internal void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(Creature excludedCreature)
        {
            _abilityManager.TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(new ReadOnlyCollection<Creature>(CreaturesInTheBattleZone.Except(new List<Creature>() { excludedCreature }).ToList()));
        }

        internal void SetPendingAbilityToBeResolved(NonStaticAbility ability)
        {
            _abilityManager.RemovePendingAbility(ability);
            _abilityManager.SetAbilityBeingResolved(ability);
        }
        #endregion void

        #region bool
        /// <summary>
        /// Checks if a card can be used.
        /// </summary>
        internal static bool CanBeUsed(Card card, ReadOnlyCardCollection manaCards)
        {
            //TODO: Remove static keyword after usability is checked with continuous effects considered.
            //System.Collections.Generic.IEnumerable<Civilization> manaCivilizations = manaCards.SelectMany(manaCard => manaCard.Civilizations).Distinct();
            //return card.Cost <= manaCards.Count && card.Civilizations.Intersect(manaCivilizations).Count() == 1; //TODO: Add support for multicolored cards.
            return card.Cost <= manaCards.Count && HasCivilizations(manaCards, card.Civilizations);
        }

        internal bool CanAttackOpponent(Creature creature)
        {
            ReadOnlyCreatureCollection creaturesThatCannotAttackPlayers = _continuousEffectManager.GetCreaturesThatCannotAttackPlayers(this, _abilityManager);
            return !AffectedBySummoningSickness(creature) && !creaturesThatCannotAttackPlayers.Contains(creature);
        }

        internal bool AttacksIfAble(Creature creature)
        {
            return _continuousEffectManager.AttacksIfAble(this, _abilityManager, creature);
        }
        #endregion bool

        #region ReadOnlyCreatureCollection
        internal ReadOnlyCreatureCollection GetCreaturesThatCanBlock(Creature attackingCreature)
        {
            return new ReadOnlyCreatureCollection(GetAllBlockersPlayerHasInTheBattleZone(GetOpponent(GetOwner(attackingCreature))).Where(c => !c.Tapped).ToList());
            //TODO: consider situations where abilities of attacking creature matter etc.
        }

        internal ReadOnlyCreatureCollection GetCreaturesThatCanAttack(Player player)
        {
            ReadOnlyCreatureCollection creaturesThatCannotAttack = _continuousEffectManager.GetCreaturesThatCannotAttack(this, _abilityManager, player);
            return new ReadOnlyCreatureCollection(player.BattleZone.UntappedCreatures.Where(creature => !AffectedBySummoningSickness(creature) && !creaturesThatCannotAttack.Contains(creature)).ToList());
        }

        internal ReadOnlyCreatureCollection GetCreaturesThatCanBeAttacked(Player player)
        {
            Player opponent = GetOpponent(player);
            return opponent.BattleZone.TappedCreatures;
            //TODO: Consider attacking creature
        }
        #endregion ReadOnlyCreatureCollection

        #region PlayerAction
        /// <summary>
        /// Player draws a card.
        /// </summary>
        internal PlayerAction DrawCard(Player player)
        {
            DrawCards(player, 1);
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

        internal PlayerAction PutFromShieldZoneToHand(Player player, Card card, bool canUseShieldTrigger)
        {
            return PutFromShieldZoneToHand(player, new ReadOnlyCardCollection(card), canUseShieldTrigger);
        }

        internal PlayerAction PutFromShieldZoneToHand(Player player, ReadOnlyCardCollection cards, bool canUseShieldTrigger)
        {
            CardCollection shieldTriggerCards = new CardCollection();
            for (int i = 0; i < cards.Count; ++i)
            {
                Card card = cards[i];
                PutFromShieldZoneToHand(player, card);
                if (canUseShieldTrigger && HasShieldTrigger(card))
                {
                    shieldTriggerCards.Add(card);
                }
            }
            return shieldTriggerCards.Count > 0 ? new DeclareShieldTriggers(player, new ReadOnlyCardCollection(shieldTriggerCards)) : null;
        }

        internal PlayerAction PutTheTopCardOfYourDeckIntoYourManaZone(Player player)
        {
            player.ManaZone.Add(RemoveTheTopCardOfDeck(player), this);
            return null;
        }

        internal PlayerAction ReturnFromBattleZoneToHand(Creature creature)
        {
            Player owner = GetOwner(creature);
            owner.BattleZone.Remove(creature, this);
            owner.Hand.Add(creature, this);
            return null;
        }

        internal PlayerAction PutFromBattleZoneIntoOwnersManazone(Creature creature)
        {
            Player owner = GetOwner(creature);
            owner.BattleZone.Remove(creature, this);
            owner.ManaZone.Add(creature, this);
            return null;
        }

        internal PlayerAction PutFromManaZoneIntoTheBattleZone(Creature creature)
        {
            Player owner = GetOwner(creature);
            owner.ManaZone.Remove(creature, this);
            owner.BattleZone.Add(creature, this);
            return null;
        }

        internal PlayerAction AddTheTopCardOfYourDeckToYourShieldsFaceDown(Player player)
        {
            PutFromTheTopOfDeckIntoShieldZone(player, 1);
            return null;
        }
        #endregion PlayerAction

        internal int GetPower(Creature creature)
        {
            return _continuousEffectManager.GetPower(this, _abilityManager, creature);
        }

        internal ReadOnlyCardCollection GetAllCards()
        {
            List<Card> cards = Player1.DeckBeforeDuel.ToList();
            cards.AddRange(Player2.DeckBeforeDuel);
            return new ReadOnlyCardCollection(cards);
        }
        #endregion Internal methods

        #region Private methods
        #region void
        ///<summary>
        /// Removes the top cards from a player's deck and puts them into their shield zone.
        ///</summary>
        private void PutFromTheTopOfDeckIntoShieldZone(Player player, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                player.ShieldZone.Add(RemoveTheTopCardOfDeck(player), this);
            }
        }

        /// <summary>
        /// A player draws a number of cards.
        /// </summary>
        private void DrawCards(Player player, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                Card drawnCard = RemoveTheTopCardOfDeck(player);
                player.Hand.Add(drawnCard, this);
                DuelEventOccurred?.Invoke(this, new DuelEventArgs(new DrawCardEvent(player, drawnCard)));
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

        private void PutFromBattleZoneIntoGraveyard(Player player, Creature creature)
        {
            player.BattleZone.Remove(creature, this);
            player.Graveyard.Add(creature, this);
        }

        private void PutFromShieldZoneToHand(Player player, Card card)
        {
            player.ShieldZone.Remove(card, this);
            player.Hand.Add(card, this);
        }
        #endregion void

        #region PlayerAction
        private PlayerAction TryToPerformAutomatically(PlayerAction playerAction)
        {
            PlayerAction newPlayerAction = playerAction.TryToPerformAutomatically(this);
            if (playerAction == newPlayerAction)
            {
                //Player action was not performed automatically.
                if (playerAction.Player is AIPlayer aiPlayer)
                {
                    PlayerAction aiAction = aiPlayer.PerformPlayerAction(this, newPlayerAction);
                    return aiAction != null ? TryToPerformAutomatically(aiAction) : Progress();
                }
                else
                {
                    return playerAction;
                }
            }
            else
            {
                return newPlayerAction != null ? TryToPerformAutomatically(newPlayerAction) : Progress();
            }
        }

        /// <summary>
        /// Progresses in the duel.
        /// </summary>
        /// <returns>A player request for a player to perform an action. Returns null if there is nothing left to do in the duel.</returns>
        private PlayerAction Progress()
        {
            if (State == DuelState.InProgress)
            {
                CheckStateBasedActions();
                return State == DuelState.InProgress ? ProgressAfterStateBasedActions() : Progress();
            }
            else if (State == DuelState.Over)
            {
                return null;
            }
            else
            {
                throw new InvalidOperationException($"Duel is in invalid state for progression. State: {State.ToString()}");
            }
        }

        private PlayerAction ContinueResolvingAbility()
        {
            PlayerActionWithEndInformation action = _abilityManager.ContinueResolution(this);
            if (!action.ResolutionOver)
            {
                //TODO: test
                return action.PlayerAction != null ? TryToPerformAutomatically(action.PlayerAction) : Progress();
            }
            else
            {
                FinishResolvingAbility();
                return null;
            }
        }

        private PlayerAction TryToUseShieldTrigger()
        {
            foreach (Player player in new List<Player>() { CurrentTurn.ActivePlayer, CurrentTurn.NonActivePlayer }.Where(player => player.ShieldTriggersToUse.Count > 0))
            {
                return TryToPerformAutomatically(new UseShieldTrigger(player, new ReadOnlyCardCollection(player.ShieldTriggersToUse)));
            }
            return null;
        }

        private PlayerAction ProgressAfterStateBasedActions()
        {
            PlayerAction tryToUseShieldTrigger = TryToUseShieldTrigger();
            if (tryToUseShieldTrigger != null)
            {
                return tryToUseShieldTrigger;
            }

            if (_abilityManager.IsAbilityBeingResolved)
            {
                PlayerAction action = ContinueResolvingAbility();
                if (action != null)
                {
                    return action;
                }
            }

            if (_spellsBeingResolved.Count > 0)
            {
                PlayerAction resolveSpellAbility = TryToResolveSpellAbility();
                if (resolveSpellAbility != null)
                {
                    return resolveSpellAbility;
                }
            }

            PlayerAction selectAbilityToResolve = TryToSelectAbilityToResolve();
            return selectAbilityToResolve ?? TryToPerformStepAction();
        }

        private PlayerAction TryToSelectAbilityToResolve()
        {
            foreach (Player player in new List<Player>() { CurrentTurn.ActivePlayer, CurrentTurn.NonActivePlayer })
            {
                SelectAbilityToResolve selectAbilityToResolve = _abilityManager.TryGetSelectAbilityToResolve(player);
                if (selectAbilityToResolve != null)
                {
                    return TryToPerformAutomatically(selectAbilityToResolve);
                }
            }
            return null;
        }

        private PlayerAction TryToPerformStepAction()
        {
            PlayerAction playerAction = CurrentTurn.CurrentStep.PlayerActionRequired(this);
            return playerAction != null ? TryToPerformAutomatically(playerAction) : ChangeStep();
        }

        private PlayerAction TryToResolveSpellAbility()
        {
            Spell spell = _spellsBeingResolved.Last();
            if (_abilityManager.GetSpellAbilityCount(spell) > 0)
            {
                return StartResolvingSpellAbility(spell);
            }
            else
            {
                _spellsBeingResolved.Remove(spell);
                GetOwner(spell).Graveyard.Add(spell, this);
                return null;
            }
        }

        private PlayerAction StartResolvingSpellAbility(Spell spell)
        {
            _abilityManager.StartResolvingSpellAbility(spell);
            return Progress();
        }

        private PlayerAction ChangeStep()
        {
            if (CurrentTurn.ChangeStep())
            {
                return StartNewTurn(CurrentTurn.NonActivePlayer, CurrentTurn.ActivePlayer);
            }
            else
            {
                PlayerAction action = CurrentTurn.CurrentStep.ProcessTurnBasedActions(this);
                return action != null ? TryToPerformAutomatically(action) : Progress();
            }
        }

        private void FinishResolvingAbility()
        {
            if (_abilityManager.IsAbilityBeingResolvedSpellAbility)
            {
                Spell spell = _spellsBeingResolved.Last();
                _spellsBeingResolved.Remove(spell);
                GetOwner(spell).Graveyard.Add(spell, this);
            }
            SetPendingAbilityToBeResolved(null);
        }

        private PlayerAction SetCurrentPlayerAction(PlayerAction playerAction)
        {
            _playerActionManager.SetCurrentPlayerAction(playerAction);
            return playerAction;
        }

        /// <summary>
        /// Creates a new turn and starts it.
        /// </summary>
        private PlayerAction StartNewTurn(Player activePlayer, Player nonActivePlayer)
        {
            PlayerAction playerAction = _turnManager.StartNewTurn(activePlayer, nonActivePlayer, this);
            return playerAction != null ? TryToPerformAutomatically(playerAction) : Progress();
        }

        /*
        private PlayerAction PutTheTopCardOfYourDeckIntoYourManaZoneThenAddTheTopCardOfYourDeckToYourShieldsFaceDown(Player player)
        {
            player.ManaZone.Add(RemoveTheTopCardOfDeck(player), this);
            return new AddTheTopCardOfYourDeckToYourShieldsFaceDown(player);
        }
        */
        #endregion PlayerAction

        #region bool
        /// <summary>
        /// Checks if selected mana cards have the required civilizations.
        /// </summary>
        private static bool HasCivilizations(ReadOnlyCardCollection paymentCards, ReadOnlyCivilizationCollection requiredCivilizations)
        {
            List<List<Civilization>> civilizationGroups = new List<List<Civilization>>();
            foreach (Card card in paymentCards)
            {
                civilizationGroups.Add(card.Civilizations.ToList());
            }
            foreach (IEnumerable<Civilization> combination in GetCivilizationCombinations(civilizationGroups, new List<Civilization>()).Select(combination => combination.Distinct()))
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

        private bool HasShieldTrigger(Creature creature)
        {
            return _continuousEffectManager.HasShieldTrigger(this, _abilityManager, creature);
        }

        private bool HasShieldTrigger(Spell spell)
        {
            return _continuousEffectManager.HasShieldTrigger(this, _abilityManager, spell);
        }

        private bool HasShieldTrigger(ICard card)
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
            return _continuousEffectManager.HasSpeedAttacker(this, _abilityManager, creature);
        }

        private bool AffectedBySummoningSickness(Creature creature)
        {
            return creature.SummoningSickness && !HasSpeedAttacker(creature);
        }
        #endregion bool

        /// <summary>
        /// Removes the top card from a player's deck and returns it.
        /// </summary>
        private Card RemoveTheTopCardOfDeck(Player player)
        {
            return player.Deck.RemoveAndGetTopCard(this);
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

        private ReadOnlyCreatureCollection GetAllBlockersPlayerHasInTheBattleZone(Player player)
        {
            return _continuousEffectManager.GetAllBlockersPlayerHasInTheBattleZone(player, this, _abilityManager);
        }

        private void CastSpell(Spell spell)
        {
            _spellsBeingResolved.Add(spell);
            _abilityManager.TriggerWheneverAPlayerCastsASpellAbilities(CreaturesInTheBattleZone);
        }
        #endregion Private methods
    }
}
