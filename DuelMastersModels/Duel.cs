using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.GameActions.StateBasedActions;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.AutomaticActions;
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
    public enum StartingPlayer
    {
        Player1 = 0,
        Player2 = 1,
        Random = 2,
    }

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
            get => _currentPlayerAction;
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

        public Collection<Creature> CreaturesInTheBattleZone
        {
            get
            {
                List<Creature> creatures = Player1.BattleZone.Creatures.ToList();
                creatures.AddRange(Player2.BattleZone.Creatures);
                return new Collection<Creature>(creatures);
            }
        }

        public NonStaticAbility AbilityBeingResolved { get; set; }

        public Collection<NonStaticAbility> PendingAbilities { get; } = new Collection<NonStaticAbility>();

        public ObservableCollection<NonStaticAbility> PendingAbilitiesForActivePlayer => new ObservableCollection<NonStaticAbility>(PendingAbilities.Where(a => a.Controller == CurrentTurn.ActivePlayer).ToList());

        public ObservableCollection<NonStaticAbility> PendingAbilitiesForNonActivePlayer => new ObservableCollection<NonStaticAbility>(PendingAbilities.Where(a => a.Controller == CurrentTurn.NonActivePlayer).ToList());
        #endregion Properties

        #region Public methods
        /// <summary>
        /// Starts a duel.
        /// </summary>
        public PlayerAction StartDuel(StartingPlayer startingPlayer = StartingPlayer.Player1)
        {
            Player activePlayer = Player1;
            Player nonActivePlayer = Player2;

            if (startingPlayer == StartingPlayer.Random)
            {
                const int RandomMax = 100;
                int randomNumber = new Random().Next(0, RandomMax);
                startingPlayer = (randomNumber % 2 == 0) ? StartingPlayer.Player1 : StartingPlayer.Player2;
            }

            if (startingPlayer == StartingPlayer.Player2)
            {
                activePlayer = Player2;
                nonActivePlayer = Player1;
            }
            else if (startingPlayer != StartingPlayer.Player1)
            {
                throw new InvalidOperationException();
            }

            activePlayer.ShuffleDeck();
            nonActivePlayer.ShuffleDeck();
            PutFromTheTopOfDeckIntoShieldZone(activePlayer, InitialNumberOfShields);
            PutFromTheTopOfDeckIntoShieldZone(nonActivePlayer, InitialNumberOfShields);
            DrawCards(activePlayer, InitialNumberOfHandCards);
            DrawCards(nonActivePlayer, InitialNumberOfHandCards);
            return SetCurrentPlayerAction(StartNewTurn(activePlayer, nonActivePlayer));
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
        public PlayerAction DrawCard(Player player)
        {
            DrawCards(player, 1);
            return null;
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
                else if (CurrentPlayerAction is MandatoryMultipleCardSelection mandatoryMultipleCardSelection)
                {
                    if (CurrentPlayerAction is PayCost payCost)
                    {
                        if (payCost.Validate(cardSelectionResponse.SelectedCards) && PayCost.Validate(cardSelectionResponse.SelectedCards, (CurrentTurn.CurrentStep as MainStep).CardToBeUsed))
                        {
                            playerAction = payCost.Perform(this, cardSelectionResponse.SelectedCards);
                            CurrentTurn.CurrentStep.PlayerActions.Add(payCost);
                        }
                        else
                        {
                            return CurrentPlayerAction;
                        }
                    }
                    else
                    {
                        if (mandatoryMultipleCardSelection.Validate(cardSelectionResponse.SelectedCards))
                        {
                            playerAction = mandatoryMultipleCardSelection.Perform(this, cardSelectionResponse.SelectedCards);
                            CurrentTurn.CurrentStep.PlayerActions.Add(mandatoryMultipleCardSelection);
                        }
                        else
                        {
                            return CurrentPlayerAction;
                        }
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
            else if (response is SelectAbilityToResolveResponse selectAbilityToResolveResponse)
            {
                if (CurrentPlayerAction is SelectAbilityToResolve selectAbilityToResolve)
                {
                    selectAbilityToResolve.SelectedAbility = selectAbilityToResolveResponse.Ability;
                    SelectAbilityToResolve.Perform(this, selectAbilityToResolveResponse.Ability);
                    CurrentTurn.CurrentStep.PlayerActions.Add(selectAbilityToResolve);
                }
                else
                {
                    throw new InvalidOperationException("optionalActionResponse");
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
            player.Hand.Remove(card, this);
            player.ManaZone.Add(card, this);
        }

        /// <summary>
        /// TODO: Handle destruction as a state-based action. 703.4d
        /// </summary>
        public void Battle(Creature attackingCreature, Creature defendingCreature, Player attackingPlayer, Player defendingPlayer)
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

        public PlayerAction PutFromShieldZoneToHand(Player player, Card card, bool canUseShieldTrigger)
        {
            return PutFromShieldZoneToHand(player, new Collection<Card>() { card }, canUseShieldTrigger);
        }

        public PlayerAction PutFromShieldZoneToHand(Player player, Collection<Card> cards, bool canUseShieldTrigger)
        {
            Collection<Card> shieldTriggerCards = new Collection<Card>();
            for (int i = 0; i < cards.Count; ++i)
            {
                Card card = cards[i];
                PutFromShieldZoneToHand(player, card);
                if (canUseShieldTrigger && HasShieldTrigger(card))
                {
                    shieldTriggerCards.Add(card);
                }
            }
            return shieldTriggerCards.Count > 0 ? new DeclareShieldTriggers(player, shieldTriggerCards) : null;
        }

        public void PlayCard(Card card, Player player)
        {
            if (card is Creature creature)
            {
                player.BattleZone.Add(creature, this);
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
            player.ManaZone.Add(RemoveTheTopCardOfDeck(player), this);
            return null;
        }

        public PlayerAction PutTheTopCardOfYourDeckIntoYourManaZoneThenAddTheTopCardOfYourDeckToYourShieldsFaceDown(Player player)
        {
            player.ManaZone.Add(RemoveTheTopCardOfDeck(player), this);
            return new AddTheTopCardOfYourDeckToYourShieldsFaceDown(player);
        }

        public PlayerAction AddTheTopCardOfYourDeckToYourShieldsFaceDown(Player player)
        {
            PutFromTheTopOfDeckIntoShieldZone(player, 1);
            return null;
        }

        public PlayerAction ReturnFromBattleZoneToHand(Creature creature)
        {
            Player owner = GetOwner(creature);
            owner.BattleZone.Remove(creature, this);
            owner.Hand.Add(creature, this);
            return null;
        }

        public Card GetCard(int gameId)
        {
            return GetAllCards().First(c => c.GameId == gameId);
        }

        public Player GetOwner(Card card)
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
        #endregion Public methods

        #region Private methods
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
        /// Removes the top card from a player's deck and returns it.
        /// </summary>
        private Card RemoveTheTopCardOfDeck(Player player)
        {
            return player.Deck.RemoveAndGetTopCard(this);
        }

        /// <summary>
        /// A player draws a number of cards.
        /// </summary>
        private void DrawCards(Player player, int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                player.Hand.Add(RemoveTheTopCardOfDeck(player), this);
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
                            return TryToPerformAutomatically(new UseShieldTrigger(player, player.ShieldTriggersToUse));
                        }
                    }

                    if (AbilityBeingResolved != null)
                    {
                        //PlayerAction playerActionFromNonStaticAbility = AbilityBeingResolved.ContinueResolution(this);
                        Tuple<PlayerAction, bool> action = AbilityBeingResolved.ContinueResolution(this);
                        if (!action.Item2)
                        {
                            return TryToPerformAutomatically(action.Item1);
                        }
                        else
                        {
                            if (AbilityBeingResolved is SpellAbility)
                            {
                                Spell spell = SpellsBeingResolved.Last();
                                SpellsBeingResolved.Remove(spell);
                                GetOwner(spell).Graveyard.Add(spell, this);
                            }

                            AbilityBeingResolved = null;
                        }
                    }

                    if (SpellsBeingResolved.Count > 0)
                    {
                        Spell spell = SpellsBeingResolved.Last();
                        if (spell.SpellAbilities.Count > 0)
                        {
                            //TODO: spell may have more than one spell ability.
                            SpellAbility spellAbility = spell.SpellAbilities.First();
                            AbilityBeingResolved = spellAbility;
                            return Progress();
                        }
                        else
                        {
                            SpellsBeingResolved.Remove(spell);
                            GetOwner(spell).Graveyard.Add(spell, this);
                        }
                    }

                    if (PendingAbilitiesForActivePlayer.Count > 0)
                    {
                        return TryToPerformAutomatically(new SelectAbilityToResolve(CurrentTurn.ActivePlayer, PendingAbilitiesForActivePlayer));
                    }

                    if (PendingAbilitiesForNonActivePlayer.Count > 0)
                    {
                        return TryToPerformAutomatically(new SelectAbilityToResolve(CurrentTurn.NonActivePlayer, PendingAbilitiesForNonActivePlayer));
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
                            (staticAbilityForCreature.ActivityCondition == StaticAbilityForCreatureActivityCondition.WhileThisCreatureIsInTheBattleZone && GetOwner(card).BattleZone.Cards.Contains(card)) ||
                            (staticAbilityForCreature.ActivityCondition == StaticAbilityForCreatureActivityCondition.WhileThisCreatureIsInYourHand && GetOwner(card).Hand.Cards.Contains(card)))
                        {
                            continuousEffects.AddRange(staticAbilityForCreature.ContinuousEffects);
                        }
                    }
                    else if (staticAbility is StaticAbilityForSpell staticAbilityForSpell)
                    {
                        if (staticAbilityForSpell.ActivityCondition == StaticAbilityForSpellActivityCondition.WhileThisSpellIsInYourHand && GetOwner(card).Hand.Cards.Contains(card))
                        {
                            continuousEffects.AddRange(staticAbilityForSpell.ContinuousEffects);
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
            player.ShieldZone.Remove(card, this);
            player.Hand.Add(card, this);
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

        /// <summary>
        /// Creates a new turn and starts it.
        /// </summary>
        private PlayerAction StartNewTurn(Player activePlayer, Player nonActivePlayer)
        {
            Turn turn = new Turn(activePlayer, nonActivePlayer, Turns.Count + 1);
            Turns.Add(turn);
            PlayerAction playerAction = turn.Start(this);
            return playerAction != null ? TryToPerformAutomatically(playerAction) : Progress();
        }

        /// <summary>
        /// 603.3. Once an ability has triggered, its controller puts it on the stack as an object that’s not a card the next time a player would receive priority.
        /// </summary>
        /// <param name="ability"></param>
        public void TriggerTriggerAbility(TriggerAbility ability, Player controller)
        {
            PendingAbilities.Add(ability.CreatePendingTriggerAbility(controller));
        }

        public static void AddFromYourHandToYourShieldsFaceDown(Player player, Card card)
        {
            player.Hand.Cards.Remove(card);
            player.ShieldZone.Cards.Add(card);
        }
        #endregion Private methods
    }
}
