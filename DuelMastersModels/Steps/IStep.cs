using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public interface IStep
    {
        IPlayer ActivePlayer { get; }

        IChoice ProcessTurnBasedActions(IDuel duel);
        IChoice PlayerActionRequired(IDuel duel);
    }
}