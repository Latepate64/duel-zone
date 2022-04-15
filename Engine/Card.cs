using Combinatorics.Collections;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Card : Common.Card, ICopyable<ICard>, ITimestampable, ICard
    {
        private IEnumerable<IAbility> Abilities => PrintedAbilities.Union(AddedAbilities);
        public IList<IAbility> PrintedAbilities { get; } = new List<IAbility>();
        public IList<IAbility> AddedAbilities { get; } = new List<IAbility>();

        private IList<Common.Subtype> _printedSubtypes = new List<Common.Subtype>();
        private readonly IList<Common.Subtype> _addedSubtypes = new List<Common.Subtype>();

        public int? PrintedPower { get; }

        public int Timestamp { get; set; }

        internal bool CountsAsIfExists => Underneath != Guid.Empty;

        public IEnumerable<T> GetAbilities<T>()
        {
            return Abilities.OfType<T>();
        }

        public Card() { }

        public Card(int? power)
        {
            PrintedPower = power;
        }

        internal Card(ICard card, int timeStamp) : base(card, false)
        {
            Timestamp = timeStamp; // 613.7d An object receives a timestamp at the time it enters a zone.
            AddedAbilities = card.AddedAbilities.Select(x => x.Copy()).ToList();
            PrintedAbilities = card.PrintedAbilities.Select(x => x.Copy()).ToList();
            PrintedPower = card.PrintedPower;
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

        public Common.ICard Convert(bool clear = false)
        {
            return new Common.Card(this, clear);
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

        public bool IsEvolutionCreature => Supertypes.Any(x => x == Common.Supertype.Evolution);

        public bool IsDragon => Subtypes.Intersect(new Common.Subtype[] { Common.Subtype.ArmoredDragon, Common.Subtype.EarthDragon, Common.Subtype.VolcanoDragon, Common.Subtype.ZombieDragon }).Any();

        public bool LostInBattle { get; set; }
        public bool IsMultiColored => Civilizations.Count > 1;

        public void ResetToPrintedValues()
        {
            Power = PrintedPower;
            AddedAbilities.Clear();
            Subtypes = _printedSubtypes.ToList();
            _addedSubtypes.Clear();
        }

        public bool CanAttackCreatures(IGame game)
        {
            return !game.GetContinuousEffects<ICannotAttackEffect>().Any(x => x.Applies(this, game)) && !game.GetContinuousEffects<ICannotAttackCreaturesEffect>().Any(x => x.Applies(this, game));
        }

        public bool CanAttackPlayers(IGame game)
        {
            return (!game.GetContinuousEffects<ICannotAttackEffect>().Any(x => x.Applies(this, game)) && !game.GetContinuousEffects<ICannotAttackPlayersEffect>().Any(x => x.Applies(this, game))) || game.GetContinuousEffects<IIgnoreCannotAttackPlayersEffects>().Any(x => x.Applies(this, game));
        }

        public bool CanEvolveFrom(IGame game, ICard card)
        {
            return game.GetContinuousEffects<IEvolutionEffect>().Any(x => x.CanEvolveFrom(card, this, game));
        }

        public bool CanBeUsedRegardlessOfManaCost(IGame game)
        {
            return (!Supertypes.Contains(Common.Supertype.Evolution) || game.CanEvolve(this)) && !game.GetContinuousEffects<ICannotUseCardEffect>().Any(x => x.Applies(this, game));
        }

        public bool CanBePaid(IPlayer player)
        {
            return ManaCost <= player.ManaZone.UntappedCards.Count() && HasCivilizations(player.ManaZone.UntappedCards, Civilizations);
        }

        public IEnumerable<IEnumerable<ICard>> GetManaCombinations(IPlayer player)
        {
            return new Combinations<ICard>(player.ManaZone.UntappedCards, ManaCost, GenerateOption.WithoutRepetition).Where(x => HasCivilizations(x, Civilizations));//.Select(x => x.Select(y => y.Id)));
        }

        internal static bool HasCivilizations(IEnumerable<ICard> manas, IEnumerable<Common.Civilization> civs)
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

        public void MoveTopCardIntoOwnersGraveyard(IGame game)
        {
            if (OnTopOf != Guid.Empty)
            {
                var card = game.GetCard(OnTopOf);
                OnTopOf = Guid.Empty;
                card.Underneath = Guid.Empty;
            }
            game.Move(ZoneType.BattleZone, ZoneType.Graveyard, this);
        }

        public bool CanAttack(ICard targetOfAttack, IGame game)
        {
            return !game.GetContinuousEffects<ICannotBeAttackedEffect>().Any(x => x.Applies(this, targetOfAttack, game));
        }

        public void Break(IGame game, int breakAmount)
        {
            game.ProcessEvents(new ShieldsBrokenEvent(this, breakAmount));
        }

        public bool HasCivilization(params Common.Civilization[] civilizations)
        {
            return Civilizations.Intersect(civilizations).Any();
        }

        public bool HasSubtype(Common.Subtype subtype)
        {
            return Subtypes.Contains(subtype);
        }

        public void AddGrantedSubtype(Common.Subtype subtype)
        {
            _addedSubtypes.Add(subtype);
            if (!Subtypes.Contains(subtype))
            {
                Subtypes.Add(subtype);
            }
        }

        protected void SetPrintedSubtypes(params Common.Subtype[] subtypes)
        {
            _printedSubtypes = subtypes;
            Subtypes = subtypes.ToList();
        }
    }
}
