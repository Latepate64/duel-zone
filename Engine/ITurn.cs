using Engine.Steps;
using System.Collections.Generic;

namespace Engine
{
    public interface ITurn
    {
        IPlayer ActivePlayer { get; set; }
        IPhase CurrentPhase { get; }
        System.Guid Id { get; set; }
        IPlayer NonActivePlayer { get; set; }
        int Number { get; set; }
        IList<IPhase> Phases { get; }

        void Dispose();
        void Play(IGame game, int number);
        void StartCurrentPhase(IGame game);
    }
}