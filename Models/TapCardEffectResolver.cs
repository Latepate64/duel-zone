using Interfaces;

namespace Models;

public class TapCardEffectResolver : OneShotEffectResolver<TapCardEffect>
{
    public override IEnumerable<OneShotEffect> Resolve(
        IGameState state, IPlayerV2 applier, TapCardEffect effect)
    {
        effect.Card.Tapped = true;
        return [];
    }
}