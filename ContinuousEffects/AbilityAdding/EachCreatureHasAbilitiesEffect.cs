using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class EachCreatureHasAbilitiesEffect : ContinuousEffect, IAbilityAddingEffect
{
    private readonly ICardFilter filter;
    private readonly IAbility[] abilities;

    internal EachCreatureHasAbilitiesEffect(
        ICardFilter filter, params IAbility[] abilities) : base()
    {
        this.filter = filter;
        this.abilities = abilities;
    }

    private EachCreatureHasAbilitiesEffect(
        EachCreatureHasAbilitiesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        abilities = [.. effect.abilities.Select(x => x.Copy())];
    }

    public void AddAbility(IGame game)
    {
        foreach (var creature in game.BattleZone.GetCreatures(filter))
        {
            foreach (var ability in abilities)
            {
                game.AddAbility(creature, ability);
            }
        }
    }

    public override IContinuousEffect Copy()
    {
        return new EachCreatureHasAbilitiesEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not EachCreatureHasAbilitiesEffect effect) return false;
        if (!filter.Equals(effect.filter)) return false;
        if (!abilities.SequenceEqual(effect.abilities)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(filter);
        foreach (var ability in abilities)
        {
            hash.Add(ability);
        }
        return hash.ToHashCode();
    }
}
