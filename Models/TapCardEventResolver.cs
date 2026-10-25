using Interfaces;

namespace Models;

public class TapCardEventResolver : EventResolver<TapCardEvent, IGameEvent>
{
    public override IEnumerable<OneShotEffect> Resolve(
        IGameState state, IPlayer applier, TapCardEvent gameEvent)
    {
        gameEvent.Card.Tapped = true;
        return [];
    }
}
