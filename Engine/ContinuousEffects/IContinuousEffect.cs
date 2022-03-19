using System;

namespace Engine.ContinuousEffects
{
    public interface IContinuousEffect
    {
        Guid SourceAbility { get; }
        CardFilter Filter { get; set; }

        bool ConditionsApply(Game game);
    }
}