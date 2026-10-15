using Interfaces;

namespace OneShotEffects;

/// <summary>
/// At the end of the turn, untap all your creatures in the battle zone.
/// </summary>
public sealed class WhiskingWhirlwindEffect : OneShotEffect
{
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;

    public WhiskingWhirlwindEffect(
        ICardFilter filter, SelectionRange selectionRange)
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
    }

    public WhiskingWhirlwindEffect(
        WhiskingWhirlwindEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
    }

    public override void Apply(IGame game)
    {
        var effect = new UntapAreaOfEffect(filter, selectionRange);
        throw new NotImplementedException();
        // game.AddDelayedTriggeredAbility(new AtTheEndOfTheTurnDelayedTriggeredAbility(
        //     Ability, game.CurrentTurn.Id, new WhiskingWhirlwindUntapEffect()));
    }

    public override IOneShotEffect Copy()
    {
        return new WhiskingWhirlwindEffect(this);
    }
}
