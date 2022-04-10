using Engine.Abilities;
using Engine.GameEvents;
using System.Collections.Generic;

namespace Engine.Steps
{
    public enum PhaseOrStep
    {
        StartOfTurn,
        Draw,
        Charge,
        Main,
        Attack,
        AttackDeclaration,
        BlockDeclaration,
        Battle,
        DirectAttack,
        EndOfAttack,
        EndOfTurn,
    }

    public interface IPhase
    {
        Queue<IGameEvent> GameEvents { get; }
        List<IResolvableAbility> PendingAbilities { get; }
        PhaseOrStep Type { get; }
        List<ICard> UsedCards { get; }

        IPhase Copy();
        IPhase GetNextPhase(IGame game);
        void Play(IGame game);
    }
}