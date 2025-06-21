using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface IPlayerChoice
    {
        IPlayer Choice { get; set; }
        IEnumerable<IPlayer> Options { get; }
    }

    public class PlayerChoice : Choice, IPlayerChoice
    {
        public PlayerChoice(PlayerChoice choice) : base(choice)
        {
        }

        public PlayerChoice(IPlayer maker, string description, IEnumerable<IPlayer> options) : base(maker, description)
        {
            Options = options;
        }

        public IPlayer Choice { get; set; }
        public IEnumerable<IPlayer> Options { get; }

        public override bool IsValid()
        {
            return Options.Contains(Choice);
        }
    }
}
