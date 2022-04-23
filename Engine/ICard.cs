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
        bool IsDragon { get; }
        bool IsEvolutionCreature { get; }
        bool IsMultiColored { get; }
        bool IsNonEvolutionCreature { get; }
        List<Guid> KnownTo { get; set; }
        bool LostInBattle { get; set; }
        int ManaCost { get; set; }
        string Name { get; set; }
        Guid OnTopOf { get; set; }
        Guid Owner { get; set; }
        IPlayer OwnerPlayer { get; }
        int? Power { get; set; }
        IList<IAbility> PrintedAbilities { get; }
        int? PrintedPower { get; }
        List<Race> Races { get; set; }
        string RulesText { get; set; }
        bool ShieldTrigger { get; set; }
        bool SummoningSickness { get; set; }
        List<Supertype> Supertypes { get; set; }
        bool Tapped { get; set; }
        Guid Underneath { get; set; }
        void AddGrantedAbility(IAbility ability);
        void AddGrantedRace(Race race);
        bool CanBePaid(IPlayer player);
        ICard Copy();

        IList<ICard> Deconstruct(IGame game, IList<ICard> deconstructred);

        IEnumerable<T> GetAbilities<T>();

        IEnumerable<IEnumerable<ICard>> GetManaCombinations(IPlayer player);

        bool HasCivilization(params Civilization[] civilizations);
        bool HasRace(Race race);
        void InitializeAbilities();
        void MoveTopCard(IGame game, ZoneType destination, IAbility ability);

        void PutOnTopOf(ICard bait);
        void ResetToPrintedValues();
    }
}