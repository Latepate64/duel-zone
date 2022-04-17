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
        private IEnumerable<IAbility> Abilities => PrintedAbilities.Union(AddedAbilities);
        public IList<IAbility> PrintedAbilities { get; } = new List<IAbility>();
        public IList<IAbility> AddedAbilities { get; } = new List<IAbility>();

        private IList<Race> _printedRaces = new List<Race>();
        private readonly IList<Race> _addedRaces = new List<Race>();

        public int? PrintedPower { get; }

        public int Timestamp { get; set; }

        internal bool CountsAsIfExists => Underneath != Guid.Empty;

        /// <summary>
        /// Also known as race for creatures.
        /// </summary>
        public List<Race> Races { get; set; } = new();

        public List<Civilization> Civilizations { get; set; } = new();

        public CardType CardType { get; set; }

        public List<Supertype> Supertypes { get; set; } = new();

        public Guid Id { get; set; }

        /// <summary>
        /// 109.5. The words “you” and “your” on an object refer to the object’s controller, its would-be controller (if a player is attempting to play, cast, or activate it), or its owner (if it has no controller).
        /// </summary>
        public Guid Owner { get; set; }

        public string Name { get; set; }

        public int? Power { get; set; }

        public int ManaCost { get; set; }

        public bool Tapped { get; set; }

        public bool ShieldTrigger { get; set; }

        public List<Guid> KnownTo { get; set; } = new();

        public bool SummoningSickness { get; set; }

        public string RulesText { get; set; }

        /// <summary>
        /// Id of the card this card is on top of.
        /// </summary>
        public Guid OnTopOf { get; set; }

        /// <summary>
        /// Id of the card this card is underneath of.
        /// </summary>
        public Guid Underneath { get; set; }

        public IEnumerable<T> GetAbilities<T>()
        {
            return Abilities.OfType<T>();
        }

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

        public virtual ICard Copy()
        {
            return new Card(this, Timestamp);
        }

        public override string ToString()
        {
            return Name;
            //return Name + " " + Id.ToString();
        }

        /// <summary>
        /// Initializes the sources and controllers of all abilities and related abstractions of the card.
        /// </summary>
        public void InitializeAbilities()
        {
            Abilities.ToList().ForEach(x => InitializeAbility(x));
            SetRulesText();
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

        public void AddGrantedAbility(IAbility ability)
        {
            AddedAbilities.Add(ability);
        }

        protected void AddAbilities(params IAbility[] abilities)
        {
            abilities.ToList().ForEach(x => PrintedAbilities.Add(x));
        }

        public bool IsEvolutionCreature => Supertypes.Any(x => x == Supertype.Evolution);

        public bool IsDragon => Races.Intersect(new Race[] { Race.ArmoredDragon, Race.EarthDragon, Race.VolcanoDragon, Race.ZombieDragon }).Any();

        public bool LostInBattle { get; set; }
        public bool IsMultiColored => Civilizations.Count > 1;

        public void ResetToPrintedValues()
        {
            Power = PrintedPower;
            AddedAbilities.Clear();
            Races = _printedRaces.ToList();
            _addedRaces.Clear();
        }

        public bool CanAttackAtLeastOneCreature(IGame game)
        {
            var canAttack = !game.GetContinuousEffects<ICannotAttackEffect>().Any(x => x.Applies(this, game));
            var opponentsCreatures = game.BattleZone.GetCreatures(game.GetOpponent(game.GetPlayer(Owner)).Id);
            return canAttack && opponentsCreatures.Any(x => CanAttackCreature(x, game));
        }

        public bool CanAttackPlayers(IGame game)
        {
            return (!game.GetContinuousEffects<ICannotAttackEffect>().Any(x => x.Applies(this, game)) && !game.GetContinuousEffects<ICannotAttackPlayersEffect>().Any(x => x.CannotAttackPlayers(this, game))) || game.GetContinuousEffects<IIgnoreCannotAttackPlayersEffects>().Any(x => x.Applies(this, game));
        }

        public bool CanEvolveFrom(IGame game, ICard card)
        {
            return game.GetContinuousEffects<IEvolutionEffect>().Any(x => x.CanEvolveFrom(card, this, game));
        }

        public bool CanBeUsedRegardlessOfManaCost(IGame game)
        {
            return (!Supertypes.Contains(Supertype.Evolution) || game.CanEvolve(this)) && !game.GetContinuousEffects<ICannotUseCardEffect>().Any(x => x.Applies(this, game));
        }

        public bool CanBePaid(IPlayer player)
        {
            return ManaCost <= player.ManaZone.UntappedCards.Count() && HasCivilizations(player.ManaZone.UntappedCards, Civilizations);
        }

        public IEnumerable<IEnumerable<ICard>> GetManaCombinations(IPlayer player)
        {
            return new Combinations<ICard>(player.ManaZone.UntappedCards, ManaCost, GenerateOption.WithoutRepetition).Where(x => HasCivilizations(x, Civilizations));//.Select(x => x.Select(y => y.Id)));
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

        public void PutOnTopOf(ICard bait)
        {
            OnTopOf = bait.Id;
            bait.Underneath = Id;
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

        public bool AffectedBySummoningSickness(IGame game)
        {
            return SummoningSickness && (!game.GetContinuousEffects<ISpeedAttackerEffect>().Any(x => x.Applies(this, game)) || !game.GetContinuousEffects<IIgnoreCannotAttackPlayersEffects>().Any(x => x.Applies(this, game)));
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

        public bool CanAttackCreature(ICard targetOfAttack, IGame game)
        {
            return !game.GetContinuousEffects<ICannotAttackEffect>().Any(x => x.Applies(this, game)) &&
                !game.GetContinuousEffects<ICannotAttackCreaturesEffect>().Any(x => x.CannotAttackCreature(this, targetOfAttack, game)) &&
                !game.GetContinuousEffects<ICannotBeAttackedEffect>().Any(x => x.Applies(this, targetOfAttack, game));
        }

        public void Break(IGame game, int breakAmount)
        {
            game.ProcessEvents(new BreakShieldsEvent(this, breakAmount));
        }

        public bool HasCivilization(params Civilization[] civilizations)
        {
            return Civilizations.Intersect(civilizations).Any();
        }

        public bool HasRace(Race race)
        {
            return Races.Contains(race);
        }

        public void AddGrantedRace(Race race)
        {
            _addedRaces.Add(race);
            if (!Races.Contains(race))
            {
                Races.Add(race);
            }
        }

        protected void SetPrintedRaces(params Race[] races)
        {
            _printedRaces = races;
            Races = races.ToList();
        }
    }
}
