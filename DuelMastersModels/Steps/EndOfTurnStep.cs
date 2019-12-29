using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 511.1. The ability to trigger at every "turn's end" triggers. The induced effect is a turn We declare solutions to be resolved from the layer and process them in order.
    /// </summary>
    internal class EndOfTurnStep : Step
    {
        internal EndOfTurnStep(Player player) : base(player)
        {
        }

        internal override PlayerAction PlayerActionRequired(Duel duel)
        {
            duel.EndContinuousEffects(typeof(Effects.Periods.UntilTheEndOfTheTurn));
            return null;
        }
    }
}
