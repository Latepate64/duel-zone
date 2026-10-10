using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each of your creatures in the battle zone has "double breaker."
/// </summary>
public sealed class EachOfYourCreaturesHasDoubleBreaker : AbilityAddingEffect
{
    private readonly ICardFilter filter;

    public EachOfYourCreaturesHasDoubleBreaker(ICardFilter filter) : base(
        new DoubleBreakerAbility())
    {
        this.filter = filter;
    }

    public EachOfYourCreaturesHasDoubleBreaker(
        EachOfYourCreaturesHasDoubleBreaker effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourCreaturesHasDoubleBreaker(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreaturesControllerByPlayer(Applier, filter);
    }
}
