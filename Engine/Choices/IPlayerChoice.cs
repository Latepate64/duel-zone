using System.Collections.Generic;

namespace Engine.Choices;

public interface IPlayerChoice
{
    IPlayer Choice { get; set; }
    IEnumerable<IPlayer> Options { get; }
}