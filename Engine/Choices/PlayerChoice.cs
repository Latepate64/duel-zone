using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Choices;

namespace Engine.Choices;

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
