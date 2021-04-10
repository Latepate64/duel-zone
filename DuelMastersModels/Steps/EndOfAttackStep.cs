using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    internal class EndOfAttackStep : Step
    {
        internal EndOfAttackStep(IPlayer activePlayer) : base(activePlayer)
        {
        }

        internal override IPlayerAction PlayerActionRequired(IDuel duel)
        {
            return null;
        }
    }
}
