using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Abilities
{
    public class PlayerActionWithEndInformation
    {
        public PlayerActionWithEndInformation(IPlayerAction playerAction, bool resolutionOver)
        {
            PlayerAction = playerAction;
            ResolutionOver = resolutionOver;
        }

        internal IPlayerAction PlayerAction { get; private set; }
        internal bool ResolutionOver { get; private set; }
    }
}
