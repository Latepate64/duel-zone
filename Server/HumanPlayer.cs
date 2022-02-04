using Engine;
using Common.Choices;

namespace Server
{
    class HumanPlayer : Player
    {
        public HumanPlayer()
        {
        }

        public HumanPlayer(Player player) : base(player)
        {
        }

        public override YesNoDecision Choose(YesNoChoice yesNoChoice)
        {
            while (true);
            return null;
        }

        public override GuidDecision Choose(GuidSelection guidSelection)
        {
            while (true) ;
            return null;
        }
    }
}
