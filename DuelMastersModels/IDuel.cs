using DuelMastersModels.Abilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
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
        IPlayer Player1 { get; }

        /// <summary>
        /// A player that participates in duel against player 1.
        /// </summary>
        IPlayer Player2 { get; }

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

        Turn CurrentTurn { get; }

        IEnumerable<IBattleZoneCreature> CreaturesInTheBattleZone { get; }

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
        PlayerAction DrawCard(IPlayer player);
        PlayerAction PutFromShieldZoneToHand(IPlayer player, IShieldZoneCard card, bool canUseShieldTrigger);
        PlayerAction PutFromShieldZoneToHand(IPlayer player, IEnumerable<IShieldZoneCard> cards, bool canUseShieldTrigger);
        PlayerAction PutTheTopCardOfYourDeckIntoYourManaZone(IPlayer player);
        PlayerAction ReturnFromBattleZoneToHand(IBattleZoneCreature creature);
        PlayerAction PutFromBattleZoneIntoOwnersManazone(IBattleZoneCreature creature);
        PlayerAction PutFromManaZoneIntoTheBattleZone(IManaZoneCreature creature);
        PlayerAction AddTheTopCardOfYourDeckToYourShieldsFaceDown(IPlayer player);
        void End(IPlayer winner);
        void EndDuelInDraw();
        void PutFromHandIntoManaZone(IPlayer player, IHandCard card);
        void Battle(IBattleZoneCreature attackingCreature, IBattleZoneCreature defendingCreature, IPlayer attackingPlayer, IPlayer defendingPlayer);
        void UseCard(IPlayer player, ICard card);
        void AddFromYourHandToYourShieldsFaceDown(IHandCard card);
        void EndContinuousEffects<T>();
        void AddContinuousEffect(ContinuousEffect continuousEffect);
        IEnumerable<BattleZoneCreature> GetCreaturesThatCanBlock(IBattleZoneCreature attackingCreature);
        IEnumerable<BattleZoneCreature> GetCreaturesThatCanAttack(IPlayer player);
        IEnumerable<IBattleZoneCreature> GetCreaturesThatCanBeAttacked(IPlayer player);
        bool CanAttackOpponent(IBattleZoneCreature creature);
        bool AttacksIfAble(IBattleZoneCreature creature);
        IEnumerable<ICard> GetAllCards();
        IPlayer GetOwner(ICard card);
        IPlayer GetOpponent(IPlayer player);
        void SetPendingAbilityToBeResolved(NonStaticAbility ability);
        void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(IBattleZoneCreature creature);
        void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(IBattleZoneCreature excludedCreature);
    }
}