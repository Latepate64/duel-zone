using DuelMastersModels.Abilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Managers;
using DuelMastersModels.PlayerActions;
using System;
using System.Collections.Generic;

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
        IPlayer Player1 { get; set; }

        /// <summary>
        /// A player that participates in duel against player 1.
        /// </summary>
        IPlayer Player2 { get; set; }

        /// <summary>
        /// 103.1. At the start of a game, the players determine which one of them will choose who takes the first turn. In the first game of a match (including a single-game match), the players may use any mutually agreeable method (flipping a coin, rolling dice, etc.) to do so. In a match of several games, the loser of the previous game chooses who takes the first turn. If the previous game was a draw, the player who made the choice in that game makes the choice in this game. The player chosen to take the first turn is the starting player. The game’s default turn order begins with the starting player and proceeds clockwise.
        /// </summary>
        IPlayer StartingPlayer { get; set; }

        /// <summary>
        /// Player who won the duel.
        /// </summary>
        IPlayer Winner { get; }

        /// <summary>
        /// Determines the state of the duel.
        /// </summary>
        DuelState State { get; set; }

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
        StartingPlayerMethod StartingPlayerMethod { get; }

        IEnumerable<IBattleZoneCreature> CreaturesInTheBattleZone { get; }

        ITurnManager TurnManager { get; set; }

        IPlayerActionManager PlayerActionManager { get; set; }

        /// <summary>
        /// Starts the duel.
        /// </summary>
        /// <returns></returns>
        IPlayerAction Start();

        /// <summary>
        /// Tries to progress in the duel.
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        IPlayerAction Progress<T>() where T : class, ICard;

        /// <summary>
        /// Tries to progress in the duel.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="card"></param>
        /// <returns></returns>
        IPlayerAction Progress<T>(T card) where T : class, ICard;

        /// <summary>
        /// Tries to progress in the duel.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cards"></param>
        /// <returns></returns>
        IPlayerAction Progress<T>(IEnumerable<T> cards) where T : class, ICard;

        int GetPower(IBattleZoneCreature creature);
        IPlayerAction DrawCard(IPlayer player);
        IPlayerAction PutFromShieldZoneToHand(IPlayer player, IShieldZoneCard card, bool canUseShieldTrigger);
        IPlayerAction PutFromShieldZoneToHand(IPlayer player, IEnumerable<IShieldZoneCard> cards, bool canUseShieldTrigger);
        IPlayerAction PutTheTopCardOfYourDeckIntoYourManaZone(IPlayer player);
        IPlayerAction ReturnFromBattleZoneToHand(IBattleZoneCreature creature);
        IPlayerAction PutFromBattleZoneIntoOwnersManazone(IBattleZoneCreature creature);
        IPlayerAction PutFromManaZoneIntoTheBattleZone(IManaZoneCreature creature);
        IPlayerAction AddTheTopCardOfYourDeckToYourShieldsFaceDown(IPlayer player);
        void End(IPlayer winner);
        void EndDuelInDraw();
        void Battle(IBattleZoneCreature attackingCreature, IBattleZoneCreature defendingCreature);
        void UseCard(IPlayer player, ICard card);
        void AddFromYourHandToYourShieldsFaceDown(IHandCard card);
        void EndContinuousEffects<T>();
        void AddContinuousEffect(IContinuousEffect continuousEffect);
        IEnumerable<IBattleZoneCreature> GetCreaturesThatCanBlock(IBattleZoneCreature attackingCreature);
        IEnumerable<IBattleZoneCreature> GetCreaturesThatCanAttack(IPlayer player);
        IEnumerable<IBattleZoneCreature> GetCreaturesThatCanBeAttacked(IPlayer player);
        bool CanAttackOpponent(IBattleZoneCreature creature);
        bool AttacksIfAble(IBattleZoneCreature creature);
        IEnumerable<ICard> GetAllCards();
        void SetPendingAbilityToBeResolved(INonStaticAbility ability);
        void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(IBattleZoneCreature creature);
        void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(IBattleZoneCreature excludedCreature);
        IPlayerAction TryToPerformAutomatically(IPlayerAction playerAction);
        IPlayerAction Progress();
    }
}