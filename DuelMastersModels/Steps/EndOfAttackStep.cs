using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    internal class EndOfAttackStep : Step
    {
        internal EndOfAttackStep(IPlayer activePlayer) : base(activePlayer)
        {
        }

        internal override PlayerAction PlayerActionRequired(IDuel duel)
        {
            return null;
        }
    }
}
