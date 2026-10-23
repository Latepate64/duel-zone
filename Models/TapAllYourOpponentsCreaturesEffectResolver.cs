using Interfaces;

namespace Models;

public class TapAllYourOpponentsCreaturesEffectResolver
    : EventResolver<TapAllYourOpponentsCreaturesEffect>
{
    public override IEnumerable<IGameEventV3> Resolve(
        IGameState state, IPlayerV2 applier, TapAllYourOpponentsCreaturesEffect effect)
    {
        return state.BattleZone.GetCreaturesControlledByPlayer(
            applier, effect.Item).Where(x => !x.Tapped).Select(x => new TapCardEvent(x));
    }
}
