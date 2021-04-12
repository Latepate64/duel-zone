using DuelMastersModels.Abilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Factories;
using DuelMastersModels.Managers;
using DuelMastersModels.Choices;
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
        #region Properties
        #region Public
        /// <summary>
        /// A player that participates in duel against player 2.
        /// </summary>
        public IPlayer Player1 { get; set; }

        /// <summary>
        /// A player that participates in duel against player 1.
        /// </summary>
        public IPlayer Player2 { get; set; }

        public IPlayer StartingPlayer { get; set; }

        /// <summary>
        /// Player who won the duel.
        /// </summary>
        public IPlayer Winner { get; private set; }

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

        /// <summary>
        /// Determines which player goes first in the duel.
        /// </summary>
        public StartingPlayerMethod StartingPlayerMethod { get; set; } = StartingPlayerMethod.Random;
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

        public ITurnManager TurnManager { get; set; } = new TurnManager();
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

        private readonly IAbilityManager _abilityManager = new AbilityManager();

        private readonly IContinuousEffectManager _continuousEffectManager = new ContinuousEffectManager();
        #endregion Fields

        #region Public methods
        /// <summary>
        /// Starts the duel.
        /// </summary>
        /// <returns>Action a player is expected to perform.</returns>
        public IChoice Start()
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

            return StartingPlayer.TakeTurn(this);
        }

        /// <summary>
        /// Tries to progress in the duel.
        /// </summary>
        /// <returns></returns>
        public IChoice Progress<T>() where T : class, ICard
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
        public IChoice Progress<T>(T card) where T : class, ICard
        {
            return Progress(new List<T> { card });
        }

        /// <summary>
        /// Tries to progress in the duel.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cards"></param>
        /// <returns></returns>
        public IChoice Progress<T>(IEnumerable<T> cards) where T : class, ICard
        {
            ValidateStateForProgressing();
            throw new NotImplementedException();
            //IChoice playerAction = PlayerActionManager.Progress(cards);
            //return playerAction == null ? SetCurrentPlayerAction(Progress()) : SetCurrentPlayerAction(TryToPerformAutomatically(playerAction));
        }

        public IChoice TryToPerformAutomatically(IChoice playerAction)
        {
            throw new NotImplementedException();
            //IChoice newPlayerAction = playerAction.TryToChooseAutomatically(this);
            //return playerAction == newPlayerAction
            //    ? playerAction
            //    : newPlayerAction != null ? TryToPerformAutomatically(newPlayerAction) : Progress();
        }
        #endregion Public methods

        #region Internal methods
        #region void
        /// <summary>
        /// Ends the duel.
        /// </summary>
        public void End(IPlayer winner)
        {
            Winner = winner;
            _losers.Add(winner.Opponent);
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
        /// Manages a battle between two creatures.
        /// </summary>
        /// <param name="attackingCreature">Creature which initiated the attack.</param>
        /// <param name="defendingCreature">Creature which the attack was directed at.</param>
        public void Battle(IBattleZoneCreature attackingCreature, IBattleZoneCreature defendingCreature)
        {
            int attackingCreaturePower = GetPower(attackingCreature);
            int defendingCreaturePower = GetPower(defendingCreature);
            //TODO: Handle destruction as a state-based action. 703.4d
            if (attackingCreaturePower > defendingCreaturePower)
            {
                defendingCreature.Owner.PutFromBattleZoneIntoGraveyard(defendingCreature);
            }
            else if (attackingCreaturePower < defendingCreaturePower)
            {
                attackingCreature.Owner.PutFromBattleZoneIntoGraveyard(attackingCreature);
            }
            else
            {
                attackingCreature.Owner.PutFromBattleZoneIntoGraveyard(attackingCreature);
                defendingCreature.Owner.PutFromBattleZoneIntoGraveyard(defendingCreature);
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
                player.BattleZone.Add(new BattleZoneCreature(creature));
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
            card.Owner.Hand.Remove(card);
            card.Owner.ShieldZone.Add(CardFactory.GenerateShieldZoneCard(card, true));
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
            return new ReadOnlyCollection<IBattleZoneCreature>(GetAllBlockersPlayerHasInTheBattleZone(attackingCreature.Owner.Opponent).Where(c => !c.Tapped).ToList());
            //TODO: consider situations where abilities of attacking creature matter etc.
        }

        public IEnumerable<IBattleZoneCreature> GetCreaturesThatCanAttack(IPlayer player)
        {
            IEnumerable<IBattleZoneCreature> creaturesThatCannotAttack = _continuousEffectManager.GetCreaturesThatCannotAttack(this, _abilityManager, player);
            return new ReadOnlyCollection<IBattleZoneCreature>(player.BattleZone.UntappedCreatures.Where(creature => !AffectedBySummoningSickness(creature) && !creaturesThatCannotAttack.Contains(creature)).ToList());
        }

        public IEnumerable<IBattleZoneCreature> GetCreaturesThatCanBeAttacked(IPlayer player)
        {
            return player.Opponent.BattleZone.TappedCreatures;
            //TODO: Consider attacking creature
        }
        #endregion ReadOnlyCreatureCollection

        #region PlayerAction
        /// <summary>
        /// Player draws a card.
        /// </summary>
        public IChoice DrawCard(IPlayer player)
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

        public IChoice PutFromShieldZoneToHand(IPlayer player, IShieldZoneCard card, bool canUseShieldTrigger)
        {
            return PutFromShieldZoneToHand(player, new List<IShieldZoneCard>() { card }, canUseShieldTrigger);
        }

        public IChoice PutFromShieldZoneToHand(IPlayer player, IEnumerable<IShieldZoneCard> cards, bool canUseShieldTrigger)
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
            throw new NotImplementedException();
            //return shieldTriggerCards.Any() ? new DeclareShieldTriggers(player, new ReadOnlyCollection<IHandCard>(shieldTriggerCards)) : null;
        }

        public IChoice PutTheTopCardOfYourDeckIntoYourManaZone(IPlayer player)
        {
            player.ManaZone.Add(CardFactory.GenerateManaZoneCard(player.RemoveTopCardOfDeck()));
            return null;
        }

        public IChoice ReturnFromBattleZoneToHand(IBattleZoneCreature creature)
        {
            creature.Owner.BattleZone.Remove(creature);
            creature.Owner.Hand.Add(new HandCreature(creature));
            return null;
        }

        public IChoice PutFromBattleZoneIntoOwnersManazone(IBattleZoneCreature creature)
        {
            creature.Owner.BattleZone.Remove(creature);
            creature.Owner.ManaZone.Add(new ManaZoneCreature(creature));
            return null;
        }

        public IChoice PutFromManaZoneIntoTheBattleZone(IManaZoneCreature creature)
        {
            creature.Owner.ManaZone.Remove(creature);
            creature.Owner.BattleZone.Add(new BattleZoneCreature(creature));
            return null;
        }

        public IChoice AddTheTopCardOfYourDeckToYourShieldsFaceDown(IPlayer player)
        {
            player.PutFromTopOfDeckIntoShieldZone(1);
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
        private IHandCard PutFromShieldZoneToHand(IPlayer player, IShieldZoneCard card)
        {
            player.ShieldZone.Remove(card);
            IHandCard handCard = CardFactory.GenerateHandCard(card);
            player.Hand.Add(handCard);
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
        /// <summary>
        /// Progresses in the duel.
        /// </summary>
        /// <returns>A player request for a player to perform an action. Returns null if there is nothing left to do in the duel.</returns>
        public IChoice Progress()
        {
            if (State == DuelState.InProgress)
            {
                //CheckStateBasedActions();
                return State == DuelState.InProgress ? ProgressAfterStateBasedActions() : Progress();
            }
            else if (State == DuelState.Over)
            {
                return null;
            }
            else
            {
                throw new InvalidOperationException($"Duel is in invalid state for progression. State: {State}");
            }
        }

        private IChoice ContinueResolvingAbility()
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

        private IChoice TryToUseShieldTrigger()
        {
            throw new NotImplementedException();
            //foreach (IPlayer player in new List<IPlayer> { TurnManager.CurrentTurn.ActivePlayer, TurnManager.CurrentTurn.NonActivePlayer }.Where(player => player.ShieldTriggersToUse.Any()))
            //{
            //    //return TryToPerformAutomatically(new UseShieldTrigger(player, new List<IHandCard>(player.ShieldTriggersToUse)));
            //}
            //return null;
        }

        private IChoice ProgressAfterStateBasedActions()
        {
            IChoice tryToUseShieldTrigger = TryToUseShieldTrigger();
            if (tryToUseShieldTrigger != null)
            {
                return tryToUseShieldTrigger;
            }

            if (_abilityManager.IsAbilityBeingResolved)
            {
                IChoice action = ContinueResolvingAbility();
                if (action != null)
                {
                    return action;
                }
            }

            if (_spellsBeingResolved.Count > 0)
            {
                IChoice resolveSpellAbility = TryToResolveSpellAbility();
                if (resolveSpellAbility != null)
                {
                    return resolveSpellAbility;
                }
            }

            IChoice selectAbilityToResolve = TryToSelectAbilityToResolve();
            return selectAbilityToResolve ?? TryToPerformStepAction();
        }

        private IChoice TryToSelectAbilityToResolve()
        {
            foreach (IPlayer player in new List<IPlayer> { TurnManager.CurrentTurn.ActivePlayer, TurnManager.CurrentTurn.NonActivePlayer })
            {
                SelectAbilityToResolve selectAbilityToResolve = _abilityManager.TryGetSelectAbilityToResolve(player);
                if (selectAbilityToResolve != null)
                {
                    return TryToPerformAutomatically(selectAbilityToResolve);
                }
            }
            return null;
        }

        private IChoice TryToPerformStepAction()
        {
            throw new NotImplementedException();
            //IChoice playerAction = TurnManager.CurrentTurn.CurrentStep.PlayerActionRequired(this);
            //return playerAction != null ? TryToPerformAutomatically(playerAction) : ChangeStep();
        }

        private IChoice TryToResolveSpellAbility()
        {
            ISpell spell = _spellsBeingResolved.Last();
            if (_abilityManager.GetSpellAbilityCount(spell) > 0)
            {
                return StartResolvingSpellAbility(spell);
            }
            else
            {
                _ = _spellsBeingResolved.Remove(spell);
                spell.Owner.Graveyard.Add(new GraveyardSpell(spell));
                return null;
            }
        }

        private IChoice StartResolvingSpellAbility(ISpell spell)
        {
            _abilityManager.StartResolvingSpellAbility(spell);
            return Progress();
        }

        //private IChoice ChangeStep()
        //{
        //    if (TurnManager.CurrentTurn.ChangeStep())
        //    {
        //        return TurnManager.CurrentTurn.NonActivePlayer.TakeTurn(this);
        //    }
        //    else
        //    {
        //        if (TurnManager.CurrentTurn.CurrentStep is ITurnBasedActionable actionAble)
        //        {
        //            actionAble.ProcessTurnBasedActions(this);
        //        }
        //        return Progress();
        //    }
        //}

        private void FinishResolvingAbility()
        {
            if (_abilityManager.IsAbilityBeingResolvedSpellAbility)
            {
                ISpell spell = _spellsBeingResolved.Last();
                _ = _spellsBeingResolved.Remove(spell);
                spell.Owner.Graveyard.Add(new GraveyardSpell(spell));
            }
            SetPendingAbilityToBeResolved(null);
        }
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

        private IEnumerable<IBattleZoneCreature> GetAllBlockersPlayerHasInTheBattleZone(IPlayer player)
        {
            return _continuousEffectManager.GetAllBlockersPlayerHasInTheBattleZone(player, this, _abilityManager);
        }

        private void CastSpell(ISpell spell)
        {
            _spellsBeingResolved.Add(spell);
            _abilityManager.TriggerWheneverAPlayerCastsASpellAbilities(CreaturesInTheBattleZone);
        }

        //private void RandomizeStartingPlayer(out IPlayer activePlayer, out IPlayer nonActivePlayer)
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
        #endregion Private methods
    }
}
