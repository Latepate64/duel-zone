using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public enum WinReason { DirectAttack, Deckout, Bombazar };

    public class GameOver : Choice, ICopyable<GameOver>
    {
        public WinReason WinReason { get; private set; }
        public IEnumerable<Guid> Winners { get; private set; }
        public IEnumerable<Guid> Losers { get; private set; }

        public GameOver(WinReason winReason, IEnumerable<Guid> winners, IEnumerable<Guid> losers) : base(Guid.Empty)
        {
            WinReason = winReason;
            Winners = winners;
            Losers = losers;
        }

        public GameOver Copy()
        {
            return new GameOver(WinReason, Winners.Select(x => x), Losers.Select(x => x));
        }
    }
}
