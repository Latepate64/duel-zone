using Interfaces;

namespace Models;

public class DestroyEvent(ICreature creature) : IGameEventV3
{
    public ICreature Creature { get; set; } = creature;
}