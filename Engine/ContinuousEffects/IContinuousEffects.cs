using Engine.Abilities;
using Engine.GameEvents;
using System;
using System.Collections.Generic;

namespace Engine.ContinuousEffects
{
    public interface IContinuousEffects : IDisposable, ICopyable<IContinuousEffects>
    {
        IGame Game { get; }

        void AddContinuousEffects(ICard source, params IStaticAbility[] staticAbilities);
        void AddContinuousEffects(IAbility source, params IContinuousEffect[] continuousEffects);
        void ApplyContinuousEffects();
        bool CanCreatureAttack(ICard creature);
        bool CanCreatureAttackCreature(ICard attacker, ICard targetOfAttack);
        bool CanCreatureAttackPlayers(ICard creature);
        bool CanCreatureAttackUntappedCreature(ICard attacker, ICard c);
        bool CanCreatureBeAttackedAsThoughItWereTapped(ICard c);
        bool CanCreatureBeBlocked(ICard attackingCreature, ICard blocker, IAttackable attackTarget);
        bool CanCreatureBlockCreature(ICard blocker, ICard attackingCreature);
        bool CanCreatureEvolve(ICard card);
        bool CanPlayerChooseCreature(IPlayer player, ICard card);
        bool CanPlayersUseTapAbilities();
        bool CanPlayerTapCreature(IPlayer player, ICard card);
        bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(IPlayer player);
        bool CanPlayerUseCard(ICard card);
        bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();
        bool DoesAnySlayerEffectApply(ICard loser, ICard winner);
        bool DoesBattleHappenAfterCreatureBecomesBlocked(ICard attackingCreature, ICard blockingCreature);
        bool DoesCreatureAttackIfAble(ICard attacker);
        bool DoesCreatureBlockIfAble(ICard blocker, ICard attackingCreature);
        bool DoesCreatureGetDestroyedInBattle(ICard against, ICard target);
        bool DoesCreatureHaveSpeedAttacker(ICard creature);
        bool DoesPlayerIgnoreAnyEffectsThatWouldPreventCreatureFromAttackingTheirOpponent(ICard creature);
        int GetAmountOfShieldsCreatureBreaksAdditionally(ICard attackingCreature);
        IEnumerable<int> GetAmountsOfShieldsCreatureCanBreak(ICard attackingCreature);
        IEnumerable<IReplacementEffect> GetReplacementEffectsThatCanBeApplied(IGameEvent gameEvent);
        void NotifyContinuousEffects(IGameEvent gameEvent);
        void RemoveContinuousEffects(IEnumerable<Guid> enumerable);
        void RemoveExpiredContinuousEffects(IGameEvent gameEvent);
    }
}