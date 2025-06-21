using Interfaces;

namespace Engine.GameEvents;

public class ConcedeEvent(IPlayerV2 player) : LoseGameEvent(player)
{
}
