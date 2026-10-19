using Interfaces;
using Interfaces.ContinuousEffects;

namespace TriggeredAbilities;

/// <summary>
/// Whenever this creature is attacked, it gets ability.
public sealed class ScalpelSpiderAbility : LinkedTriggeredAbility
{
    private readonly IAbility ability;
    private readonly IAbilityAddingContinuousEffectFactory factory;
    private readonly IDuration duration;

    public ScalpelSpiderAbility(
        IAbility ability,
        IAbilityAddingContinuousEffectFactory factory,
        IDuration duration) : base()
    {
        this.ability = ability;
        this.factory = factory;
        this.duration = duration;
    }

    public ScalpelSpiderAbility(ScalpelSpiderAbility ability) : base(ability)
    {
        this.ability = ability.ability.Copy();
        factory = ability.factory;
        duration = ability.duration.Copy();
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new ScalpelSpiderAbility(this);
    }

    public override void Resolve(IGame game)
    {
        game.AddContinuousEffects(
            this,
            duration,
            factory.Create(ability, (ICreature)Source));
    }

    public override ITriggeredAbility Trigger(
        Guid source, Guid owner, IGameEvent gameEvent)
    {
        return new ScalpelSpiderAbility(this);
    }
}
