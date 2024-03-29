﻿using Engine.Abilities;
using Engine.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public interface ICard : ITimestampable, IAttackable
    {
        IList<IAbility> AddedAbilities { get; }
        CardType CardType { get; set; }
        List<Civilization> Civilizations { get; set; }
        bool FaceDown { get; set; }
        Guid Id { get; set; }
        bool IsDragon => Races.Intersect(new Race[] { Race.ArmoredDragon, Race.EarthDragon, Race.VolcanoDragon, Race.ZombieDragon }).Any();
        bool IsEvolutionCreature => Supertypes.Any(x => x == Supertype.Evolution);
        bool IsMultiColored => Civilizations.Count > 1;
        bool IsNonEvolutionCreature => CardType == CardType.Creature && !IsEvolutionCreature;
        List<Guid> KnownTo { get; set; }
        bool LostInBattle { get; set; }
        int ManaCost { get; set; }
        string Name { get; set; }
        ICard OnTopOf { get; set; }
        IPlayer Owner { get; set; }
        int? Power { get; set; }
        IList<IAbility> PrintedAbilities { get; }
        int? PrintedPower { get; }
        List<Race> Races { get; set; }
        string RulesText { get; set; }
        bool ShieldTrigger { get; set; }
        bool SummoningSickness { get; set; }
        List<Supertype> Supertypes { get; set; }
        bool Tapped { get; set; }
        ICard Underneath { get; set; }
        int PhysicalCardId { get; set; }

        void AddGrantedAbility(IAbility ability);
        void AddGrantedRace(Race race);
        bool CanBePaid(IPlayer player);
        ICard Copy();

        IList<ICard> Deconstruct(IList<ICard> deconstructred);

        IEnumerable<T> GetAbilities<T>();
        IEnumerable<IEvolutionEffect> GetEvolutionEffects();
        IEnumerable<IEnumerable<ICard>> GetManaCombinations(IPlayer player);
        IEnumerable<SilentSkillAbility> GetSilentSkillAbilities();
        IEnumerable<TapAbility> GetTapAbilities();
        bool HasCivilization(params Civilization[] civilizations);
        bool HasRace(Race race);
        void InitializeAbilities();
        void PutOnTopOf(IEnumerable<ICard> bait);
        void ResetToPrintedValues();
        void SeparateTopCard();
    }
}