using Interfaces;

namespace Models;

public class TapCardEvent : IGameEventV3
{
    public ICard Card { get; set; }

    public TapCardEvent(ICard card)
    {
        Card = card;
    }
}
