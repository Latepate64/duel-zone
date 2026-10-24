using Interfaces;

namespace Models;

public class TapCardEvent(ICard card) : IGameEventV3
{
    public ICard Card { get; set; } = card;
}
