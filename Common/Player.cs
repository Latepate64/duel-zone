﻿using System;

namespace Common
{
    public class Player
    {
        public Guid Id { get; }

        public string Name { get; set; }

        protected Player()
        {
            Id = Guid.NewGuid();
        }

        protected Player(Player player)
        {
            Id = player.Id;
            Name = player.Name;
        }
    }
}
