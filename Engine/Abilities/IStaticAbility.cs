using Engine.ContinuousEffects;
using Interfaces;
using System.Collections.Generic;

namespace Engine.Abilities
{
    public interface IStaticAbility : IAbility
    {
        ZoneType FunctionZone { get; set; }
        IEnumerable<IContinuousEffect> ContinuousEffects { get; }
    }
}