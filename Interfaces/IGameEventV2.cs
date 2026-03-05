namespace Interfaces;

public interface IGameEventV2
{
    IPlayerV2 Player { get; }
    bool Passable { get; }
    IEnumerable<IGameEventV2> Happen(IGameState state);
    void Validate(IGameEventV2 gameEvent);
    IGameEventV2 Copy();
}
