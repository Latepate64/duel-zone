using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    public interface IContinuousEffect
    {
        Period Period { get; }
    }
}