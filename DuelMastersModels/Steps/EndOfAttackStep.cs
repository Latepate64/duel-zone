using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    internal class EndOfAttackStep : Step
    {
        internal EndOfAttackStep(IPlayer activePlayer) : base(activePlayer)
        {
        }

        public override IChoice PlayerActionRequired(IDuel duel)
        {
            return null;
        }
    }
}
