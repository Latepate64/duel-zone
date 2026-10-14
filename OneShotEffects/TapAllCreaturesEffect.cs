using Interfaces;

namespace OneShotEffects;

public sealed class TapAllCreaturesEffect : OneShotEffect
{
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;

    public TapAllCreaturesEffect(
        ICardFilter filter, SelectionRange selectionRange) : base()
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
    }

    public TapAllCreaturesEffect(TapAllCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
    }

    public override IOneShotEffect Copy()
    {
        return new TapAllCreaturesEffect(this);
    }

    public override void Apply(IGame game)
    {
        Controller.Tap(
            game,
            [.. game.BattleZone.GetCreatures(Applier, filter, selectionRange)]);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not TapAllCreaturesEffect effect) return false;
        if (!filter.Equals(effect.filter)) return false;
        if (!selectionRange.Equals(effect.selectionRange)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), filter, selectionRange);
    }
}
