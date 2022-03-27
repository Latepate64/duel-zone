using System;

namespace Engine.ContinuousEffects
{
    public interface IContinuousEffect : ITimestampable, IDisposable, IDurationable
    {
        Guid SourceAbility { get; set; }
        ICardFilter Filter { get; set; }

        bool ConditionsApply(IGame game);
        IContinuousEffect Copy();
        void SetupConditionFilters(Guid id);
    }
}