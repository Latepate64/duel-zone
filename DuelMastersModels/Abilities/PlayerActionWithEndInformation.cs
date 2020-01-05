using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Abilities
{
    internal class PlayerActionWithEndInformation
    {
        internal PlayerActionWithEndInformation(PlayerAction playerAction, bool resolutionOver)
        {
            PlayerAction = playerAction;
            ResolutionOver = resolutionOver;
        }

        internal PlayerAction PlayerAction { get; private set; }
        internal bool ResolutionOver { get; private set; }
    }
}
