using Interfaces;

namespace OneShotEffects;

/// <summary>
/// 610.1. A one-shot effect does something just once and doesn’t have a duration.
/// Examples include moving an object from one zone to another.
/// </summary>
public abstract class OneShotEffect : IOneShotEffect
{
    public IAbility Ability { get; set; }
    public IPlayer Controller => Ability.Controller;
    public ICard Source => Ability.Source;

    public IPlayerV2 Applier => throw new NotImplementedException();

    protected OneShotEffect() { }

    protected OneShotEffect(IOneShotEffect effect)
    {
        Ability = effect.Ability?.Copy();
    }

    /// <summary>
    /// Applies the effect.
    /// </summary>
    /// <param name="game"></param>
    /// 
    /// <returns>Any object that represents usable information of whatever happened during the effect (such as did the
    /// player take an action or what cards were affected). This information may be applied for reflexive triggered
    /// abilities (see rule 603.12.). Returns null if no information of what happened is of use.</returns>
    public abstract void Apply(IGame game);

    public abstract IOneShotEffect Copy();

    protected IPlayer GetOpponent(IGame game)
    {
        return game.GetOpponent(Controller);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not OneShotEffect effect) return false;
        if (Ability == null && effect.Ability != null) return false;
        if (Ability != null && !Ability.Equals(effect.Ability)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Ability);
    }
}
