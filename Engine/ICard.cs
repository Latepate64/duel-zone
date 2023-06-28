using Engine.Abilities;
using System;
using System.Collections.Generic;

namespace Engine
{
    public interface ICard : ITimestampable, IAttackable
    {
        IList<IAbility> AddedAbilities { get; }
        CardType CardType { get; set; }
        List<Civilization> Civilizations { get; set; }
        bool FaceDown { get; set; }
        Guid Id { get; set; }
        bool IsCreature { get; }
        bool IsDragon { get; }
        bool IsEvolutionCreature { get; }
        bool IsMultiColored { get; }
        bool IsNonEvolutionCreature { get; }
        bool IsSpell { get; }
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
        void AddGrantedAbility(IAbility ability);
        void AddGrantedRace(Race race);
        bool CanBePaid(IPlayer player);
        ICard Copy();

        IList<ICard> Deconstruct(IList<ICard> deconstructred);

        IEnumerable<T> GetAbilities<T>();

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