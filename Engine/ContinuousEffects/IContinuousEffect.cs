using Engine.Durations;
using System;

namespace Engine.ContinuousEffects
{
    public interface IContinuousEffect : ITimestampable, IDisposable
    {
        Guid SourceAbility { get; set; }
        CardFilter Filter { get; set; }
        IDuration Duration { get; set; }

        bool ConditionsApply(Game game);
        IContinuousEffect Copy();
        void SetupConditionFilters(Guid id);
    }
}