using Interfaces.ContinuousEffects;

namespace Interfaces;

/// <summary>
/// 604.1.
/// Static abilities do something all the time rather than being activated or
/// triggered. They are written as statements, and they’re simply true.
/// </summary>
public interface IStaticAbility : IAbility
{
    /// <summary>
    /// 604.2.
    /// Static abilities create continuous effects, some of which are prevention
    /// effects or replacement effects.
    /// </summary>
    IEnumerable<IContinuousEffect> ContinuousEffects { get; }
}
