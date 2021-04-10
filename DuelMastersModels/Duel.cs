using DuelMastersModels.Abilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Factories;
using DuelMastersModels.GameActions.StateBasedActions;
using DuelMastersModels.Managers;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// Represents a duel that is played between two players.
    /// </summary>
    public class Duel : IDuel
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
        public IPlayer Player1 => _playerManager.Player1;

        /// <summary>
        /// A player that participates in duel against player 1.
        /// </summary>
        public IPlayer Player2 => _playerManager.Player2;

        /// <summary>
        /// Player who won the duel.
        /// </summary>
        public IPlayer Winner { get; private set; }

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

        /// <summary>
        /// The turn that is currently being processed.
        /// </summary>
        public ITurn CurrentTurn => _turnManager.CurrentTurn;
        #endregion Public

        /// <summary>
        /// All creatures that are in the battle zone.
        /// </summary>
        public IEnumerable<IBattleZoneCreature> CreaturesInTheBattleZone
        {
            get
            {
                List<IBattleZoneCreature> creatures = Player1.BattleZone.Creatures.OfType<IBattleZoneCreature>().ToList();
                creatures.AddRange(Player2.BattleZone.Creatures);
                return new ReadOnlyCollection<IBattleZoneCreature>(creatures);
            }
        }
        #endregion Properties

        #region Fields
        /// <summary>
        /// Players who lost the duel.
        /// </summary>
        private readonly Collection<IPlayer> _losers = new Collection<IPlayer>();

        /// <summary>
        /// Spells that are being resolved.
        /// </summary>
        private readonly Collection<ISpell> _spellsBeingResolved = new Collection<ISpell>();

        private readonly AbilityManager _abilityManager = new AbilityManager();

        private readonly ContinuousEffectManager _continuousEffectManager = new ContinuousEffectManager();

        private readonly PlayerActionManager _playerActionManager;

        private readonly IPlayerManager _playerManager;

        private readonly TurnManager _turnManager = new TurnManager();
        #endregion Fields

        /// <summary>
        /// Creates a duel.
        /// </summary>
        /// <param name="player1">One of the two playes.</param>
        /// <param name="player2">Another one of the two players.</param>
        public Duel(IPlayer player1, Player player2)
        {
            _playerActionManager = new PlayerActionManager(this);
            _playerManager = new PlayerManager(player1 ?? throw new ArgumentNullException(nameof(player1)), player2 ?? throw new ArgumentNullException(nameof(player2)));
        }

        #region Public methods
        /// <summary>
        /// Starts the duel.
        /// </summary>
        /// <returns>Action a player is expected to perform.</returns>
        public IPlayerAction Start()
        {
            if (State != DuelState.Setup)
            {
                throw new InvalidOperationException($"Could not start duel as state was {State.ToString()} instead of setup.");
            }
            State = DuelState.InProgress;
            IPlayer activePlayer = Player1;
            IPlayer nonActivePlayer = Player2;

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
        /// Tries to progress in the duel.
        /// </summary>
        /// <returns></returns>
        public IPlayerAction Progress<T>() where T : class, ICard
        {
            //return _playerActionManager.Progress<T>();
            return Progress(new List<T>());
        }

        /// <summary>
        /// Tries to progress in the duel.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="card"></param>
        /// <returns></returns>
        public IPlayerAction Progress<T>(T card) where T : class, ICard
        {
            return Progress(new List<T>() { card });
        }

        /// <summary>
        /// Tries to progress in the duel.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cards"></param>
        /// <returns></returns>
        public IPlayerAction Progress<T>(IEnumerable<T> cards) where T : class, ICard
        {
            ValidateStateForProgressing();
            IPlayerAction playerAction = _playerActionManager.Progress(cards);
            return playerAction == null ? SetCurrentPlayerAction(ProgressPrivate()) : SetCurrentPlayerAction(TryToPerformAutomatically(playerAction));
        }
        #endregion Public methods

        #region Internal methods
        #region Player
        /// <summary>
        /// Returns the opponent of a player.
        /// </summary>
        public IPlayer GetOpponent(IPlayer player)
        {
            return _playerManager.GetOpponent(player);
        }

        /// <summary>
        /// Returns the player who owns target card.
        /// </summary>
        /// <param name="card">Card whose owner is queried.</param>
        /// <returns>Player who owns the card.</returns>
        public IPlayer GetOwner(ICard card)
        {
            return _playerManager.GetOwner(card);
        }
        #endregion Player

        #region void
        /// <summary>
        /// Ends the duel.
        /// </summary>
        public void End(IPlayer winner)
        {
            Winner = winner;
            _losers.Add(GetOpponent(winner));
            State = DuelState.Over;
        }

        /// <summary>
        /// Ends duel in a draw.
        /// </summary>
        public void EndDuelInDraw()
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
        public void PutFromHandIntoManaZone(IPlayer player, IHandCard card)
        {
            player.Hand.Remove(card, this);
            player.ManaZone.Add(CardFactory.GenerateManaZoneCard(card), this);
        }

        /// <summary>
        /// Manages a battle between two creatures.
        /// </summary>
        /// <param name="attackingCreature">Creature which initiated the attack.</param>
        /// <param name="defendingCreature">Creature which the attack was directed at.</param>
        /// <param name="attackingPlayer"></param>
        /// <param name="defendingPlayer"></param>
        public void Battle(IBattleZoneCreature attackingCreature, IBattleZoneCreature defendingCreature, IPlayer attackingPlayer, IPlayer defendingPlayer)
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
        /// <param name="player"></param>
        /// <param name="card"></param>
        public void UseCard(IPlayer player, ICard card)
        {
            if (card is ICreature creature)
            {
                player.BattleZone.Add(new BattleZoneCreature(creature), this);
            }
            else if (card is ISpell spell)
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
        public void AddFromYourHandToYourShieldsFaceDown(IHandCard card)
        {
            IPlayer owner = GetOwner(card);
            owner.Hand.Remove(card, this);
            owner.ShieldZone.Add(CardFactory.GenerateShieldZoneCard(card, true), this);
        }

        public void EndContinuousEffects<T>()
        {
            _continuousEffectManager.EndContinuousEffects<T>();
        }

        public void AddContinuousEffect(IContinuousEffect continuousEffect)
        {
            _continuousEffectManager.AddContinuousEffect(continuousEffect);
        }

        public void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(IBattleZoneCreature creature)
        {
            _abilityManager.TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(creature);
        }

        public void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(IBattleZoneCreature excludedCreature)
        {
            _abilityManager.TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(new ReadOnlyCollection<IBattleZoneCreature>(CreaturesInTheBattleZone.Except(new List<IBattleZoneCreature>() { excludedCreature }).ToList()));
        }

        public void SetPendingAbilityToBeResolved(INonStaticAbility ability)
        {
            _abilityManager.RemovePendingAbility(ability);
            _abilityManager.SetAbilityBeingResolved(ability);
        }
        #endregion void

        #region bool
        /// <summary>
        /// Checks if a card can be used.
        /// </summary>
        internal static bool CanBeUsed(ICard card, IEnumerable<IManaZoneCard> manaCards)
        {
            //TODO: Remove static keyword after usability is checked with continuous effects considered.
            //System.Collections.Generic.IEnumerable<Civilization> manaCivilizations = manaCards.SelectMany(manaCard => manaCard.Civilizations).Distinct();
            //return card.Cost <= manaCards.Count && card.Civilizations.Intersect(manaCivilizations).Count() == 1; //TODO: Add support for multicolored cards.
            return card.Cost <= manaCards.Count() && HasCivilizations(manaCards, card.Civilizations);
        }

        public bool CanAttackOpponent(IBattleZoneCreature creature)
        {
            IEnumerable<IBattleZoneCreature> creaturesThatCannotAttackPlayers = _continuousEffectManager.GetCreaturesThatCannotAttackPlayers(this, _abilityManager);
            return !AffectedBySummoningSickness(creature) && !creaturesThatCannotAttackPlayers.Contains(creature);
        }

        public bool AttacksIfAble(IBattleZoneCreature creature)
        {
            return _continuousEffectManager.AttacksIfAble(this, _abilityManager, creature);
        }
        #endregion bool

        #region ReadOnlyCreatureCollection
        public IEnumerable<IBattleZoneCreature> GetCreaturesThatCanBlock(IBattleZoneCreature attackingCreature)
        {
            return new ReadOnlyCollection<BattleZoneCreature>(GetAllBlockersPlayerHasInTheBattleZone(GetOpponent(GetOwner(attackingCreature))).Where(c => !c.Tapped).ToList());
            //TODO: consider situations where abilities of attacking creature matter etc.
        }

        public IEnumerable<IBattleZoneCreature> GetCreaturesThatCanAttack(IPlayer player)
        {
            IEnumerable<IBattleZoneCreature> creaturesThatCannotAttack = _continuousEffectManager.GetCreaturesThatCannotAttack(this, _abilityManager, player);
            return new ReadOnlyCollection<BattleZoneCreature>(player.BattleZone.UntappedCreatures.Where(creature => !AffectedBySummoningSickness(creature) && !creaturesThatCannotAttack.Contains(creature)).ToList());
        }

        public IEnumerable<IBattleZoneCreature> GetCreaturesThatCanBeAttacked(IPlayer player)
        {
            IPlayer opponent = GetOpponent(player);
            return opponent.BattleZone.TappedCreatures;
            //TODO: Consider attacking creature
        }
        #endregion ReadOnlyCreatureCollection

        #region PlayerAction
        /// <summary>
        /// Player draws a card.
        /// </summary>
        public IPlayerAction DrawCard(IPlayer player)
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

        public IPlayerAction PutFromShieldZoneToHand(IPlayer player, IShieldZoneCard card, bool canUseShieldTrigger)
        {
            return PutFromShieldZoneToHand(player, new List<IShieldZoneCard>() { card }, canUseShieldTrigger);
        }

        public IPlayerAction PutFromShieldZoneToHand(IPlayer player, IEnumerable<IShieldZoneCard> cards, bool canUseShieldTrigger)
        {
            Collection<IHandCard> shieldTriggerCards = new Collection<IHandCard>();
            for (int i = 0; i < cards.Count(); ++i)
            {
                IHandCard handCard = PutFromShieldZoneToHand(player, cards.ElementAt(i));
                if (canUseShieldTrigger && HasShieldTrigger(handCard))
                {
                    shieldTriggerCards.Add(handCard);
                }
            }
            return shieldTriggerCards.Any() ? new DeclareShieldTriggers(player, new ReadOnlyCollection<IHandCard>(shieldTriggerCards)) : null;
        }

        public IPlayerAction PutTheTopCardOfYourDeckIntoYourManaZone(IPlayer player)
        {
            player.ManaZone.Add(CardFactory.GenerateManaZoneCard(RemoveTheTopCardOfDeck(player)), this);
            return null;
        }

        public IPlayerAction ReturnFromBattleZoneToHand(IBattleZoneCreature creature)
        {
            IPlayer owner = GetOwner(creature);
            owner.BattleZone.Remove(creature, this);
            owner.Hand.Add(new HandCreature(creature), this);
            return null;
        }

        public IPlayerAction PutFromBattleZoneIntoOwnersManazone(IBattleZoneCreature creature)
        {
            IPlayer owner = GetOwner(creature);
            owner.BattleZone.Remove(creature, this);
            owner.ManaZone.Add(new ManaZoneCreature(creature), this);
            return null;
        }

        public IPlayerAction PutFromManaZoneIntoTheBattleZone(IManaZoneCreature creature)
        {
            IPlayer owner = GetOwner(creature);
            owner.ManaZone.Remove(creature, this);
            owner.BattleZone.Add(new BattleZoneCreature(creature), this);
            return null;
        }

        public IPlayerAction AddTheTopCardOfYourDeckToYourShieldsFaceDown(IPlayer player)
        {
            PutFromTheTopOfDeckIntoShieldZone(player, 1);
            return null;
        }
        #endregion PlayerAction

        public int GetPower(IBattleZoneCreature creature)
        {
            return _continuousEffectManager.GetPower(this, _abilityManager, creature);
        }

        public IEnumerable<ICard> GetAllCards()
        {
            List<ICard> cards = Player1.CardsInAllZones.ToList();
            cards.AddRange(Player2.CardsInAllZones);
            return cards;
        }
        #endregion Internal methods

        #region Private methods
        #region void
        ///<summary>
        /// Removes the top cards from a player's deck and puts them into their shield zone.
        ///</summary>
        private void PutFromTheTopOfDeckIntoShieldZone(IPlayer player, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                player.ShieldZone.Add(CardFactory.GenerateShieldZoneCard(RemoveTheTopCardOfDeck(player), false), this);
            }
        }

        /// <summary>
        /// A player draws a number of cards.
        /// </summary>
        private void DrawCards(IPlayer player, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                ICard drawnCard = RemoveTheTopCardOfDeck(player);
                IHandCard handCard = CardFactory.GenerateHandCard(drawnCard);
                player.Hand.Add(handCard, this);
                DuelEventOccurred?.Invoke(this, new DuelEventArgs(new DrawCardEvent(player, handCard)));
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

        private void PutFromBattleZoneIntoGraveyard(IPlayer player, IBattleZoneCard card)
        {
            player.BattleZone.Remove(card, this);
            player.Graveyard.Add(CardFactory.GenerateGraveyardCard(card), this);
        }

        private IHandCard PutFromShieldZoneToHand(IPlayer player, IShieldZoneCard card)
        {
            player.ShieldZone.Remove(card, this);
            IHandCard handCard = CardFactory.GenerateHandCard(card);
            player.Hand.Add(handCard, this);
            return handCard;
        }

        private void ValidateStateForProgressing()
        {
            //TODO: Implement as attribute?
            if (State != DuelState.InProgress)
            {
                throw new InvalidOperationException($"Could not progress in duel duel as state was {State.ToString()} instead of in progress.");
            }
        }
        #endregion void

        #region PlayerAction
        private IPlayerAction TryToPerformAutomatically(IPlayerAction playerAction)
        {
            IPlayerAction newPlayerAction = playerAction.TryToPerformAutomatically(this);
            if (playerAction == newPlayerAction)
            {
                //Player action was not performed automatically.
                if (playerAction.Player is AIPlayer aiPlayer)
                {
                    IPlayerAction aiAction = aiPlayer.PerformPlayerAction(this, newPlayerAction);
                    return aiAction != null ? TryToPerformAutomatically(aiAction) : ProgressPrivate();
                }
                else
                {
                    return playerAction;
                }
            }
            else
            {
                return newPlayerAction != null ? TryToPerformAutomatically(newPlayerAction) : ProgressPrivate();
            }
        }

        /// <summary>
        /// Progresses in the duel.
        /// </summary>
        /// <returns>A player request for a player to perform an action. Returns null if there is nothing left to do in the duel.</returns>
        private IPlayerAction ProgressPrivate()
        {
            if (State == DuelState.InProgress)
            {
                CheckStateBasedActions();
                return State == DuelState.InProgress ? ProgressAfterStateBasedActions() : ProgressPrivate();
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

        private IPlayerAction ContinueResolvingAbility()
        {
            PlayerActionWithEndInformation action = _abilityManager.ContinueResolution(this);
            if (!action.ResolutionOver)
            {
                //TODO: test
                return action.PlayerAction != null ? TryToPerformAutomatically(action.PlayerAction) : ProgressPrivate();
            }
            else
            {
                FinishResolvingAbility();
                return null;
            }
        }

        private IPlayerAction TryToUseShieldTrigger()
        {
            foreach (IPlayer player in new List<IPlayer>() { CurrentTurn.ActivePlayer, CurrentTurn.NonActivePlayer }.Where(player => player.ShieldTriggersToUse.Any()))
            {
                return TryToPerformAutomatically(new UseShieldTrigger(player, new List<IHandCard>(player.ShieldTriggersToUse)));
            }
            return null;
        }

        private IPlayerAction ProgressAfterStateBasedActions()
        {
            IPlayerAction tryToUseShieldTrigger = TryToUseShieldTrigger();
            if (tryToUseShieldTrigger != null)
            {
                return tryToUseShieldTrigger;
            }

            if (_abilityManager.IsAbilityBeingResolved)
            {
                IPlayerAction action = ContinueResolvingAbility();
                if (action != null)
                {
                    return action;
                }
            }

            if (_spellsBeingResolved.Count > 0)
            {
                IPlayerAction resolveSpellAbility = TryToResolveSpellAbility();
                if (resolveSpellAbility != null)
                {
                    return resolveSpellAbility;
                }
            }

            IPlayerAction selectAbilityToResolve = TryToSelectAbilityToResolve();
            return selectAbilityToResolve ?? TryToPerformStepAction();
        }

        private IPlayerAction TryToSelectAbilityToResolve()
        {
            foreach (IPlayer player in new List<IPlayer> { CurrentTurn.ActivePlayer, CurrentTurn.NonActivePlayer })
            {
                SelectAbilityToResolve selectAbilityToResolve = _abilityManager.TryGetSelectAbilityToResolve(player);
                if (selectAbilityToResolve != null)
                {
                    return TryToPerformAutomatically(selectAbilityToResolve);
                }
            }
            return null;
        }

        private IPlayerAction TryToPerformStepAction()
        {
            IPlayerAction playerAction = CurrentTurn.CurrentStep.PlayerActionRequired(this);
            return playerAction != null ? TryToPerformAutomatically(playerAction) : ChangeStep();
        }

        private IPlayerAction TryToResolveSpellAbility()
        {
            ISpell spell = _spellsBeingResolved.Last();
            if (_abilityManager.GetSpellAbilityCount(spell) > 0)
            {
                return StartResolvingSpellAbility(spell);
            }
            else
            {
                _ = _spellsBeingResolved.Remove(spell);
                GetOwner(spell).Graveyard.Add(new GraveyardSpell(spell), this);
                return null;
            }
        }

        private IPlayerAction StartResolvingSpellAbility(ISpell spell)
        {
            _abilityManager.StartResolvingSpellAbility(spell);
            return ProgressPrivate();
        }

        private IPlayerAction ChangeStep()
        {
            if (CurrentTurn.ChangeStep())
            {
                return StartNewTurn(CurrentTurn.NonActivePlayer, CurrentTurn.ActivePlayer);
            }
            else
            {
                IPlayerAction action = CurrentTurn.CurrentStep.ProcessTurnBasedActions(this);
                return action != null ? TryToPerformAutomatically(action) : ProgressPrivate();
            }
        }

        private void FinishResolvingAbility()
        {
            if (_abilityManager.IsAbilityBeingResolvedSpellAbility)
            {
                ISpell spell = _spellsBeingResolved.Last();
                _ = _spellsBeingResolved.Remove(spell);
                GetOwner(spell).Graveyard.Add(new GraveyardSpell(spell), this);
            }
            SetPendingAbilityToBeResolved(null);
        }

        private IPlayerAction SetCurrentPlayerAction(IPlayerAction playerAction)
        {
            _playerActionManager.SetCurrentPlayerAction(playerAction);
            return playerAction;
        }

        /// <summary>
        /// Creates a new turn and starts it.
        /// </summary>
        private IPlayerAction StartNewTurn(IPlayer activePlayer, IPlayer nonActivePlayer)
        {
            IPlayerAction playerAction = _turnManager.StartNewTurn(activePlayer, nonActivePlayer, this);
            return playerAction != null ? TryToPerformAutomatically(playerAction) : ProgressPrivate();
        }

        /*
        private PlayerAction PutTheTopCardOfYourDeckIntoYourManaZoneThenAddTheTopCardOfYourDeckToYourShieldsFaceDown(IPlayer player)
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
        private static bool HasCivilizations(IEnumerable<IManaZoneCard> paymentCards, IEnumerable<Civilization> requiredCivilizations)
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

        private bool HasShieldTrigger(IHandCreature creature)
        {
            return _continuousEffectManager.HasShieldTrigger(this, _abilityManager, creature);
        }

        private bool HasShieldTrigger(IHandSpell spell)
        {
            return _continuousEffectManager.HasShieldTrigger(this, _abilityManager, spell);
        }

        private bool HasShieldTrigger(IHandCard card)
        {
            if (card is IHandCreature creature)
            {
                return HasShieldTrigger(creature);
            }
            else if (card is IHandSpell spell)
            {
                return HasShieldTrigger(spell);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private bool HasSpeedAttacker(IBattleZoneCreature creature)
        {
            return _continuousEffectManager.HasSpeedAttacker(this, _abilityManager, creature);
        }

        private bool AffectedBySummoningSickness(IBattleZoneCreature creature)
        {
            return creature.SummoningSickness && !HasSpeedAttacker(creature);
        }
        #endregion bool

        /// <summary>
        /// Removes the top card from a player's deck and returns it.
        /// </summary>
        private ICard RemoveTheTopCardOfDeck(IPlayer player)
        {
            return player.Deck.RemoveAndGetTopCard(this);
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

        private IEnumerable<BattleZoneCreature> GetAllBlockersPlayerHasInTheBattleZone(IPlayer player)
        {
            return _continuousEffectManager.GetAllBlockersPlayerHasInTheBattleZone(player, this, _abilityManager);
        }

        private void CastSpell(ISpell spell)
        {
            _spellsBeingResolved.Add(spell);
            _abilityManager.TriggerWheneverAPlayerCastsASpellAbilities(CreaturesInTheBattleZone);
        }
        #endregion Private methods
    }
}
