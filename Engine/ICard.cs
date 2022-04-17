using Engine.Abilities;
using System;
using System.Collections.Generic;

namespace Engine
{
    public interface ICard : ITimestampable, IAttackable
    {
        bool IsEvolutionCreature { get; }
        IList<IAbility> PrintedAbilities { get; }
        IList<IAbility> AddedAbilities { get; }
        int? PrintedPower { get; }
        bool IsDragon { get; }
        bool LostInBattle { get; set; }
        bool IsMultiColored { get; }
        List<Race> Races { get; set; }
        List<Civilization> Civilizations { get; set; }
        CardType CardType { get; set; }
        List<Supertype> Supertypes { get; set; }
        List<Guid> KnownTo { get; set; }
        int ManaCost { get; set; }
        string Name { get; set; }
        Guid OnTopOf { get; set; }
        Guid Owner { get; set; }
        int? Power { get; set; }
        string RulesText { get; set; }
        bool ShieldTrigger { get; set; }
        bool SummoningSickness { get; set; }
        bool Tapped { get; set; }
        Guid Underneath { get; set; }
        Guid Id { get; set; }

        void AddGrantedAbility(IAbility ability);
        bool AffectedBySummoningSickness(IGame game);
        bool CanAttackCreature(ICard creature, IGame game);
        bool CanAttackAtLeastOneCreature(IGame game);
        bool HasCivilization(params Civilization[] civilizations);
        void AddGrantedRace(Race race);
        bool CanAttackPlayers(IGame game);
        bool CanBePaid(IPlayer player);
        bool CanBeUsedRegardlessOfManaCost(IGame game);
        bool CanEvolveFrom(IGame game, ICard card);
        ICard Copy();
        IList<ICard> Deconstruct(IGame game, IList<ICard> deconstructred);
        bool HasRace(Race race);
        IEnumerable<T> GetAbilities<T>();
        IEnumerable<IEnumerable<ICard>> GetManaCombinations(IPlayer player);
        void Break(IGame game, int breakAmount);
        void InitializeAbilities();
        void PutOnTopOf(ICard bait);
        void ResetToPrintedValues();
        void MoveTopCard(IGame game, ZoneType destination, IAbility ability);
    }
}