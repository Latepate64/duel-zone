using Interfaces;

namespace GameEvents;

public sealed class ConcedeEvent(IPlayerV2 player) : LoseGameEvent(player), IConcedeEvent
{
}
