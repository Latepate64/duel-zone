using Engine.Steps;
using System.Collections.Generic;

namespace Engine
{
    public interface ITurn : Common.ITurn
    {
        IPlayer ActivePlayer { get; set; }
        IPlayer NonActivePlayer { get; set; }
        IPhase CurrentPhase { get; }
        IList<IPhase> Phases { get; }

        Common.ITurn Convert();
        void Dispose();
        void Play(IGame game, int number);
    }
}