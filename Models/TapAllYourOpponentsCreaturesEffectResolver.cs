using Interfaces;

namespace Models;

public class TapAllYourOpponentsCreaturesEffectResolver
    : EventResolver<TapAllYourOpponentsCreaturesEffect, IGameEvent>
{
    public override IEnumerable<IGameEvent> Resolve(
        IGameState state, IPlayer applier, TapAllYourOpponentsCreaturesEffect effect)
    {
        return state.BattleZone.GetCreaturesControlledByPlayer(
            applier, effect.CardFilter).Where(x => !x.Tapped).Select(x => new TapCardEvent(x));
    }
}
