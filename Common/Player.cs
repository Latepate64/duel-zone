using System;

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

        public Player(Player player)
        {
            Id = player.Id;
            Name = player.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
