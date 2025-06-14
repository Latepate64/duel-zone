using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface IPlayerChoice
    {
        Player Choice { get; set; }
        IEnumerable<Player> Options { get; }
    }

    public class PlayerChoice : Choice, IPlayerChoice
    {
        public PlayerChoice(PlayerChoice choice) : base(choice)
        {
        }

        public PlayerChoice(Player maker, string description, IEnumerable<Player> options) : base(maker, description)
        {
            Options = options;
        }

        public Player Choice { get; set; }
        public IEnumerable<Player> Options { get; }

        public override bool IsValid()
        {
            return Options.Contains(Choice);
        }
    }
}
