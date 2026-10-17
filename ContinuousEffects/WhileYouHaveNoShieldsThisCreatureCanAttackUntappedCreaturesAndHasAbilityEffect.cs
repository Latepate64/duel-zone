using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class WhileYouHaveNoShieldsThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect
    : ContinuousEffect, ICanAttackUntappedCreaturesEffect, IAbilityAddingEffect
{
    private readonly int power;
    private readonly IStaticAbilityWithIntegerFactory abilityFactory;

    public WhileYouHaveNoShieldsThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect(
        int power,
        IStaticAbilityWithIntegerFactory abilityFactory) : base()
    {
        this.power = power;
        this.abilityFactory = abilityFactory;
    }

    private WhileYouHaveNoShieldsThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect(
        WhileYouHaveNoShieldsThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect effect)
        : base(effect)
    {
        power = effect.power;
        abilityFactory = effect.abilityFactory;
    }

    public void AddAbility(IGame game)
    {
        if (YouHaveNoShields(game))
        {
            Source.AddGrantedAbility(abilityFactory.Create(power));
        }
    }

    public bool CanAttackUntappedCreature(
        ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return YouHaveNoShields(game) && IsSourceOfAbility(attacker);
    }

    public override IContinuousEffect Copy()
    {
        return new WhileYouHaveNoShieldsThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect(
            this);
    }

    private bool YouHaveNoShields(IGame game)
    {
        return !Ability.Controller.ShieldZone.HasCards;
    }
}