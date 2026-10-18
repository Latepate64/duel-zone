using Interfaces;
using Interfaces.ContinuousEffects;

namespace Abilities.Static;

public class StaticAbility : IStaticAbility
{
    private readonly List<IContinuousEffect> _continuousEffects = [];

    public IEnumerable<IContinuousEffect> ContinuousEffects => _continuousEffects;

    public ZoneType FunctionZone { get; set; } = ZoneType.BattleZone;
    public ICard Source { get; set; }
    public IPlayer Controller { get; set; }

    protected StaticAbility() : base()
    {
    }

    public StaticAbility(IContinuousEffect continuousEffect)
    {
        _continuousEffects.Add(continuousEffect);
    }

    protected StaticAbility(StaticAbility ability)
    {
        _continuousEffects = [.. ability._continuousEffects.Select(x => x.Copy())];
        FunctionZone = ability.FunctionZone;
    }

    public virtual IAbility Copy()
    {
        return new StaticAbility(this);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not StaticAbility ability) return false;
        if (Source == null && ability.Source != null) return false;
        if (Source != null && !Source.Equals(ability.Source)) return false;
        if (Controller == null && ability.Controller != null) return false;
        if (Controller != null && !Controller.Equals(ability.Controller)) return false;
        if (!_continuousEffects.SequenceEqual(ability._continuousEffects)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Source);
        hash.Add(Controller);
        foreach (var effect in _continuousEffects)
        {
            hash.Add(effect);
        }
        return hash.ToHashCode();
    }
}
