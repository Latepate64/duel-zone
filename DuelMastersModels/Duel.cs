using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Abilities.TriggerAbilities;
using DuelMastersModels.Cards;
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
        public Player Player1 { get; private set; }

        /// <summary>
        /// A player that participates in duel against player 1.
        /// </summary>
        public Player Player2 { get; private set; }

        /// <summary>
        /// Player who won the duel.
        /// </summary>
        public Player Winner { get; private set; }

        /// <summary>
        /// Determines whether duel has ended or not.
        /// </summary>
        public bool Ended { get; private set; }

        /// <summary>
        /// The number of shields each player has at the start of a duel. 
        /// </summary>
        public int InitialNumberOfShields { get; set; } = 5;

        /// <summary>
        /// The number of cards each player draw at the start of a duel.
        /// </summary>
        public int InitialNumberOfHandCards { get; set; } = 5;

        /// <summary>
        /// An action a player is currently performing.
        /// </summary>
        public PlayerAction CurrentPlayerAction
        {
            get => _currentPlayerAction;
            set
            {
                if (value != _currentPlayerAction)
                {
                    _currentPlayerAction = value;
                }
            }
        }

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
        /// Non-static abilities that are waiting to be resolved.
        /// </summary>
        internal Collection<NonStaticAbility> PendingAbilities { get; } = new Collection<NonStaticAbility>();

        /// <summary>
        /// A non-static ability that is currently being resolved.
        /// </summary>
        internal NonStaticAbility AbilityBeingResolved { get; set; }

        /// <summary>
        /// The turn that is currently being processed.
        /// </summary>
        internal Turn CurrentTurn => _turns.Last();

        /// <summary>
        /// An ability can be a characteristic an card has that lets it affect the game. A card's abilities are defined by its rules text or by the effect that created it.
        /// </summary>
        internal AbilityCollection Abilities { get; } = new AbilityCollection();

        internal ReadOnlyTriggerAbilityCollection TriggerAbilities => new ReadOnlyTriggerAbilityCollection(Abilities.Where(a => a is TriggerAbility).Cast<TriggerAbility>());

        internal ReadOnlyStaticAbilityCollection StaticAbilities => new ReadOnlyStaticAbilityCollection(Abilities.Where(a => a is StaticAbility).Cast<StaticAbility>());

        internal ReadOnlySpellAbilityCollection SpellAbilities => new ReadOnlySpellAbilityCollection(Abilities.Where(a => a is SpellAbility).Cast<SpellAbility>());
        #endregion Internal
        #endregion Properties

        #region Fields
        /// <summary>
        /// Continuous effects that are generated by non-static abilities. Use method GetContinuousEffects() to obtain all continuous effects generated by non-static and static abilities.
        /// </summary>
        private readonly Collection<ContinuousEffect> _continuousEffects = new Collection<ContinuousEffect>();

        /// <summary>
        /// Players who lost the duel.
        /// </summary>
        private readonly Collection<Player> _losers = new Collection<Player>();

        /// <summary>
        /// All the turns of the duel that have been or are processed, in order.
        /// </summary>
        private readonly Collection<Turn> _turns = new Collection<Turn>();

        /// <summary>
        /// Spells that are being resolved.
        /// </summary>
        private readonly SpellCollection _spellsBeingResolved = new SpellCollection();

        private PlayerAction _currentPlayerAction;
        #endregion Fields

        /// <summary>
        /// Creates a duel.
        /// </summary>
        /// <param name="player1">One of the two playes.</param>
        /// <param name="player2">Another one of the two players.</param>
        public Duel(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            InstantiateAbilities(Player1);
            InstantiateAbilities(Player2);
        }

        #region Public methods
        /// <summary>
        /// Starts a duel.
        /// </summary>
        public PlayerAction Start()
        {
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
            PlayerAction playerAction = null;
            if (response is CardSelectionResponse cardSelectionResponse)
            {
                playerAction = PerformCardSelection(cardSelectionResponse);

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
                        playerAction = optionalCreatureSelection.Perform(this, creature);
                    }
                    else
                    {
                        return CurrentPlayerAction;
                    }
                }
                else if (CurrentPlayerAction is MandatoryCreatureSelection mandatoryCreatureSelection)
                {
                    if (creatureSelectionResponse.SelectedCreatures.Count == 1)
                    {
                        Creature creature = creatureSelectionResponse.SelectedCreatures.First();
                        if (mandatoryCreatureSelection.Validate(creature))
                        {
                            playerAction = mandatoryCreatureSelection.Perform(this, creature);
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
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else if (response is SelectAbilityToResolveResponse selectAbilityToResolveResponse)
            {
                if (CurrentPlayerAction is SelectAbilityToResolve selectAbilityToResolve)
                {
                    selectAbilityToResolve.SelectedAbility = selectAbilityToResolveResponse.Ability;
                    SelectAbilityToResolve.Perform(this, selectAbilityToResolveResponse.Ability);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            //TODO SelectAbilityToResolveResponse
            //else if (response if )
            else
            {
                throw new ArgumentOutOfRangeException("response");
            }
            return playerAction == null ? SetCurrentPlayerAction(Progress()) : SetCurrentPlayerAction(TryToPerformAutomatically(playerAction));
        }

        private PlayerAction PerformCardSelection(CardSelectionResponse cardSelectionResponse)
        {
            PlayerAction playerAction;
            if (CurrentPlayerAction is OptionalCardSelection optionalCardSelection)
            {
                Card card = null;
                if (cardSelectionResponse.SelectedCards.Count == 1)
                {
                    card = cardSelectionResponse.SelectedCards.First();
                }
                optionalCardSelection.Validate(card);
                playerAction = optionalCardSelection.Perform(this, card);
            }
            else if (CurrentPlayerAction is MandatoryMultipleCardSelection mandatoryMultipleCardSelection)
            {
                if (CurrentPlayerAction is PayCost payCost)
                {
                    payCost.Validate(cardSelectionResponse.SelectedCards, (CurrentTurn.CurrentStep as MainStep).CardToBeUsed);
                    playerAction = payCost.Perform(this, cardSelectionResponse.SelectedCards);
                }
                else
                {
                    mandatoryMultipleCardSelection.Validate(cardSelectionResponse.SelectedCards);
                    playerAction = mandatoryMultipleCardSelection.Perform(this, cardSelectionResponse.SelectedCards);
                }
            }
            else if (CurrentPlayerAction is MultipleCardSelection multipleCardSelection)
            {
                multipleCardSelection.Validate(cardSelectionResponse.SelectedCards);
                foreach (Card card in cardSelectionResponse.SelectedCards)
                {
                    multipleCardSelection.SelectedCards.Add(card);
                }
                playerAction = multipleCardSelection.Perform(this, cardSelectionResponse.SelectedCards);
            }
            else if (CurrentPlayerAction is MandatoryCardSelection mandatoryCardSelection)
            {
                if (cardSelectionResponse.SelectedCards.Count == 1)
                {
                    Card card = cardSelectionResponse.SelectedCards.First();
                    mandatoryCardSelection.Validate(card);
                    playerAction = mandatoryCardSelection.Perform(this, card);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new InvalidOperationException("Could not identify current player action.");
            }
            return playerAction;
        }
        #endregion Public methods

        #region Internal methods
        #region Player
        /// <summary>
        /// Returns the opponent of a player.
        /// </summary>
        internal Player GetOpponent(Player player)
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
        /// Returns the player who owns target card.
        /// </summary>
        /// <param name="card">Card whose owner is queried.</param>
        /// <returns>Player who owns the card.</returns>
        internal Player GetOwner(Card card)
        {
            //TODO: test if works
            if (Player1.DeckBeforeDuel.Contains(card))
            //if (Player1.DeckBeforeDuel.Select(c => c.GameId).Contains(card.GameId))
            {
                return Player1;
            }
            else if (Player2.DeckBeforeDuel.Contains(card))
            //else if (Player2.DeckBeforeDuel.Select(c => c.GameId).Contains(card.GameId))
            {
                return Player2;
            }
            else
            {
                throw new ArgumentOutOfRangeException("card");
            }
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
            Ended = true;
        }

        /// <summary>
        /// Ends duel in a draw.
        /// </summary>
        internal void EndDuelInDraw()
        {
            _losers.Add(Player1);
            _losers.Add(Player2);
            Ended = true;
        }

        /// <summary>
        /// Target player puts target card from their hand into their mana zone.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        internal void PutFromHandIntoManaZone(Player player, Card card)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            if (card == null)
            {
                throw new ArgumentNullException("card");
            }
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
        internal void UseCard(Card card)
        {
            if (card is Creature creature)
            {
                GetOwner(creature).BattleZone.Add(creature, this);
            }
            else if (card is Spell spell)
            {
                _spellsBeingResolved.Add(spell);
                foreach (Creature battleZoneCreature in CreaturesInTheBattleZone)
                {
                    foreach (TriggerAbility ability in TriggerAbilities.Where(ability => ability.Source == battleZoneCreature && ability.TriggerCondition is WheneverAPlayerCastsASpell))
                    {
                        TriggerTriggerAbility(ability, ability.Controller);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Once an ability has triggered, its controller puts it on the stack as an object that’s not a card the next time a player would receive priority.
        /// </summary>
        /// <param name="ability"></param>
        /// <param name="controller"></param>
        internal void TriggerTriggerAbility(TriggerAbility ability, Player controller)
        {
            PendingAbilities.Add(ability.CreatePendingTriggerAbility(controller));
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

        internal void EndContinuousEffects(Type type)
        {
            //TODO: Test
            _continuousEffects.ToList().RemoveAll(c => c.Period.GetType() == type);
            /*
            List<ContinuousEffect> suitableContinuousEffects = _continuousEffects.Where(c => c.Period.GetType() == type).ToList();
            while (suitableContinuousEffects.Count() > 0)
            {
                _continuousEffects.Remove(suitableContinuousEffects.First());
                suitableContinuousEffects.Remove(suitableContinuousEffects.First());
            }
            */
        }

        internal void AddContinuousEffect(ContinuousEffect continuousEffect)
        {
            _continuousEffects.Add(continuousEffect);
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
            IEnumerable<Creature> creaturesThatCannotAttackPlayers = GetContinuousEffects<CannotAttackPlayersEffect>().SelectMany(e => e.CreatureFilter.FilteredCreatures).Distinct();
            return !AffectedBySummoningSickness(creature) && !creaturesThatCannotAttackPlayers.Contains(creature);
        }

        internal bool AttacksIfAble(Creature creature)
        {
            return GetContinuousEffects<AttacksIfAbleEffect>().Any(e => e.CreatureFilter.FilteredCreatures.Contains(creature));
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
            List<Creature> creatures = player.BattleZone.UntappedCreatures.Where(creature => !AffectedBySummoningSickness(creature)).ToList();

            IEnumerable<Creature> creaturesThatCannotAttackPlayers = GetContinuousEffects<CannotAttackPlayersEffect>().SelectMany(e => e.CreatureFilter.FilteredCreatures).Distinct();
            IEnumerable<Creature> creaturesThatCannotAttack = creaturesThatCannotAttackPlayers.Where(c => GetCreaturesThatCanBeAttacked(player).Count == 0);
            creatures.RemoveAll(c => creaturesThatCannotAttack.Contains(c));
            return new ReadOnlyCreatureCollection(creatures);
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
            //return creature.Power + GetContinuousEffects().Where(e => e is PowerEffect).Cast<PowerEffect>().Where(e => e.CreatureFilter.FilteredCreatures.Contains(creature)).Sum(e => e.Power);
            return creature.Power + GetContinuousEffects<PowerEffect>().Where(e => e.CreatureFilter.FilteredCreatures.Contains(creature)).Sum(e => e.Power);
        }

        internal ReadOnlyCollection<TriggerAbility> GetTriggerAbilities<T>(Card card)
        {
            return new ReadOnlyCollection<TriggerAbility>(TriggerAbilities.Where(ability => ability.Source == card && ability.TriggerCondition is T).ToList());
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
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            if (creature == null)
            {
                throw new ArgumentNullException("creature");
            }
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
            if (!Ended)
            {
                CheckStateBasedActions();
                if (!Ended)
                {
                    foreach (Player player in new List<Player>() { CurrentTurn.ActivePlayer, CurrentTurn.NonActivePlayer })
                    {
                        if (player.ShieldTriggersToUse.Count > 0)
                        {
                            return TryToPerformAutomatically(new UseShieldTrigger(player, new ReadOnlyCardCollection(player.ShieldTriggersToUse)));
                        }
                    }

                    if (AbilityBeingResolved != null)
                    {
                        //PlayerAction playerActionFromNonStaticAbility = AbilityBeingResolved.ContinueResolution(this);
                        PlayerActionWithEndInformation action = AbilityBeingResolved.ContinueResolution(this);
                        if (!action.End)
                        {
                            //TODO: test
                            return action.PlayerAction != null ? TryToPerformAutomatically(action.PlayerAction) : Progress();
                        }
                        else
                        {
                            if (AbilityBeingResolved is SpellAbility)
                            {
                                Spell spell = _spellsBeingResolved.Last();
                                _spellsBeingResolved.Remove(spell);
                                GetOwner(spell).Graveyard.Add(spell, this);
                            }

                            AbilityBeingResolved = null;
                        }
                    }

                    if (_spellsBeingResolved.Count > 0)
                    {
                        Spell spell = _spellsBeingResolved.Last();
                        if (SpellAbilities.Count(a => a.Source == spell) > 0)
                        {
                            //TODO: spell may have more than one spell ability.
                            SpellAbility spellAbility = SpellAbilities.First(a => a.Source == spell);
                            AbilityBeingResolved = spellAbility;
                            return Progress();
                        }
                        else
                        {
                            _spellsBeingResolved.Remove(spell);
                            GetOwner(spell).Graveyard.Add(spell, this);
                        }
                    }

                    ReadOnlyCollection<NonStaticAbility> pendingAbilitiesForActivePlayer = GetPendingAbilitiesForActivePlayer();
                    if (pendingAbilitiesForActivePlayer.Count > 0)
                    {
                        return TryToPerformAutomatically(new SelectAbilityToResolve(CurrentTurn.ActivePlayer, pendingAbilitiesForActivePlayer));
                    }
                    ReadOnlyCollection<NonStaticAbility> pendingAbilitiesForNonActivePlayer = GetPendingAbilitiesForNonActivePlayer();
                    if (pendingAbilitiesForNonActivePlayer.Count > 0)
                    {
                        return TryToPerformAutomatically(new SelectAbilityToResolve(CurrentTurn.NonActivePlayer, pendingAbilitiesForNonActivePlayer));
                    }

                    /*foreach (Collection<NonStaticAbility> pendingAbilities in new List<Collection<NonStaticAbility>>() { PendingAbilitiesForActivePlayer, PendingAbilitiesForNonActivePlayer })
                    {
                        SelectAbilityToResolve selectAbilityToResolve = new SelectAbilityToResolve(pendingAbilities.First().Controller, pendingAbilities);
                        return TryToPerformAutomatically(selectAbilityToResolve);
                    }*/

                    PlayerAction playerAction = CurrentTurn.CurrentStep.PlayerActionRequired(this);
                    if (playerAction != null)
                    {
                        return TryToPerformAutomatically(playerAction);
                    }
                    else
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
                }
            }
            return null;
        }

        private PlayerAction SetCurrentPlayerAction(PlayerAction playerAction)
        {
            CurrentPlayerAction = playerAction;
            return playerAction;
        }

        /// <summary>
        /// Creates a new turn and starts it.
        /// </summary>
        private PlayerAction StartNewTurn(Player activePlayer, Player nonActivePlayer)
        {
            Turn turn = new Turn(activePlayer, nonActivePlayer, _turns.Count + 1);
            _turns.Add(turn);
            PlayerAction playerAction = turn.Start(this);
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
            foreach (SpellContinuousEffect spellContinuousEffect in GetContinuousEffects().Where(e => e is SpellShieldTriggerEffect).Cast<SpellShieldTriggerEffect>())
            {
                if (spellContinuousEffect.SpellFilter.FilteredSpells.Contains(spell))
                {
                    return true;
                }
            }
            return false;
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
            return GetContinuousEffects<SpeedAttackerEffect>().Any(e => e.CreatureFilter.FilteredCreatures.Contains(creature));
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

        private ReadOnlyCardCollection GetAllCards()
        {
            List<Card> cards = Player1.DeckBeforeDuel.ToList();
            cards.AddRange(Player2.DeckBeforeDuel);
            return new ReadOnlyCardCollection(cards);
        }

        private ReadOnlyContinuousEffectCollection GetContinuousEffects()
        {
            List<ContinuousEffect> continuousEffects = _continuousEffects.ToList();
            foreach (Card card in GetAllCards())
            {
                continuousEffects.AddRange(GetContinuousEffectsGeneratedByCard(card));
            }
            return new ReadOnlyContinuousEffectCollection(continuousEffects);
        }

        private IEnumerable<T> GetContinuousEffects<T>()
        {
            return GetContinuousEffects().Where(e => e is T).Cast<T>();
        }

        private List<ContinuousEffect> GetContinuousEffectsGeneratedByCard(Card card)
        {
            List<ContinuousEffect> continuousEffects = new List<ContinuousEffect>();
            foreach (StaticAbility staticAbility in StaticAbilities.Where(a => a.Source == card))
            {
                continuousEffects.AddRange(GetOwner(card).GetContinuousEffectsGeneratedByStaticAbility(card, staticAbility));
            }
            return continuousEffects;
        }

        private ReadOnlyCreatureCollection GetAllBlockersPlayerHasInTheBattleZone(Player player)
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
            return new ReadOnlyCreatureCollection(blockers);
        }

        /// <summary>
        /// Non-static abilities controlled by active player that are waiting to be resolved.
        /// </summary>
        private ReadOnlyCollection<NonStaticAbility> GetPendingAbilitiesForActivePlayer()
        {
            return new ReadOnlyCollection<NonStaticAbility>(PendingAbilities.Where(a => a.Controller == CurrentTurn.ActivePlayer).ToList());
        }

        /// <summary>
        /// Non-static abilities controlled by non-active player that are waiting to be resolved.
        /// </summary>
        private ReadOnlyCollection<NonStaticAbility> GetPendingAbilitiesForNonActivePlayer()
        {
            return new ReadOnlyCollection<NonStaticAbility>(PendingAbilities.Where(a => a.Controller == CurrentTurn.NonActivePlayer).ToList());
        }

        private void InstantiateAbilities(Player player)
        {
            foreach (Card card in player.DeckBeforeDuel)
            {
                if (card is Creature creature)
                {
                    foreach (Ability ability in creature.TryParseCreatureAbilities(player))
                    {
                        Abilities.Add(ability);
                    }
                }
                else if (card is Spell spell)
                {
                    foreach (Ability ability in spell.TryParseSpellAbilities(player))
                    {
                        Abilities.Add(ability);
                    }
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
        #endregion Private methods
    }
}
