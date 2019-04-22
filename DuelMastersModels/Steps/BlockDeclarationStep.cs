using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    public class BlockDeclarationStep : Step
    {
        public BlockDeclarationStep(Player activePlayer) : base(activePlayer)
        {
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            return null;
        }
    }
}
