using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// While you have at least one other creature in the battle zone, this creature
/// has ability.
/// </summary>
public sealed class WhileYouControlAtLeastOneOtherCreatureThisCreatureHasAbilityEffect
    : ContinuousEffect, IAbilityAddingEffect
{
    private readonly IAbility ability;
    private readonly ICardFilter filter;

    public WhileYouControlAtLeastOneOtherCreatureThisCreatureHasAbilityEffect(
        IAbility ability, ICardFilter filter)
    {
        this.ability = ability;
        this.filter = filter;
    }

    public WhileYouControlAtLeastOneOtherCreatureThisCreatureHasAbilityEffect(
        WhileYouControlAtLeastOneOtherCreatureThisCreatureHasAbilityEffect effect)
        : base(effect)
    {
        ability = effect.ability.Copy();
        filter = effect.filter.Copy();
    }

    public void AddAbility(IGame game)
    {
        var creature = (ICreature)Source!;
        if (game.BattleZone.HasOtherCreaturesControllerByPlayer(
            creature, filter))
        {
            creature.AddGrantedAbility(ability);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new WhileYouControlAtLeastOneOtherCreatureThisCreatureHasAbilityEffect(
            this);
    }
}
