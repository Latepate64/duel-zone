using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace Interfaces;

public interface IGameState
{
    IPlayerV2[] Players { get; }
    IPlayerV2 Winner { get; set; }
    List<IPlayerV2> Losers { get; init; }
    IEventStack EventsHappening { get; init; }
    IGameEventV2 PassableAction { get; set; }
    IEventsThatWouldHappen EventsThatWouldHappen { get; }
    int TurnNumber { get; }
    IBattleZone BattleZone { get; init; }
    IContinuousEffects ContinuousEffects { get; }
    IPlayerV2 ActivePlayer { get; }
    IEnumerable<IPlayerV2> NonActivePlayers { get; }
    bool GameOver { get; }

    bool Equals(object obj);
}
