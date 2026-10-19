using Interfaces;

namespace TriggeredAbilities;

public abstract class TriggeredAbility : ITriggeredAbility
{
    public ICard Source { get; set; }
    public IPlayer Controller { get; set; }
    private readonly IOneShotEffect oneShotEffect;

    protected TriggeredAbility(IOneShotEffect oneShotEffect)
    {
        this.oneShotEffect = oneShotEffect;
    }

    protected TriggeredAbility(TriggeredAbility ability)
    {
        oneShotEffect = ability.oneShotEffect.Copy();
    }

    public virtual ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        return Copy() as ITriggeredAbility;
    }

    public abstract bool CanTrigger(IGameEvent gameEvent, IGame game);

    public virtual bool CheckInterveningIfClause(IGame game)
    {
        return true;
    }

    public virtual void Resolve(IGame game)
    {
        // 608.2a
        // If a triggered ability has an intervening “if” clause,
        // it checks whether the clause’s condition is true.
        // If it isn’t, the ability does nothing.
        // Otherwise, it continues to resolve. See rule 603.4.
        if (CheckInterveningIfClause(game))
        {
            oneShotEffect.Ability = this;
            oneShotEffect.Apply(game);
        }
    }

    protected string GetEffectText()
    {
        return oneShotEffect.ToString();
    }

    public abstract IAbility Copy();

    public override bool Equals(object? obj)
    {
        if (obj is not TriggeredAbility ability) return false;
        if (Source == null && ability.Source != null) return false;
        if (Source != null && !Source.Equals(ability.Source)) return false;
        if (Controller == null && ability.Controller != null) return false;
        if (Controller != null && !Controller.Equals(ability.Controller)) return false;
        if (!oneShotEffect.Equals(ability.oneShotEffect)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Source, Controller, oneShotEffect);
    }
}
