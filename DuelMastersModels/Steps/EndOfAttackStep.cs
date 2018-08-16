using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    public class EndOfAttackStep : Step
    {
        public EndOfAttackStep(Player activePlayer) : base(activePlayer, "End of attack")
        {
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            return null;
        }
    }
}
