using Engine.Abilities;
using System.Collections.Generic;

namespace Engine
{
    public interface ICard : Common.ICard
    {
        bool IsEvolutionCreature { get; }
        List<Ability> PrintedAbilities { get; }
        List<Ability> AddedAbilities { get; }
        int? PrintedPower { get; }
        int Timestamp { get; }

        void AddGrantedAbility(Ability ability);
        bool CanAttackCreatures(IGame game);
        bool CanAttackPlayers(IGame game);
        bool CanBePaid(Player player);
        bool CanBeUsedRegardlessOfManaCost(IGame game);
        bool CanEvolveFrom(IGame game, ICard card);
        Common.Card Convert(bool clear = false);
        ICard Copy();
        List<ICard> Deconstruct(IGame game, List<ICard> deconstructred);
        IEnumerable<T> GetAbilities<T>();
        IEnumerable<IEnumerable<ICard>> GetManaCombinations(Player player);
        void InitializeAbilities();
        void PutOnTopOf(ICard bait);
        void ResetToPrintedValues();
    }
}