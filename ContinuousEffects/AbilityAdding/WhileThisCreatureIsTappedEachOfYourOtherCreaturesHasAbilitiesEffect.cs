using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// While this creature is tapped, each of your other creatures has abilities.
/// </summary>
public sealed class WhileThisCreatureIsTappedEachOfYourOtherCreaturesHasAbilitiesEffect
    : ContinuousEffect, IAbilityAddingEffect
{
    private readonly IAbility[] abilities;
    private readonly ICardFilter filter;

    public WhileThisCreatureIsTappedEachOfYourOtherCreaturesHasAbilitiesEffect(
        ICardFilter filter, params Ability[] abilities)
    {
        this.filter = filter;
        this.abilities = abilities;
    }

    public WhileThisCreatureIsTappedEachOfYourOtherCreaturesHasAbilitiesEffect(
        WhileThisCreatureIsTappedEachOfYourOtherCreaturesHasAbilitiesEffect effect)
        : base(effect)
    {
        filter = effect.filter.Copy();
        abilities = [..effect.abilities.Select(x => x.Copy())];
    }

    public void AddAbility(IGame game)
    {
        var creature = (ICreature)Source!;
        if (creature.Tapped)
        {
            var creatures = game.BattleZone.GetOtherCreaturesControlledByPlayer(
                creature, filter);
            foreach (var c in creatures)
            {
                c.AddGrantedAbility(abilities);
            }
        }
    }

    public override IContinuousEffect Copy()
    {
        return new WhileThisCreatureIsTappedEachOfYourOtherCreaturesHasAbilitiesEffect(
            this);
    }
}
