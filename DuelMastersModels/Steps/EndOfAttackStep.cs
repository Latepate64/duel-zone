using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    internal class EndOfAttackStep : Step
    {
        internal EndOfAttackStep(Player activePlayer) : base(activePlayer)
        {
        }

        internal override PlayerAction PlayerActionRequired(Duel duel)
        {
            return null;
        }
    }
}
