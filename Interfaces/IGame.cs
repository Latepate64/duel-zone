using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace Interfaces;

public interface IGame
{
    IBattleZone BattleZone { get; }

    IEnumerable<IPlayer> Players { get; }
    public IContinuousEffects ContinuousEffects { get; }

    void AddAbility(ICard card, IAbility ability);

    void AddContinuousEffects(IAbility source, params IContinuousEffect[] continuousEffects);
    void AddDelayedTriggeredAbility(IDelayedTriggeredAbility ability);
    void Break(ICreature creature, int breakAmount);

    bool CanAttackAtLeastOneCreature(ICreature creature);
    bool CanAttackAtLeastSomething(ICreature creature);

    bool CanAttackCreature(ICard attacker, ICard targetOfAttack);

    void Destroy(IAbility ability, params ICreature[] cards);

    IEnumerable<ICard> GetAllCards();

    ICard GetCard(Guid id);
    IPlayer GetOpponent(IPlayer player);
    Guid GetOpponent(Guid player);
    IPlayer GetOwner(ICard card);
    IPlayer GetPlayer(Guid id);
    int GetTimestamp();
    IZone GetZone(ICard card);

    void Lose(params IPlayer[] players);
    IEnumerable<IGameEvent> Move<T>(IAbility ability, ZoneType source, ZoneType destination, params T[] cards)
        where T : ICard;
    IEnumerable<IGameEvent> MoveTapped(IAbility ability, ZoneType hand, ZoneType manaZone, params ICard[] cards);
    void MoveTopCard(ICard card, ZoneType destination, IAbility ability);
    void PutFromShieldZoneToHand(IEnumerable<ICard> cards, bool canUseShieldTrigger, IAbility ability);
    IEnumerable<ICreature> GetBattleZoneCreatures(IPlayer player);
    int GetAmountOfBattleZoneCreatures(IPlayer player);
}
