using Engine.Steps;
using System.Collections.Generic;

namespace Engine
{
    public interface ITurn : Common.ITurn
    {
        IPlayer ActivePlayer { get; set; }
        IPlayer NonActivePlayer { get; set; }
        Phase CurrentPhase { get; }
        IList<Phase> Phases { get; }

        Common.ITurn Convert();
        void Dispose();
        void Play(IGame game, int number);
    }
}