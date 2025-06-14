using Engine.GameEvents;
using Engine.Steps;
using System.Collections.Generic;

namespace Engine
{
    public interface ITurn
    {
        Player ActivePlayer { get; set; }
        IPhase CurrentPhase { get; }
        System.Guid Id { get; set; }
        Player NonActivePlayer { get; set; }
        int Number { get; set; }
        IList<IPhase> Phases { get; }
        IEnumerable<IGameEvent> GameEvents { get; }

        void Dispose();
        void Play(IGame game, int number);
        void StartCurrentPhase(IGame game);
    }
}