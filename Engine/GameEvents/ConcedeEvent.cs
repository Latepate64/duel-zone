using Interfaces;

namespace Engine.GameEvents;

public sealed class ConcedeEvent(IPlayerV2 player) : LoseGameEvent(player)
{
}
