using DuelMastersModels.Choices;
using DuelMastersModels.Steps;

namespace DuelMastersModels
{
    public interface ITurn
    {
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        IPlayer ActivePlayer { get; }

        /// <summary>
        /// The opponent of the active player.
        /// </summary>
        IPlayer NonActivePlayer { get; }

        /// <summary>
        /// The step that is currently being processed.
        /// </summary>
        IStep CurrentStep { get; }

        /// <summary>
        /// Changes step to the next one and starts it, or starts the first step if no steps exist.
        /// </summary>
        /// <returns></returns>
        IChoice ChangeStep(IDuel duel);
    }
}