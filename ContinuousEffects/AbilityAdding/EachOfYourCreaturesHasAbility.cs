using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each of your creatures in the battle zone has ability.
/// </summary>
public class EachOfYourCreaturesHasAbility : AbilityAddingEffect
{
    private readonly ICardFilter filter;

    public EachOfYourCreaturesHasAbility(
        IAbility ability, ICardFilter filter) : base(ability)
    {
        this.filter = filter;
    }

    public EachOfYourCreaturesHasAbility(
        EachOfYourCreaturesHasAbility effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourCreaturesHasAbility(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreaturesControllerByPlayer(Applier, filter);
    }
}
