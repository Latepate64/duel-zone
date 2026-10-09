using Interfaces;

namespace Abilities;

public abstract class ResolvableAbility : Ability, IResolvableAbility
{
    public IOneShotEffect OneShotEffect { get; set; }

    protected ResolvableAbility(IOneShotEffect effect) : base()
    {
        OneShotEffect = effect;
    }

    protected ResolvableAbility(ResolvableAbility ability) : base(ability)
    {
        OneShotEffect = ability.OneShotEffect.Copy();
    }

    /// <summary>
    /// 608.2c The controller of the ability follows its instructions in the
    /// order written.
    /// </summary>
    /// <param name="game"></param>
    public virtual void Resolve(IGame game)
    {
        OneShotEffect.Ability = this;
        OneShotEffect.Apply(game);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not ResolvableAbility ability) return false;
        if (!OneShotEffect.Equals(ability.OneShotEffect)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), OneShotEffect);
    }
}
