﻿using Engine.Abilities;
using System.Collections.Generic;

namespace Engine
{
    public interface ICard : Common.ICard, ITimestampable, IAttackable
    {
        bool IsEvolutionCreature { get; }
        IList<IAbility> PrintedAbilities { get; }
        IList<IAbility> AddedAbilities { get; }
        int? PrintedPower { get; }
        bool IsDragon { get; }
        bool LostInBattle { get; set; }
        bool IsMultiColored { get; }
        List<Subtype> Subtypes { get; set; }
        List<Civilization> Civilizations { get; set; }
        CardType CardType { get; set; }
        List<Supertype> Supertypes { get; set; }

        void AddGrantedAbility(IAbility ability);
        bool AffectedBySummoningSickness(IGame game);
        bool CanAttack(ICard creature, IGame game);
        bool CanAttackCreatures(IGame game);
        bool HasCivilization(params Civilization[] civilizations);
        void AddGrantedSubtype(Subtype subtype);
        bool CanAttackPlayers(IGame game);
        bool CanBePaid(IPlayer player);
        bool CanBeUsedRegardlessOfManaCost(IGame game);
        bool CanEvolveFrom(IGame game, ICard card);
        Common.ICard Convert(bool clear = false);
        ICard Copy();
        IList<ICard> Deconstruct(IGame game, IList<ICard> deconstructred);
        bool HasSubtype(Subtype subtype);
        IEnumerable<T> GetAbilities<T>();
        IEnumerable<IEnumerable<ICard>> GetManaCombinations(IPlayer player);
        void Break(IGame game, int breakAmount);
        void InitializeAbilities();
        void PutOnTopOf(ICard bait);
        void ResetToPrintedValues();
        void MoveTopCardIntoOwnersGraveyard(IGame game);
    }
}