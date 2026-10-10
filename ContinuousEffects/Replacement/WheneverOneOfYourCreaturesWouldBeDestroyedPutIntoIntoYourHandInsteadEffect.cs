using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Replacement;

/// <summary>
/// Whenever one of your creatures would be destroyed, put it into your hand
/// instead.
/// </summary>
public sealed class WheneverOneOfYourCreaturesWouldBeDestroyedPutIntoIntoYourHandInsteadEffect :
    WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect
{
    private readonly ICardFilter filter;

    public WheneverOneOfYourCreaturesWouldBeDestroyedPutIntoIntoYourHandInsteadEffect(
        ICardFilter filter)
    {
        this.filter = filter;
    }

    public WheneverOneOfYourCreaturesWouldBeDestroyedPutIntoIntoYourHandInsteadEffect(
        WheneverOneOfYourCreaturesWouldBeDestroyedPutIntoIntoYourHandInsteadEffect effect)
        : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new WheneverOneOfYourCreaturesWouldBeDestroyedPutIntoIntoYourHandInsteadEffect(
            this);
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return card != null && card.Owner == Controller && filter.Match(card);
    }
}
