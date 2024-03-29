﻿using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public interface IGame
    {
        IBattleZone BattleZone { get; }
        ITurn CurrentTurn { get; }
        /// <summary>
        /// 104.1. A game ends immediately when a player wins, when the game is a draw, or when the game is restarted.
        /// </summary>
        bool Ended { get; }

        Stack<ITurn> ExtraTurns { get; }
        IEnumerable<IPlayer> Players { get; }
        Queue<IGameEvent> PreGameEvents { get; }
        SpellStack SpellStack { get; }
        Queue<IGameState> States { get; }
        IList<ITurn> Turns { get; }
        public IContinuousEffects ContinuousEffects { get; }
        IPlayer ActivePlayer => CurrentTurn.ActivePlayer;

        void AddAbility(ICard card, IAbility ability);

        void AddContinuousEffects(IAbility source, params IContinuousEffect[] continuousEffects);
        void AddDelayedTriggeredAbility(DelayedTriggeredAbility ability);

        void AddPendingAbilities(params IResolvableAbility[] abilities);

        void AddReflexiveTriggeredAbility(IResolvableAbility ability);

        bool AffectedBySummoningSickness(ICard creature);
        void Battle(ICard attackingCreature, ICard defendingCreature);

        void Break(ICard creature, int breakAmount);

        bool CanAttackAtLeastOneCreature(ICard creature);
        bool CanAttackAtLeastSomething(ICard creature) => CanAttackAtLeastOneCreature(creature) || CanAttackPlayers(creature);

        bool CanAttackCreature(ICard attacker, ICard targetOfAttack);

        bool CanAttackPlayers(ICard creature);

        bool CanBeUsedRegardlessOfManaCost(ICard card);

        bool CheckStateBasedActions();

        void Destroy(IAbility ability, params ICard[] cards);

        IAbility GetAbility(Guid id);

        IEnumerable<ICard> GetAllCards();

        IAttackable GetAttackable(Guid id);

        ICard GetCard(Guid id);

        IEnumerable<ICard> GetChoosableCreaturesControlledByAnyone(IGame game, Guid id) => BattleZone.GetChoosableCreaturesControlledByAnyone(game, id);
        IEnumerable<ICard> GetCreaturesThatHaveAttackTargets();
        IPlayer GetOpponent(IPlayer player);
        Guid GetOpponent(Guid player);
        IPlayer GetOwner(ICard card);
        IPlayer GetPlayer(Guid id);
        IEnumerable<IAttackable> GetPossibleAttackTargets(ICard attacker);
        int GetTimestamp();
        IZone GetZone(ICard card);

        void Lose(params IPlayer[] players);
        IEnumerable<IGameEvent> Move(IAbility ability, ZoneType source, ZoneType destination, params ICard[] cards);
        IEnumerable<IGameEvent> MoveTapped(IAbility ability, ZoneType hand, ZoneType manaZone, params ICard[] cards);
        void MoveTopCard(ICard card, ZoneType destination, IAbility ability);
        void Play(IPlayer startingPlayer, IPlayer otherPlayer);
        IEnumerable<IGameEvent> ProcessEvents(params IGameEvent[] gameEvents);
        void PutFromShieldZoneToHand(IEnumerable<ICard> cards, bool canUseShieldTrigger, IAbility ability);
        void ResolveReflexiveTriggeredAbilities();
        int GetAmountOfShieldsCreatureBreaks(ICard attackingCreature);
        void ProcessCreatureAttackedEvent(ICard attacker, IAttackable target);
        void AddPendingSilentSkillAbilities(IEnumerable<ICard> cards);
        IEnumerable<ICard> GetBattleZoneCreatures(IPlayer player) => BattleZone.GetCreatures(player);
        IEnumerable<ICard> GetBattleZoneCreaturesWithSilentSkill(IPlayer player) => BattleZone.GetCreaturesWithSilentSkill(player);
        void RemoveSummoningSicknesses(IPlayer player) => BattleZone.RemoveSummoningSicknesses(player);
        bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(IPlayer player) => ContinuousEffects.CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(player);
        bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn() => ContinuousEffects.DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();
        int GetAmountOfBattleZoneCreatures(IPlayer player) => GetBattleZoneCreatures(player).Count();
    }
}