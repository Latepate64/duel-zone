using DuelMastersModels.PlayerActionResponses;
using DuelMastersModels.PlayerActions;
using System;

namespace DuelMastersModels
{
    /// <summary>
    /// Interface for Duel Masters duels.
    /// </summary>
    public interface IDuel
    {
        /// <summary>
        /// Event which is raised whenever an important event during the duel occurs.
        /// </summary>
        event EventHandler<DuelEventArgs> DuelEventOccurred;

        /// <summary>
        /// A player that participates in duel against player 2.
        /// </summary>
        Player Player1 { get; }

        /// <summary>
        /// A player that participates in duel against player 1.
        /// </summary>
        Player Player2 { get; }

        /// <summary>
        /// Player who won the duel.
        /// </summary>
        IPlayer Winner { get; }

        /// <summary>
        /// Determines the state of the duel.
        /// </summary>
        DuelState State { get; }

        /// <summary>
        /// The number of shields each player has at the start of a duel. 
        /// </summary>
        int InitialNumberOfShields { get; }

        /// <summary>
        /// The number of cards each player draw at the start of a duel.
        /// </summary>
        int InitialNumberOfHandCards { get; }

        /// <summary>
        /// Determines which player goes first in the duel.
        /// </summary>
        StartingPlayer StartingPlayer { get; }

        /// <summary>
        /// Starts the duel.
        /// </summary>
        /// <returns></returns>
        IPlayerAction Start();

        /// <summary>
        /// Tries to progress in the duel based on the latest player action, and returns new player action for a player to take.
        /// </summary>
        IPlayerAction Progress<T>(PlayerActionResponse response) where T : class, Cards.ICard;
    }
}