using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class EachCreatureHasAbilityEffect : ContinuousEffect, IAbilityAddingEffect
{
    private readonly ICardFilter filter;
    private readonly IAbility ability;

    internal EachCreatureHasAbilityEffect(
        ICardFilter filter, IAbility ability) : base()
    {
        this.filter = filter;
        this.ability = ability;
    }

    private EachCreatureHasAbilityEffect(
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

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not EachCreatureHasAbilityEffect effect) return false;
        if (!filter.Equals(effect.filter)) return false;
        if (!ability.Equals(effect.ability)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(filter, ability);
    }
}
