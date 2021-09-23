using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public enum WinReason { DirectAttack, Deckout, Bombazar };

    public class GameOver : Choice
    {
        public WinReason WinReason { get; private set; }
        public IEnumerable<Player> Winners { get; private set; }
        public IEnumerable<Player> Losers { get; private set; }

        public GameOver(WinReason winReason, IEnumerable<Player> winners, IEnumerable<Player> losers) : base(null)
        {
            WinReason = winReason;
            Winners = winners;
            Losers = losers;
        }
    }
}
