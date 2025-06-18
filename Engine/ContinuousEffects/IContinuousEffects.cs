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
        bool CanCreatureAttack(Creature creature);
        bool CanCreatureAttackCreature(Creature attacker, Creature targetOfAttack);
        bool CanCreatureAttackPlayers(Creature creature);
        bool CanCreatureAttackUntappedCreature(Creature attacker, Creature c);
        bool CanCreatureBeAttackedAsThoughItWereTapped(Creature c);
        bool CanCreatureBeBlocked(Creature attackingCreature, Creature blocker, IAttackable attackTarget);
        bool CanCreatureBlockCreature(Creature blocker, Creature attackingCreature);
        bool CanCreatureEvolve(Creature card);
        bool CanPlayerChooseCreature(Player player, Creature card);
        bool CanPlayersUseTapAbilities();
        bool CanPlayerTapCreature(Player player, Creature card);
        bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(Player player);
        bool CanPlayerUseCard(Card card);
        bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();
        bool DoesAnySlayerEffectApply(Creature loser, Creature winner);
        bool DoesBattleHappenAfterCreatureBecomesBlocked(Creature attackingCreature, Creature blockingCreature);
        bool DoesCreatureAttackIfAble(Creature attacker);
        bool DoesCreatureBlockIfAble(Creature blocker, Creature attackingCreature);
        bool DoesCreatureGetDestroyedInBattle(Creature against, Creature target);
        bool DoesCreatureHaveSpeedAttacker(Creature creature);
        bool DoesPlayerIgnoreAnyEffectsThatWouldPreventCreatureFromAttackingTheirOpponent(Creature creature);
        int GetAmountOfShieldsCreatureBreaksAdditionally(Creature attackingCreature);
        IEnumerable<int> GetAmountsOfShieldsCreatureCanBreak(Creature attackingCreature);
        IEnumerable<IReplacementEffect> GetReplacementEffectsThatCanBeApplied(IGameEvent gameEvent);
        void Notify(IGameEvent gameEvent);
        void Remove(IEnumerable<Guid> enumerable);
        void RemoveExpired(IGameEvent gameEvent);
    }
}