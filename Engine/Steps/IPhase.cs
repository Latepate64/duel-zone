using Common.GameEvents;
using Engine.Abilities;
using System.Collections.Generic;

namespace Engine.Steps
{
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