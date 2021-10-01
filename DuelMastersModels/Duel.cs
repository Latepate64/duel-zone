using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DuelMastersModels.Abilities.Triggered;
using DuelMastersModels.Effects.Periods;
using DuelMastersModels.Abilities;

namespace DuelMastersModels
{
    public class Duel : IDisposable
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

        public Turn CurrentTurn => Turns.Last();

        public IEnumerable<Card> BattleZoneCreatures => Players.SelectMany(x => x.BattleZone.Creatures);

        internal Stack<Card> ResolvingSpells = new Stack<Card>();
        internal Queue<SpellAbility> ResolvingSpellAbilities = new Queue<SpellAbility>();

        /// <summary>
        /// All the turns of the duel that have been or are processed, in order.
        /// </summary>
        public IList<Turn> Turns { get; } = new List<Turn>();

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
            if (ExtraTurns.Any())
            {
                Turns.Add(ExtraTurns.Dequeue());
            }
            else
            {
                Turns.Add(new Turn(activePlayer, nonActivePlayer));
            }
            return Turns.Last().Start(this, Turns.Count);
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
            Card attackingCreature = GetCard(attackingCreatureId);
            Card defendingCreature = GetCard(defendingCreatureId);
            int attackingCreaturePower = attackingCreature.Power.Value;
            int defendingCreaturePower = defendingCreature.Power.Value;
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
            CurrentTurn.CurrentStep.UsedCards.Add(card.Id);
            if (card.CardType == CardType.Creature)
            {
                player.Hand.Remove(card);
                player.BattleZone.Add(card, this);
            }
            else if (card.CardType == CardType.Spell)
            {
                player.Cast(card, this);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Checks if a card can be used.
        /// </summary>
        internal static bool CanBeUsed(Card card, IEnumerable<Card> manaCards)
        {
            //TODO: Remove static keyword after usability is checked with continuous effects considered.
            //System.Collections.Generic.IEnumerable<Civilization> manaCivilizations = manaCards.SelectMany(manaCard => manaCard.Civilizations).Distinct();
            //return card.Cost <= manaCards.Count && card.Civilizations.Intersect(manaCivilizations).Count() == 1; //TODO: Add support for multicolored cards.
            return card.ManaCost <= manaCards.Count() && HasCivilizations(manaCards, card.Civilizations);
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

        internal void Destroy(IEnumerable<Card> creatures)
        {
            while (creatures.Any())
            {
                GetOwner(creatures.First()).PutFromBattleZoneIntoGraveyard(creatures.First(), this);
            }
        }

        public Duel() { }

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
            ResolvingSpellAbilities = new Queue<SpellAbility>(duel.ResolvingSpellAbilities.Select(x => x.Copy()).Cast<SpellAbility>());
            ResolvingSpells = new Stack<Card>(duel.ResolvingSpells.Select(x => x.Copy()));
            Turns = duel.Turns.Select(x => new Turn(x)).ToList();
        }

        internal Queue<Turn> ExtraTurns { get; private set; } = new Queue<Turn>();

        internal List<DelayedTriggeredAbility> DelayedTriggeredAbilities = new List<DelayedTriggeredAbility>();

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

        public void Trigger<T>() where T : TriggeredAbility
        {
            var abilities = BattleZoneCreatures.SelectMany(x => x.Abilities).OfType<T>().Where(x => x.CanTrigger(this)).Select(x => x.Copy()).ToList();
            List<DelayedTriggeredAbility> toBeRemoved = new List<DelayedTriggeredAbility>();
            foreach (var ability in DelayedTriggeredAbilities.Where(x => x.TriggeredAbility is T && x.TriggeredAbility.CanTrigger(this)))
            {
                abilities.Add(ability.TriggeredAbility.Copy());
                if (ability.Period is Once)
                {
                    toBeRemoved.Add(ability);
                }
            }
            _ = DelayedTriggeredAbilities.RemoveAll(x => toBeRemoved.Contains(x));
            CurrentTurn.CurrentStep.PendingAbilities.AddRange(abilities.Cast<NonStaticAbility>());
        }

        public override string ToString()
        {
            return $"{CurrentTurn} {GameOverInformation}";
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var x in ExtraTurns)
                {
                    x.Dispose();
                }
                ExtraTurns = null;
                GameOverInformation?.Dispose();
                GameOverInformation = null;
                Player1.Dispose();
                Player1 = null;
                Player2.Dispose();
                Player2 = null;
                DelayedTriggeredAbilities = null;
                ResolvingSpellAbilities = null;
                foreach (var x in ResolvingSpells)
                {
                    x.Dispose();
                }
                ResolvingSpells = null;
                foreach (var x in Turns)
                {
                    x.Dispose();
                }
                Turns.Clear();
            }
        }
    }
}
