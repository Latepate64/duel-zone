using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class EachOfYourOtherCreaturesHasAbilityEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    private readonly ICardFilter filter;
    private readonly IAbility ability;
    private readonly ICondition? condition;

    public EachOfYourOtherCreaturesHasAbilityEffect(
        ICardFilter filter, IAbility ability, ICondition? condition = null) : base()
    {
        this.filter = filter;
        this.ability = ability;
        this.condition = condition;
    }

    public EachOfYourOtherCreaturesHasAbilityEffect(
        EachOfYourOtherCreaturesHasAbilityEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        ability = effect.ability.Copy();
        condition = effect.condition?.Copy();
    }

    public void AddAbility(IGame game)
    {
        var source = (ICreature)Source!;
        if (condition == null || condition.IsMet(source))
        {
            var creatures = game.BattleZone.GetOtherCreaturesControlledByPlayer(source, filter);
            foreach (var creature in creatures)
            {
                creature.AddGrantedAbility(ability);
            }
        }
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourOtherCreaturesHasAbilityEffect(this);
    }
}
