using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// While you have no shields, this creature can attack untapped creatures and
/// has "Power attacker +x."
/// </summary>
public sealed class CratersaurEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect,
    IAbilityAddingEffect
{
    private readonly int power;
    private readonly IStaticAbilityWithEffectFactory abilityFactory;
    private readonly IContinuousEffectWithIntegerFactory effectFactory;

    public CratersaurEffect(
        int power,
        IStaticAbilityWithEffectFactory abilityFactory,
        IContinuousEffectWithIntegerFactory effectFactory) : base()
    {
        this.power = power;
        this.abilityFactory = abilityFactory;
        this.effectFactory = effectFactory;
    }

    private CratersaurEffect(CratersaurEffect effect) : base(effect)
    {
        power = effect.power;
        abilityFactory = effect.abilityFactory;
        effectFactory = effect.effectFactory;
    }

    public void AddAbility(IGame game)
    {
        if (YouHaveNoShields(game))
        {
            Source.AddGrantedAbility(
                abilityFactory.Create(
                    effectFactory.Create(power)));
        }
    }

    public bool CanAttackUntappedCreature(
        ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return YouHaveNoShields(game) && IsSourceOfAbility(attacker);
    }

    public override IContinuousEffect Copy()
    {
        return new CratersaurEffect(this);
    }

    private bool YouHaveNoShields(IGame game)
    {
        return !Ability.Controller.ShieldZone.HasCards;
    }
}