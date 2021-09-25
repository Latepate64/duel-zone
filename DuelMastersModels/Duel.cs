using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Managers;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Effects.Periods;
using DuelMastersModels.Abilities;

namespace DuelMastersModels
{
    public class Duel
    {
        public GameOver GameOverInformation { get; internal set; }

        public IEnumerable<Player> Players => new Collection<Player> { Player1, Player2 };

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

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

        public IEnumerable<Creature> BattleZoneCreatures => Players.SelectMany(x => x.BattleZone.Creatures);

        /// <summary>
        /// Spells that are being resolved.
        /// </summary>
        private readonly List<Spell> _spellsBeingResolved = new List<Spell>();

        private readonly ContinuousEffectManager _continuousEffectManager;

        /// <summary>
        /// All the turns of the duel that have been or are processed, in order.
        /// </summary>
        private readonly IList<Turn> _turns = new List<Turn>();

        public Duel()
        {
            _continuousEffectManager = new ContinuousEffectManager(this);
        }

        /// <summary>
        /// Starts the duel.
        /// </summary>
        /// <returns>Action a player is expected to perform.</returns>
        public Choice Start(Player startingPlayer, Player otherPlayer)
        {
            if (State != DuelState.Setup)
            {
                throw new InvalidOperationException($"Could not start the duel as state was {State} instead of {DuelState.Setup}.");
            }
            State = DuelState.InProgress;

            Player1 = startingPlayer;
            Player2 = otherPlayer;

            // 103.2. After the starting player has been determined, each player shuffles their deck so that the cards are in a random order.
            startingPlayer.ShuffleDeck();
            otherPlayer.ShuffleDeck();

            startingPlayer.PutFromTopOfDeckIntoShieldZone(InitialNumberOfShields, this);
            otherPlayer.PutFromTopOfDeckIntoShieldZone(InitialNumberOfShields, this);

            startingPlayer.DrawCards(InitialNumberOfHandCards, this);
            otherPlayer.DrawCards(InitialNumberOfHandCards, this);

            return StartNewTurn(startingPlayer.Id, otherPlayer.Id);
        }

        private Choice StartNewTurn(Guid activePlayer, Guid nonActivePlayer)
        {
            Turn turn = ExtraTurns.Any() ? ExtraTurns.Dequeue() : new Turn(activePlayer, nonActivePlayer);
            _turns.Add(turn);
            return turn.Start(this, _turns.Count);
        }

        public Choice Continue(Decision decision)
        {
            var choiceVar = CurrentTurn.Continue(decision, this);
            if (choiceVar == null)
            {
                return StartNewTurn(CurrentTurn.NonActivePlayer, CurrentTurn.ActivePlayer);
            }
            else
            {
                return choiceVar;
            }
        }

        /// <summary>
        /// Manages a battle between two creatures.
        /// </summary>
        /// <param name="attackingCreatureId">Creature which initiated the attack.</param>
        /// <param name="defendingCreatureId">Creature which the attack was directed at.</param>
        public void Battle(Guid attackingCreatureId, Guid defendingCreatureId)
        {
            Creature attackingCreature = GetCard(attackingCreatureId) as Creature;
            Creature defendingCreature = GetCard(defendingCreatureId) as Creature;
            int attackingCreaturePower = attackingCreature.Power;
            int defendingCreaturePower = defendingCreature.Power;
            //TODO: Handle destruction as a state-based action. 703.4d
            if (attackingCreaturePower > defendingCreaturePower)
            {
                GetOwner(defendingCreature).PutFromBattleZoneIntoGraveyard(defendingCreature, this);
            }
            else if (attackingCreaturePower < defendingCreaturePower)
            {
                GetOwner(attackingCreature).PutFromBattleZoneIntoGraveyard(attackingCreature, this);
            }
            else
            {
                GetOwner(attackingCreature).PutFromBattleZoneIntoGraveyard(attackingCreature, this);
                GetOwner(defendingCreature).PutFromBattleZoneIntoGraveyard(defendingCreature, this);
            }
        }

