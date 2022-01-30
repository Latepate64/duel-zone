using DuelMastersModels;
using DuelMastersModels.Choices;
using System;

namespace Server
{
    class ComputerPlayer : Player
    {
        public override YesNoDecision Choose(YesNoChoice yesNoChoice)
        {
            throw new NotImplementedException();
        }

        public override GuidDecision Choose(GuidSelection guidSelection)
        {
            throw new NotImplementedException();
        }

        public override Player Copy()
        {
            throw new NotImplementedException();
        }
    }
}
