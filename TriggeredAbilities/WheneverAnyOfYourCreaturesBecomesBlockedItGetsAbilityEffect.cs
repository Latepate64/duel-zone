using Interfaces;

namespace TriggeredAbilities;

/// <summary>
/// Whenever any of your creatures becomes blocked, it gets ability.
/// </summary>
public sealed class WheneverAnyOfYourCreaturesBecomesBlockedItGetsAbilityEffect
    : LinkedTriggeredAbility
{
    private readonly ICreature? creature;
    private readonly IAbilityAddingContinuousEffectFactory factory;
    private readonly IAbility ability;

    public WheneverAnyOfYourCreaturesBecomesBlockedItGetsAbilityEffect(
        IAbilityAddingContinuousEffectFactory factory,
        IAbility ability)
    {
        this.factory = factory;
        this.ability = ability;
    }

    public WheneverAnyOfYourCreaturesBecomesBlockedItGetsAbilityEffect(
        WheneverAnyOfYourCreaturesBecomesBlockedItGetsAbilityEffect ability)
            : base(ability)
    {
        creature = ability.creature != null
            ? (ICreature)ability.creature.Copy()
            : null;
        factory = ability.factory;
        this.ability = ability.ability;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new WheneverAnyOfYourCreaturesBecomesBlockedItGetsAbilityEffect(
            this);
    }

    public override void Resolve(IGame game)
    {
        if (creature != null)
        {
            game.AddContinuousEffects(
                this,
                factory.Create(ability, creature));
        }
        
    }

    public override ITriggeredAbility Trigger(
        Guid source, Guid owner, IGameEvent gameEvent)
    {
        throw new NotImplementedException();
    }
}
