using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Abilities
{
    internal class PlayerActionWithEndInformation
    {
        internal PlayerActionWithEndInformation(IPlayerAction playerAction, bool resolutionOver)
        {
            PlayerAction = playerAction;
            ResolutionOver = resolutionOver;
        }

        internal IPlayerAction PlayerAction { get; private set; }
        internal bool ResolutionOver { get; private set; }
    }
}
