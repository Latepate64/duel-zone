using Interfaces;

namespace OneShotEffects;

public sealed class EachPlayersDrawsCardForEachCreatureTheyControlEffect
    : OneShotEffect
{
    private readonly ICardFilter filter;

    public EachPlayersDrawsCardForEachCreatureTheyControlEffect(
        ICardFilter filter)
    {
        this.filter = filter;
    }

    public EachPlayersDrawsCardForEachCreatureTheyControlEffect(
        EachPlayersDrawsCardForEachCreatureTheyControlEffect effect) : base(
            effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var players = new List<IPlayerV2>(); //TODO from state
        foreach (var player in players)
        {
            var count = game.BattleZone.GetNumberOfCreaturesControllerByPlayer(
                player, filter);
            throw new NotImplementedException("Draw cards");
        }
    }

    public override IOneShotEffect Copy()
    {
        return new EachPlayersDrawsCardForEachCreatureTheyControlEffect(this);
    }
}
