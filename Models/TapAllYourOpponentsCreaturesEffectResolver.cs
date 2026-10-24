using Interfaces;

namespace Models;

public class TapAllYourOpponentsCreaturesEffectResolver
    : EventResolver<TapAllYourOpponentsCreaturesEffect>
{
    public override IEnumerable<IGameEvent> Resolve(
        IGameState state, IPlayerV2 applier, TapAllYourOpponentsCreaturesEffect effect)
    {
        return state.BattleZone.GetCreaturesControlledByPlayer(
            applier, effect.CardFilter).Where(x => !x.Tapped).Select(x => new TapCardEvent(x));
    }
}
