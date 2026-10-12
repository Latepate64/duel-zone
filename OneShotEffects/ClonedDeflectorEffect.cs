using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your opponent's creatures in the battle zone. Then, for each
/// card name in each graveyard, you may choose another of your opponent's
/// creatures in the battle zone. Tap all those creatures.
/// </summary>
public sealed class ClonedDeflectorEffect : ClonedEffect
{
    private readonly ICardFilter filter;

    public ClonedDeflectorEffect(string name, ICardFilter filter) : base(name)
    {
        this.filter = filter;
    }

    public ClonedDeflectorEffect(ClonedDeflectorEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var creatures = player.ChooseCards(
            game.BattleZone.GetOpponentsChoosableCreatures(
                Applier, filter, game),
            1, GetAmount(game), ToString());
        player.Tap(game, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ClonedDeflectorEffect(this);
    }
}
