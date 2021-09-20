using DuelMastersModels.Choices;

namespace DuelMastersModels.Effects.OneShotEffects
{
    /// <summary>
    /// 610.1. A one-shot effect does something just once and doesn’t have a duration.
    /// </summary>
    public abstract class OneShotEffect : Effect
    {
        internal abstract Choice Apply(Duel duel, IPlayer player, Choice choice);
    }
}
