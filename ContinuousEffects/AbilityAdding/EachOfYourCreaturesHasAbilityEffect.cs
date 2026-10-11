using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each of your creatures in the battle zone has ability.
/// </summary>
public class EachOfYourCreaturesHasAbilityEffect : AbilityAddingEffect
{
    private readonly ICardFilter filter;

    public EachOfYourCreaturesHasAbilityEffect(
        IAbility ability, ICardFilter filter) : base(ability)
    {
        this.filter = filter;
    }

    public EachOfYourCreaturesHasAbilityEffect(
        EachOfYourCreaturesHasAbilityEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourCreaturesHasAbilityEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }
}
