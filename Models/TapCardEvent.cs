using Interfaces;

namespace Models;

public class TapCardEvent(ICard card) : IGameEvent
{
    public ICard Card { get; set; } = card;
}
