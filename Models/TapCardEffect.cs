using Interfaces;

namespace Models;

public class TapCardEffect : OneShotEffect
{
    public ICard Card { get; set; }

    public TapCardEffect(ICard card)
    {
        Card = card;
    }
}
