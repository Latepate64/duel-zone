using DuelMastersModels;
using DuelMastersModels.Choices;

namespace Server
{
    class HumanPlayer : Player
    {
        public override YesNoDecision Choose(YesNoChoice yesNoChoice)
        {
            throw new System.NotImplementedException();
        }

        public override GuidDecision Choose(GuidSelection guidSelection)
        {
            throw new System.NotImplementedException();
        }

        public override Player Copy()
        {
            throw new System.NotImplementedException();
        }
    }
}
