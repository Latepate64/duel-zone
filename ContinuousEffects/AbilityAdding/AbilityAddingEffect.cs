using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public abstract class AbilityAddingEffect : ContinuousEffect, IAbilityAddingEffect
{
    public List<IAbility> Abilities { get; }

    protected AbilityAddingEffect(params IAbility[] abilities) : base()
    {
        Abilities = [.. abilities];
    }

    protected AbilityAddingEffect(AbilityAddingEffect effect) : base(effect)
    {
        Abilities = [.. effect.Abilities.Select(x => x.Copy())];
    }

    public void AddAbility(IGame game)
    {
        foreach (var card in GetAffectedCards(game))
        {
            Abilities.ForEach(x => card.AddGrantedAbility(x.Copy()));
        }
    }

    protected abstract IEnumerable<ICard> GetAffectedCards(IGame game);
}
