using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public abstract class AbilityAddingEffect : ContinuousEffect, IAbilityAddingEffect
{
    public List<IAbility> Abilities { get; }

    protected AbilityAddingEffect(AbilityAddingEffect effect) : base(effect)
    {
        Abilities = [.. effect.Abilities.Select(x => x.Copy())];
    }

    protected AbilityAddingEffect(params IAbility[] abilities) : base()
    {
        Abilities = [.. abilities];
    }

    public void AddAbility(IGame game)
    {
        foreach (var card in GetAffectedCards(game))
        {
            Abilities.ForEach(x => card.AddGrantedAbility(x.Copy()));
        }
    }

    protected string AbilitiesAsText => string.Join(", ", Abilities.Select(x => x.ToString()));

    protected abstract IEnumerable<Card> GetAffectedCards(IGame game);
}
