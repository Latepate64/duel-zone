using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThatCreatureHasAbilityEffect : ContinuousEffect, IAbilityAddingEffect
{
    private readonly ICreature creature;
    private readonly IAbility ability;

    public ThatCreatureHasAbilityEffect(ICreature creature, IAbility ability)
    {
        this.creature = creature;
        this.ability = ability;
    }

    private ThatCreatureHasAbilityEffect(ThatCreatureHasAbilityEffect effect) : base(effect)
    {
        creature = (ICreature)effect.creature.Copy();
        ability = effect.ability.Copy();
    }


    public void AddAbility(IGame game)
    {
        game.AddAbility(creature, ability);
    }

    public override IContinuousEffect Copy()
    {
        return new ThatCreatureHasAbilityEffect(this);
    }
}
