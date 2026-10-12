using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each creature in the battle zone has ability.
/// </summary>
public sealed class EachCreatureHasAbilityEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    private readonly ICardFilter filter;
    private readonly IAbility ability;

    public EachCreatureHasAbilityEffect(
        ICardFilter filter, IAbility ability) : base()
    {
        this.filter = filter;
        this.ability = ability;
    }

    public EachCreatureHasAbilityEffect(
        EachCreatureHasAbilityEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        ability = effect.ability.Copy();
    }

    public void AddAbility(IGame game)
    {
        foreach (var creature in game.BattleZone.GetCreatures(filter))
        {
            game.AddAbility(creature, ability);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new EachCreatureHasAbilityEffect(this);
    }
}
