using Interfaces;

namespace OneShotEffects;

public sealed class UntapAreaOfEffect : OneShotEffect
{
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;

    public UntapAreaOfEffect(
        ICardFilter filter, SelectionRange selectionRange) : base()
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
    }

    private UntapAreaOfEffect(UntapAreaOfEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreatures(
            Applier, filter, selectionRange);
        Controller.Untap(game, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new UntapAreaOfEffect(this);
    }
}
