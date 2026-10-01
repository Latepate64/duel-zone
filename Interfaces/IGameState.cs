using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace Interfaces;

public interface IGameState
{
    IPlayerV2[] Players { get; set; }
    IPlayerV2 Winner { get; set; }
    IList<IPlayerV2> Losers { get; init; }
    IEventStack EventsHappening { get; init; }
    IPassableGameEvent PassableAction { get; set; }
    IEventsThatWouldHappen EventsThatWouldHappen { get; }
    int TurnNumber { get; set; }
    IBattleZone BattleZone { get; init; }
    IContinuousEffects ContinuousEffects { get; }
    IPlayerV2 ActivePlayer { get; }
    IEnumerable<IPlayerV2> NonActivePlayers { get; }
    bool GameOver { get; }
}
