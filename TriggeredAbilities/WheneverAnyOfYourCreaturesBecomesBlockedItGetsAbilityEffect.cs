using Interfaces;
using Interfaces.ContinuousEffects;

namespace TriggeredAbilities;

public sealed class WheneverAnyOfYourCreaturesBecomesBlockedItGetsAbilityEffect
    : LinkedTriggeredAbility
{
    private readonly ICreature? creature;
    private readonly IAbilityAddingContinuousEffectFactory factory;
    private readonly IAbility ability;
    private readonly IDuration duration;

    public WheneverAnyOfYourCreaturesBecomesBlockedItGetsAbilityEffect(
        IAbilityAddingContinuousEffectFactory factory,
        IAbility ability,
        IDuration duration)
    {
        this.factory = factory;
        this.ability = ability;
        this.duration = duration;
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
        duration = ability.duration.Copy();
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
                duration,
                factory.Create(ability, creature));
        }
        
    }

    public override ITriggeredAbility Trigger(
        Guid source, Guid owner, IGameEvent gameEvent)
    {
        throw new NotImplementedException();
    }
}
