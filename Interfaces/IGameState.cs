using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace Interfaces;

public interface IGameState
{
    IPlayer Winner { get; set; }
    IList<IPlayer> Losers { get; set; }
    IEventStack EventsHappening { get; }
    IPassableGameEvent PassableAction { get; set; }
    IEventsThatWouldHappen EventsThatWouldHappen { get; }
    int TurnNumber { get; set; }
    IBattleZone BattleZone { get; init; }
    IContinuousEffects ContinuousEffects { get; }
    IPlayer ActivePlayer { get; set; }
    IPlayer NonActivePlayer { get; set; }
    bool GameOver { get; }
    IGameState Copy();
}
