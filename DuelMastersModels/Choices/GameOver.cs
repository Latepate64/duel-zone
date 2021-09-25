using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public enum WinReason { DirectAttack, Deckout, Bombazar };

    public class GameOver : Choice
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

        public GameOver(GameOver gameOver) : base(Guid.Empty)
        {
            WinReason = gameOver.WinReason;
            Winners = gameOver.Winners.Select(x => x);
            Losers = gameOver.Losers.Select(x => x);
        }

        public override string ToString()
        {
            return $"Reason: {WinReason} Winners: {Winners.First()} Losers: {Losers.First()}";
        }
    }
}
