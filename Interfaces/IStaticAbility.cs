using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IStaticAbility : IAbility
{
    ZoneType FunctionZone { get; set; }
    IEnumerable<IContinuousEffect> ContinuousEffects { get; }
}
