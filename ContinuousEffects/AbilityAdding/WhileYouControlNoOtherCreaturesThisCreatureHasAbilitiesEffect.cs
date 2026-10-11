using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// While you have no other creatures in the battle zone, this creature has
/// abilities.
/// </summary>
public sealed class WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect
    : ContinuousEffect, IAbilityAddingEffect
{
    private readonly IAbility[] abilities;
    private readonly ICardFilter filter;

    public WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect(
        ICardFilter filter, params Ability[] abilities)
    {
        this.filter = filter;
        this.abilities = abilities;
    }

    public WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect(
        WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect effect)
        : base(effect)
    {
        filter = effect.filter.Copy();
        abilities = [..effect.abilities.Select(x => x.Copy())];
    }

    public void AddAbility(IGame game)
    {
        var creature = (ICreature)Source!;
        if (!game.BattleZone.HasOtherCreaturesControllerByPlayer(
            creature, filter))
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
