using Interfaces;

namespace Models;

public class TapAllYourOpponentsCreaturesEffectResolver
    : OneShotEffectResolver<TapAllYourOpponentsCreaturesEffect>
{
    private readonly ICardFilter cardFilter;

    public TapAllYourOpponentsCreaturesEffectResolver(ICardFilter cardFilter)
    {
        this.cardFilter = cardFilter;
    }

    public override IEnumerable<OneShotEffect> Resolve(
        IGameState state, IPlayerV2 applier, TapAllYourOpponentsCreaturesEffect effect)
    {
        return state.BattleZone.GetCreaturesControlledByPlayer(applier, cardFilter).Where(
            x => !x.Tapped).Select(x => new TapCardEffect(x));
    }
}
