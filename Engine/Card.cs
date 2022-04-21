using Combinatorics.Collections;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Card : ICard, ICopyable<ICard>, ITimestampable
    {
        private readonly IList<Race> _addedRaces = new List<Race>();
        private IList<Race> _printedRaces = new List<Race>();
        public Card()
        {
            Id = Guid.NewGuid();
        }

        public Card(int? power) : this()
        {
            PrintedPower = power;
        }

        internal Card(ICard card, int timeStamp)
        {
            Id = Guid.NewGuid();
            Owner = card.Owner;
            KnownTo = card.KnownTo.ToList();
            ManaCost = card.ManaCost;
            Name = card.Name;
            OnTopOf = card.OnTopOf;
            Power = card.Power;
            RulesText = card.RulesText;
            ShieldTrigger = card.ShieldTrigger;
            SummoningSickness = card.SummoningSickness;
            Tapped = card.Tapped;
            Underneath = card.Underneath;
            FaceDown = card.FaceDown;

            Timestamp = timeStamp; // 613.7d An object receives a timestamp at the time it enters a zone.
            AddedAbilities = card.AddedAbilities.Select(x => x.Copy()).ToList();
            CardType = card.CardType;
            Civilizations = card.Civilizations.ToList();
            PrintedAbilities = card.PrintedAbilities.Select(x => x.Copy()).ToList();
            PrintedPower = card.PrintedPower;
            Races = card.Races?.ToList();
            Supertypes = card.Supertypes?.ToList();
            InitializeAbilities();
        }

        public IList<IAbility> AddedAbilities { get; } = new List<IAbility>();
        public CardType CardType { get; set; }
        public List<Civilization> Civilizations { get; set; } = new();
        /// <summary>
        /// TODO: Apply in logic
        /// </summary>
        public bool FaceDown { get; set; }

        public Guid Id { get; set; }
        public bool IsDragon => Races.Intersect(new Race[] { Race.ArmoredDragon, Race.EarthDragon, Race.VolcanoDragon, Race.ZombieDragon }).Any();
        public bool IsEvolutionCreature => Supertypes.Any(x => x == Supertype.Evolution);
        public bool IsMultiColored => Civilizations.Count > 1;
        public bool IsNonEvolutionCreature => CardType == CardType.Creature && !IsEvolutionCreature;
        public List<Guid> KnownTo { get; set; } = new();
        public bool LostInBattle { get; set; }
        public int ManaCost { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Id of the card this card is on top of.
        /// </summary>
        public Guid OnTopOf { get; set; }

        /// <summary>
        /// 109.5. The words “you” and “your” on an object refer to the object’s controller, its would-be controller (if a player is attempting to play, cast, or activate it), or its owner (if it has no controller).
        /// </summary>
        public Guid Owner { get; set; }

        public int? Power { get; set; }
        public IList<IAbility> PrintedAbilities { get; } = new List<IAbility>();
        public int? PrintedPower { get; }
        /// <summary>
        /// Also known as race for creatures.
        /// </summary>
        public List<Race> Races { get; set; } = new();

        public string RulesText { get; set; }
        public bool ShieldTrigger { get; set; }
        public bool SummoningSickness { get; set; }
        public List<Supertype> Supertypes { get; set; } = new();
        public bool Tapped { get; set; }
        public int Timestamp { get; set; }
        /// <summary>
        /// Id of the card this card is underneath of.
        /// </summary>
        public Guid Underneath { get; set; }

        internal bool CountsAsIfExists => Underneath != Guid.Empty;
        private IEnumerable<IAbility> Abilities => PrintedAbilities.Union(AddedAbilities);

        public IPlayer OwnerPlayer { get; internal set; }

        public void AddGrantedAbility(IAbility ability)
        {
            AddedAbilities.Add(ability);
        }

        public void AddGrantedRace(Race race)
        {
            _addedRaces.Add(race);
            if (!Races.Contains(race))
            {
                Races.Add(race);
            }
        }

        public bool AffectedBySummoningSickness(IGame game)
        {
            return SummoningSickness && (!game.GetContinuousEffects<ISpeedAttackerEffect>().Any(x => x.Applies(this, game)) || !game.GetContinuousEffects<IIgnoreCannotAttackPlayersEffects>().Any(x => x.IgnoreCannotAttackPlayersEffects(this, game)));
        }

        public void Break(IGame game, int breakAmount)
        {
            game.ProcessEvents(new CreatureBreaksShieldsEvent(this, breakAmount));
        }

        public bool CanAttackAtLeastOneCreature(IGame game)
        {
            var canAttack = !game.GetContinuousEffects<ICannotAttackEffect>().Any(x => x.CannotAttack(this, game));
            var opponentsCreatures = game.BattleZone.GetCreatures(game.GetOpponent(game.GetPlayer(Owner)).Id);
            return canAttack && opponentsCreatures.Any(x => CanAttackCreature(x, game));
        }

        public bool CanAttackCreature(ICard targetOfAttack, IGame game)
        {
            return !game.GetContinuousEffects<ICannotAttackEffect>().Any(x => x.CannotAttack(this, game)) &&
                !game.GetContinuousEffects<ICannotAttackCreaturesEffect>().Any(x => x.CannotAttackCreature(this, targetOfAttack, game)) &&
                !game.GetContinuousEffects<ICannotBeAttackedEffect>().Any(x => x.Applies(this, targetOfAttack, game));
        }

        public bool CanAttackPlayers(IGame game)
        {
            return (!game.GetContinuousEffects<ICannotAttackEffect>().Any(x => x.CannotAttack(this, game)) && !game.GetContinuousEffects<ICannotAttackPlayersEffect>().Any(x => x.CannotAttackPlayers(this, game))) || game.GetContinuousEffects<IIgnoreCannotAttackPlayersEffects>().Any(x => x.IgnoreCannotAttackPlayersEffects(this, game));
        }

        public bool CanBePaid(IPlayer player)
        {
            return ManaCost <= player.ManaZone.UntappedCards.Count() && HasCivilizations(player.ManaZone.UntappedCards, Civilizations);
        }

        public bool CanBeUsedRegardlessOfManaCost(IGame game)
        {
            return (!Supertypes.Contains(Supertype.Evolution) || game.CanEvolve(this)) && !game.GetContinuousEffects<ICannotUseCardEffect>().Any(x => x.Applies(this, game));
        }

        public bool CanEvolveFrom(IGame game, ICard card)
        {
            return game.GetContinuousEffects<IEvolutionEffect>().Any(x => x.CanEvolveFrom(card, this, game));
        }

        public virtual ICard Copy()
        {
            return new Card(this, Timestamp);
        }

        public IList<ICard> Deconstruct(IGame game, IList<ICard> deconstructred)
        {
            if (Underneath != Guid.Empty)
            {
                var list = deconstructred.ToList();
                list.AddRange(game.GetCard(Underneath).Deconstruct(game, deconstructred));
                Underneath = Guid.Empty;
                return list;
            }
            else
            {
                OnTopOf = Guid.Empty;
                return new List<ICard> { this };
            }
        }

        public IEnumerable<T> GetAbilities<T>()
        {
            return Abilities.OfType<T>();
        }
        public IEnumerable<IEnumerable<ICard>> GetManaCombinations(IPlayer player)
        {
            return new Combinations<ICard>(player.ManaZone.UntappedCards, ManaCost, GenerateOption.WithoutRepetition).Where(x => HasCivilizations(x, Civilizations));//.Select(x => x.Select(y => y.Id)));
        }

        public bool HasCivilization(params Civilization[] civilizations)
        {
            return Civilizations.Intersect(civilizations).Any();
        }

        public bool HasRace(Race race)
        {
            return Races.Contains(race);
        }

        /// <summary>
        /// Initializes the sources and controllers of all abilities and related abstractions of the card.
        /// </summary>
        public void InitializeAbilities()
        {
            Abilities.ToList().ForEach(x => InitializeAbility(x));
            SetRulesText();
        }

        public void MoveTopCard(IGame game, ZoneType destination, IAbility ability)
        {
            if (OnTopOf != Guid.Empty)
            {
                var card = game.GetCard(OnTopOf);
                OnTopOf = Guid.Empty;
                card.Underneath = Guid.Empty;
            }
            game.Move(ability, ZoneType.BattleZone, destination, this);
        }

        public void PutOnTopOf(ICard bait)
        {
            OnTopOf = bait.Id;
            bait.Underneath = Id;
        }

        public void ResetToPrintedValues()
        {
            Power = PrintedPower;
            AddedAbilities.Clear();
            Races = _printedRaces.ToList();
            _addedRaces.Clear();
        }

        public override string ToString()
        {
            return Name;
            //return Name + " " + Id.ToString();
        }
        internal static bool HasCivilizations(IEnumerable<ICard> manas, IEnumerable<Civilization> civs)
        {
            if (!civs.Any())
            {
                return true;
            }
            else if (!manas.Any())
            {
                return false;
            }
            else
            {
                return manas.First().Civilizations.Any(x => HasCivilizations(manas.Skip(1), civs.Where(c => c != x)));
            }
        }

        protected void AddAbilities(params IAbility[] abilities)
        {
            abilities.ToList().ForEach(x => PrintedAbilities.Add(x));
        }

        protected void SetPrintedRaces(params Race[] races)
        {
            _printedRaces = races;
            Races = races.ToList();
        }

        private void InitializeAbility(IAbility ability)
        {
            ability.Controller = Owner;
            ability.Source = Id;
        }

        private void SetRulesText()
        {
            RulesText = string.Join("\r\n", Abilities.Select(x => x.ToString()));
        }
    }
}