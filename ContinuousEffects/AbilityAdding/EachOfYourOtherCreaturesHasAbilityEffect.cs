using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each of your other creatures in the battle zone has ability.
/// </summary>
public sealed class EachOfYourOtherCreaturesHasAbilityEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    private readonly ICardFilter filter;
    private readonly IAbility ability;

    public EachOfYourOtherCreaturesHasAbilityEffect(
        ICardFilter filter, IAbility ability) : base()
    {
        this.filter = filter;
        this.ability = ability;
    }

    public EachOfYourOtherCreaturesHasAbilityEffect(
        EachOfYourOtherCreaturesHasAbilityEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        ability = effect.ability.Copy();
    }

    public void AddAbility(IGame game)
    {
        var creatures = game.BattleZone.GetOtherCreaturesControlledByPlayer(
            (ICreature)Source!, filter);
        foreach (var creature in creatures)
        {
            game.AddAbility(creature, ability);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourOtherCreaturesHasAbilityEffect(this);
    }
}
