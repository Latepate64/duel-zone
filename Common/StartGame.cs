﻿using System.Collections.Generic;

namespace Common
{
    public class StartGame
    {
        public List<PlayerDeck> Players { get; set; }
    }

    public class PlayerDeck
    {
        public Player Player { get; set; }

        public List<ICard> Deck { get; set; }
    }
}
