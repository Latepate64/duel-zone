namespace Interfaces.ContinuousEffects;

public interface IContinuousEffects : IDisposable, ICopyable<IContinuousEffects>
{
    IGame Game { get; }

    void Add(ICard source, params IStaticAbility[] staticAbilities);
    void Add(IAbility source, params IContinuousEffect[] continuousEffects);
    void Apply();
    bool CanCreatureAttack(ICreature creature);
    bool CanCreatureAttackCreature(ICreature attacker, ICreature targetOfAttack);
    bool CanCreatureAttackPlayers(ICreature creature);
    bool CanCreatureAttackUntappedCreature(ICreature attacker, ICreature c);
    bool CanCreatureBeAttackedAsThoughItWereTapped(ICreature c);
    bool CanCreatureBeBlocked(ICreature attackingCreature, ICreature blocker, IAttackable attackTarget);
    bool CanCreatureBlockCreature(ICreature blocker, ICreature attackingCreature);
    bool CanCreatureEvolve(ICreature card);
    bool CanPlayerChooseCreature(IPlayer player, ICreature card);
    bool CanPlayersUseTapAbilities();
    bool CanPlayerTapCreature(IPlayer player, ICreature card);
    bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(IPlayer player);
    bool CanPlayerUseCard(ICard card);
    bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();
    bool DoesAnySlayerEffectApply(ICreature loser, ICreature winner);
    bool DoesBattleHappenAfterCreatureBecomesBlocked(ICreature attackingCreature, ICreature blockingCreature);
    bool DoesCreatureAttackIfAble(ICreature attacker);
    bool DoesCreatureBlockIfAble(ICreature blocker, ICreature attackingCreature);
    bool DoesCreatureGetDestroyedInBattle(ICreature against, ICreature target);
    bool DoesCreatureHaveSpeedAttacker(ICreature creature);
    bool DoesPlayerIgnoreAnyEffectsThatWouldPreventCreatureFromAttackingTheirOpponent(ICreature creature);
    int GetAmountOfShieldsCreatureBreaksAdditionally(ICreature attackingCreature);
    IEnumerable<int> GetAmountsOfShieldsCreatureCanBreak(ICreature attackingCreature);
    IEnumerable<IReplacementEffect> GetReplacementEffectsThatCanBeApplied(IGameEvent gameEvent);
    void Notify(IGameEvent gameEvent);
    void Remove(IEnumerable<Guid> enumerable);
    void RemoveExpired(IGameEvent gameEvent);
}
