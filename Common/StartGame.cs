using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class StartGame
    {
        public List<PlayerDeck> Players { get; set; }
    }

    [Serializable]
    public class PlayerDeck
    {
        public Player Player { get; set; }

        public List<Card> Deck { get; set; }
    }
}
