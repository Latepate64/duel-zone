using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public enum WinReason { DirectAttack, Deckout, Bombazar };

    public class GameOver : Choice, ICopyable<GameOver>
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

        public GameOver Copy()
        {
            return new GameOver(WinReason, Winners.Select(x => x.Copy()), Losers.Select(x => x.Copy()));
        }
    }
}
