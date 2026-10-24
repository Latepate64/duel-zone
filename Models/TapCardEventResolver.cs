using Interfaces;

namespace Models;

public class TapCardEventResolver : EventResolver<TapCardEvent>
{
    public override IEnumerable<OneShotEffect> Resolve(
        IGameState state, IPlayerV2 applier, TapCardEvent gameEvent)
    {
        gameEvent.Card.Tapped = true;
        return [];
    }
}
