﻿using Combinatorics.Collections;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Card : Common.Card, ICopyable<ICard>, ITimestampable, ICard
    {
        private IEnumerable<Ability> Abilities => PrintedAbilities.Union(AddedAbilities);
        public List<Ability> PrintedAbilities { get; } = new();
        public List<Ability> AddedAbilities { get; } = new();

        public int? PrintedPower { get; }

        public int Timestamp { get; }

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
            foreach (var ability in Abilities)
            {
                ability.Owner = Owner;
                ability.Source = Id;
                if (ability is StaticAbility staticAbility)
                {
                    foreach (var effect in staticAbility.ContinuousEffects)
                    {
                        if (effect.Filter is ITargetFilterable target)
                        {
                            target.Target = Id;
                        }
                        effect.SetupConditionFilters(Id);
                    }
                }
                else if (ability is CardTriggeredAbility triggeredAbility && triggeredAbility.Filter is TargetFilter target)
                {
                    target.Target = Id;
                }
            }
            SetRulesText();
        }

        public Common.Card Convert(bool clear = false)
        {
            return new Common.Card(this, clear);
        }

        private void SetRulesText()
        {
            RulesText = string.Join("\r\n", Abilities.Select(x => x.ToString()));
        }

        public void AddGrantedAbility(Ability ability)
        {
            AddedAbilities.Add(ability);
        }

        protected void AddAbilities(params Ability[] abilities)
        {
            PrintedAbilities.AddRange(abilities);
        }

        public bool IsEvolutionCreature => Supertypes.Any(x => x == Common.Supertype.Evolution);

        public void ResetToPrintedValues()
        {
            Power = PrintedPower;
            AddedAbilities.Clear();
        }

        public bool CanAttackCreatures(IGame game)
        {
            return !game.GetContinuousEffects<CannotAttackCreaturesEffect>(this).Any();
        }

        public bool CanAttackPlayers(IGame game)
        {
            return !game.GetContinuousEffects<CannotAttackPlayersEffect>(this).Any() || game.GetContinuousEffects<IgnoreCannotAttackPlayersEffects>(this).Any();
        }

        public bool CanEvolveFrom(IGame game, ICard card)
        {
            return game.GetContinuousEffects<IEvolutionEffect>(this).Any(x => x.CanEvolveFrom(card));
        }

        public bool CanBeUsedRegardlessOfManaCost(IGame game)
        {
            return !Supertypes.Contains(Common.Supertype.Evolution) || game.CanEvolve(this);
        }

        public bool CanBePaid(Player player)
        {
            return ManaCost <= player.ManaZone.UntappedCards.Count() && HasCivilizations(player.ManaZone.UntappedCards, Civilizations);
        }

        public IEnumerable<IEnumerable<ICard>> GetManaCombinations(Player player)
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

        public List<ICard> Deconstruct(IGame game, List<ICard> deconstructred)
        {
            if (Underneath != Guid.Empty)
            {
                deconstructred.AddRange(game.GetCard(Underneath).Deconstruct(game, deconstructred));
                Underneath = Guid.Empty;
                return deconstructred;
            }
            else
            {
                OnTopOf = Guid.Empty;
                return new List<ICard> { this };
            }
        }
    }
}
