using Engine.Durations;
using System;

namespace Engine.ContinuousEffects
{
    public interface IContinuousEffect : ITimestampable, IDisposable, IDurationable
    {
        Guid SourceAbility { get; set; }
        ICardFilter Filter { get; set; }

        bool ConditionsApply(Game game);
        IContinuousEffect Copy();
        void SetupConditionFilters(Guid id);
    }
}