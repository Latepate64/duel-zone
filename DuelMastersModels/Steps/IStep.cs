using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    public interface IStep
    {
        IPlayer ActivePlayer { get; }

        IPlayerAction ProcessTurnBasedActions(IDuel duel);
        IPlayerAction PlayerActionRequired(IDuel duel);
    }
}