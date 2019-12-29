using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Abilities
{
    internal class PlayerActionWithEndInformation
    {
        internal PlayerActionWithEndInformation(PlayerAction playerAction, bool end)
        {
            PlayerAction = playerAction;
            End = end;
        }

        internal PlayerAction PlayerAction { get; private set; }
        internal bool End { get; private set; }
    }
}
