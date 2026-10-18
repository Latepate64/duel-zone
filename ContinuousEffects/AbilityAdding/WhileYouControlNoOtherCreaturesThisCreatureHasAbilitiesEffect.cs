using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect
    : ContinuousEffect, IAbilityAddingEffect
{
    private readonly IAbility[] abilities;
    private readonly ICardFilter filter;
    private readonly IConditionWithBattleZoneCreatureAndFilter condition;

    public WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect(
        ICardFilter filter,
        IConditionWithBattleZoneCreatureAndFilter condition,
        params IAbility[] abilities)
    {
        this.filter = filter;
        this.condition = condition;
        this.abilities = abilities;
    }

    public WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect(
        WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect effect)
        : base(effect)
    {
        filter = effect.filter.Copy();
        condition = effect.condition;
        abilities = [..effect.abilities.Select(x => x.Copy())];
    }

    public void AddAbility(IGame game)
    {
        var creature = (ICreature)Source!;
        if (condition.IsMet(game.BattleZone, creature, filter))
        {
            creature.AddGrantedAbility(abilities);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect(
            this);
    }
}
