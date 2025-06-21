using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace Interfaces;

public interface IGame
{
    IBattleZone BattleZone { get; }
    // ITurn CurrentTurn { get; }
    /// <summary>
    /// 104.1. A game ends immediately when a player wins, when the game is a draw, or when the game is restarted.
    /// </summary>
    bool Ended { get; }

    // Stack<Turn> ExtraTurns { get; }
    IEnumerable<IPlayer> Players { get; }
    Queue<IGameEvent> PreGameEvents { get; }
    ISpellStack SpellStack { get; }
    // IList<Turn> Turns { get; }
    public IContinuousEffects ContinuousEffects { get; }
    // IPlayer ActivePlayer => CurrentTurn.ActivePlayer;

    void AddAbility(ICard card, IAbility ability);

    void AddContinuousEffects(IAbility source, params IContinuousEffect[] continuousEffects);
    void AddDelayedTriggeredAbility(IDelayedTriggeredAbility ability);

    void AddPendingAbilities(params IResolvableAbility[] abilities);

    void AddReflexiveTriggeredAbility(IResolvableAbility ability);

    bool AffectedBySummoningSickness(ICreature creature);
    void Battle(ICard attackingCreature, ICard defendingCreature);

    void Break(ICreature creature, int breakAmount);

    bool CanAttackAtLeastOneCreature(ICreature creature);
    bool CanAttackAtLeastSomething(ICreature creature) => CanAttackAtLeastOneCreature(creature) || CanAttackPlayers(creature);

    bool CanAttackCreature(ICard attacker, ICard targetOfAttack);

    bool CanAttackPlayers(ICreature creature);

    bool CanBeUsedRegardlessOfManaCost(ICard card);

    bool CheckStateBasedActions();

    void Destroy(IAbility ability, params ICreature[] cards);

    IAbility GetAbility(Guid id);

    IEnumerable<ICard> GetAllCards();

    IAttackable GetAttackable(Guid id);

    ICard GetCard(Guid id);

    IEnumerable<ICreature> GetChoosableCreaturesControlledByAnyone(IGame game, Guid id) => BattleZone.GetChoosableCreaturesControlledByAnyone(game, id);
    IEnumerable<ICreature> GetCreaturesThatHaveAttackTargets();
    IPlayer GetOpponent(IPlayer player);
    Guid GetOpponent(Guid player);
    IPlayer GetOwner(ICard card);
    IPlayer GetPlayer(Guid id);
    IEnumerable<IAttackable> GetPossibleAttackTargets(ICreature attacker);
    int GetTimestamp();
    IZone GetZone(ICard card);

    void Lose(params IPlayer[] players);
    IEnumerable<IGameEvent> Move<T>(IAbility ability, ZoneType source, ZoneType destination, params T[] cards)
        where T : ICard;
    IEnumerable<IGameEvent> MoveTapped(IAbility ability, ZoneType hand, ZoneType manaZone, params ICard[] cards);
    void MoveTopCard(ICard card, ZoneType destination, IAbility ability);
    void Play(IPlayer startingPlayer, IPlayer otherPlayer);
    IEnumerable<IGameEvent> ProcessEvents(params IGameEvent[] gameEvents);
    void PutFromShieldZoneToHand(IEnumerable<ICard> cards, bool canUseShieldTrigger, IAbility ability);
    void ResolveReflexiveTriggeredAbilities();
    int GetAmountOfShieldsCreatureBreaks(ICreature attackingCreature);
    void ProcessCreatureAttackedEvent(ICreature attacker, IAttackable target);
    void AddPendingSilentSkillAbilities(IEnumerable<ICreature> cards);
    IEnumerable<ICreature> GetBattleZoneCreatures(IPlayer player) => BattleZone.GetCreatures(player);
    IEnumerable<ICreature> GetBattleZoneCreaturesWithSilentSkill(IPlayer player) => BattleZone.GetCreaturesWithSilentSkill(player);
    void RemoveSummoningSicknesses(IPlayer player) => BattleZone.RemoveSummoningSicknesses(player);
    bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(IPlayer player) => ContinuousEffects.CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(player);
    bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn() => ContinuousEffects.DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();
    int GetAmountOfBattleZoneCreatures(IPlayer player) => GetBattleZoneCreatures(player).Count();
}
