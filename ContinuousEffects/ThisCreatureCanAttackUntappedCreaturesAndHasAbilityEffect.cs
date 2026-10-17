using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect : ContinuousEffect,
    ICanAttackUntappedCreaturesEffect, IAbilityAddingEffect
{
    private readonly IStaticAbilityWithIntegerFactory abilityFactory;
    private readonly int power;

    public ThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect(
        IStaticAbilityWithIntegerFactory abilityFactory, int power) : base()
    {
        this.abilityFactory = abilityFactory;
        this.power = power;
    }

    private ThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect(
        ThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect effect) : base(effect)
    {
        abilityFactory = effect.abilityFactory;
        power = effect.power;
    }

    public void AddAbility(IGame game)
    {
        Source.AddGrantedAbility(abilityFactory.Create(power));
    }

    public bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return IsSourceOfAbility(attacker);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect(this);
    }
}
