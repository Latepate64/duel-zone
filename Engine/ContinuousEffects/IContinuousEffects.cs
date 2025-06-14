using Engine.Abilities;
using Engine.GameEvents;
using System;
using System.Collections.Generic;

namespace Engine.ContinuousEffects
{
    public interface IContinuousEffects : IDisposable, ICopyable<IContinuousEffects>
    {
        IGame Game { get; }

        void Add(Card source, params IStaticAbility[] staticAbilities);
        void Add(IAbility source, params IContinuousEffect[] continuousEffects);
        void Apply();
        bool CanCreatureAttack(Card creature);
        bool CanCreatureAttackCreature(Card attacker, Card targetOfAttack);
        bool CanCreatureAttackPlayers(Card creature);
        bool CanCreatureAttackUntappedCreature(Card attacker, Card c);
        bool CanCreatureBeAttackedAsThoughItWereTapped(Card c);
        bool CanCreatureBeBlocked(Card attackingCreature, Card blocker, IAttackable attackTarget);
        bool CanCreatureBlockCreature(Card blocker, Card attackingCreature);
        bool CanCreatureEvolve(Card card);
        bool CanPlayerChooseCreature(IPlayer player, Card card);
        bool CanPlayersUseTapAbilities();
        bool CanPlayerTapCreature(IPlayer player, Card card);
        bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(IPlayer player);
        bool CanPlayerUseCard(Card card);
        bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();
        bool DoesAnySlayerEffectApply(Card loser, Card winner);
        bool DoesBattleHappenAfterCreatureBecomesBlocked(Card attackingCreature, Card blockingCreature);
        bool DoesCreatureAttackIfAble(Card attacker);
        bool DoesCreatureBlockIfAble(Card blocker, Card attackingCreature);
        bool DoesCreatureGetDestroyedInBattle(Card against, Card target);
        bool DoesCreatureHaveSpeedAttacker(Card creature);
        bool DoesPlayerIgnoreAnyEffectsThatWouldPreventCreatureFromAttackingTheirOpponent(Card creature);
        int GetAmountOfShieldsCreatureBreaksAdditionally(Card attackingCreature);
        IEnumerable<int> GetAmountsOfShieldsCreatureCanBreak(Card attackingCreature);
        IEnumerable<IReplacementEffect> GetReplacementEffectsThatCanBeApplied(IGameEvent gameEvent);
        void Notify(IGameEvent gameEvent);
        void Remove(IEnumerable<Guid> enumerable);
        void RemoveExpired(IGameEvent gameEvent);
    }
}