        public void UseCard(Card card, Player player)
        {
            if (card is Creature creature)
            {
                player.Hand.Remove(creature);
                player.BattleZone.Add(creature, this);
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

        public void EndContinuousEffects<T>()
        {
            _continuousEffectManager.EndContinuousEffects<T>();
        }

        public void AddContinuousEffect(ContinuousEffect continuousEffect)
        {
            _continuousEffectManager.AddContinuousEffect(continuousEffect);
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
            return !creature.AffectedBySummoningSickness() && !creaturesThatCannotAttackPlayers.Contains(creature);
        }

        public bool AttacksIfAble(Creature creature)
        {
            return _continuousEffectManager.AttacksIfAble(creature);
        }

        //public IEnumerable<Creature> GetCreaturesThatCanBlock(Creature attackingCreature)
        //{
        //    return new ReadOnlyCollection<Creature>(GetAllBlockersPlayerHasInTheBattleZone(attackingCreature.Owner.Opponent).Where(c => !c.Tapped).ToList());
        //    //TODO: consider situations where abilities of attacking creature matter etc.
        //}

        public IEnumerable<Creature> GetCreaturesThatCanAttack(Player player)
        {
            throw new NotImplementedException();
            //IEnumerable<Creature> creaturesThatCannotAttack = _continuousEffectManager.GetCreaturesThatCannotAttack(player);
            //return new ReadOnlyCollection<Creature>(BattleZone.GetUntappedCreatures(player).Where(creature => !AffectedBySummoningSickness(creature) && !creaturesThatCannotAttack.Contains(creature)).ToList());
        }

        public IEnumerable<Creature> GetCreaturesThatCanBeAttacked(Player player)
        {
            throw new NotImplementedException();
            //return BattleZone.GetTappedCreatures(GetOpponent(player));
            //TODO: Consider attacking creature
        }

        public Choice ReturnFromBattleZoneToHand(Card card)
        {
            throw new NotImplementedException();
            //BattleZone.Remove(card);
            //card.Owner.Hand.Add(card);
            //return null;
        }

        public Choice PutFromBattleZoneIntoOwnersManazone(Card card)
        {
            throw new NotImplementedException();
            //BattleZone.Remove(card);
            //card.Owner.ManaZone.Add(card);
            //return null;
        }

        public Choice PutFromManaZoneIntoTheBattleZone(Card card)
        {
            throw new NotImplementedException();
            //card.Owner.ManaZone.Remove(card);
            //BattleZone.Add(card);
            //return null;
        }

        public int GetPower(Creature creature)
        {
            return _continuousEffectManager.GetPower(creature);
        }

        public IEnumerable<Card> GetAllCards()
        {
            return Players.SelectMany(x => x.AllCards);
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

        //private bool HasShieldTrigger(Creature creature)
        //{
        //    return _continuousEffectManager.HasShieldTrigger(creature);
        //}

        //private bool HasShieldTrigger(Spell spell)
        //{
        //    return _continuousEffectManager.HasShieldTrigger(spell);
        //}

        //private bool HasShieldTrigger(Card card)
        //{
        //    if (card is Creature creature)
        //    {
        //        return HasShieldTrigger(creature);
        //    }
        //    else if (card is Spell spell)
        //    {
        //        return HasShieldTrigger(spell);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException();
        //    }
        //}

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

        //private IEnumerable<Creature> GetAllBlockersPlayerHasInTheBattleZone(Player player)
        //{
        //    return _continuousEffectManager.GetAllBlockersPlayerHasInTheBattleZone(player);
        //}

        private void CastSpell(Spell spell)
        {
            _spellsBeingResolved.Add(spell);
        }

        internal void Destroy(IEnumerable<Creature> creatures)
        {
            foreach (var creature in creatures)
            {
                GetOwner(creature).PutFromBattleZoneIntoGraveyard(creature, this);
            }
        }

        public Duel(Duel duel)
        {
            DelayedTriggeredAbilities = duel.DelayedTriggeredAbilities.Select(x => new DelayedTriggeredAbility(x)).ToList();
            ExtraTurns = new Queue<Turn>(duel.ExtraTurns.Select(x => new Turn(x)));
            GameOverInformation = duel.GameOverInformation != null ? new GameOver(duel.GameOverInformation) : null;
            InitialNumberOfHandCards = duel.InitialNumberOfHandCards;
            InitialNumberOfShields = duel.InitialNumberOfShields;
            Player1 = new Player(duel.Player1);
            Player2 = new Player(duel.Player2);
            State = duel.State;
            _spellsBeingResolved = duel._spellsBeingResolved.Select(x => x.Copy()).Cast<Spell>().ToList();
            _turns = duel._turns.Select(x => new Turn(x)).ToList();
        }

        internal Queue<Turn> ExtraTurns { get; private set; } = new Queue<Turn>(); // TODO: Consider extra turns when changing turn.

        internal List<DelayedTriggeredAbility> DelayedTriggeredAbilities = new List<DelayedTriggeredAbility>(); // TODO: Consider delayed triggered abilities when events occur.

        public Player GetOpponent(Player player)
        {
            if (player == Player1)
            {
                return Player2;
            }
            else if (player == Player2)
            {
                return Player1;
            }
            else
            {
                throw new ArgumentOutOfRangeException(player.ToString());
            }
        }

        public Guid GetOpponent(Guid player)
        {
            if (player == Player1.Id)
            {
                return Player2.Id;
            }
            else if (player == Player2.Id)
            {
                return Player1.Id;
            }
            else
            {
                throw new ArgumentOutOfRangeException(player.ToString());
            }
        }

        public Player GetOwner(Card card)
        {
            if (Player1.AllCards.Contains(card))
            {
                return Player1;
            }
            else if (Player2.AllCards.Contains(card))
            {
                return Player2;
            }
            else
            {
                throw new ArgumentOutOfRangeException(card.ToString());
            }
        }

        public Card GetCard(Guid id)
        {
            return GetAllCards().Single(c => c.Id == id);
        }

        public Creature GetCreature(Guid id)
        {
            return GetCard(id) as Creature;
        }

        public Player GetPlayer(Guid id)
        {
            return Players.Single(x => x.Id == id);
        }

        /// <summary>
        /// Use this method only if the type of the DuelObject is not certain.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DuelObject GetDuelObject(Guid id)
        {
            if (Players.Any(x => x.Id == id))
            {
                return GetPlayer(id);
            }
            else
            {
                return GetCard(id);
            }
        }

        public void Trigger<T>() where T : TriggerCondition
        {
            var abilities = BattleZoneCreatures.SelectMany(x => x.TriggerAbilities).Where(x => x.TriggerCondition is T && x.TriggerCondition.CanTrigger(this)).Select(x => x.Copy()).Cast<NonStaticAbility>().ToList();
            List<DelayedTriggeredAbility> toBeRemoved = new List<DelayedTriggeredAbility>();
            foreach (var ability in DelayedTriggeredAbilities.Where(x => x.TriggeredAbility.TriggerCondition is T && x.TriggeredAbility.TriggerCondition.CanTrigger(this)))
            {
                abilities.Add(ability.TriggeredAbility.Copy() as NonStaticAbility);
                if (ability.Period is Once)
                {
                    toBeRemoved.Add(ability);
                }
            }
            _ = DelayedTriggeredAbilities.RemoveAll(x => toBeRemoved.Contains(x));
            CurrentTurn.CurrentStep.PendingAbilities.AddRange(abilities);
        }
    }
}
