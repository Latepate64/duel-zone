namespace Interfaces;

public interface IGameEventV2
{
    IPlayerV2 Player { get; }
    IEnumerable<IGameEventV2> Happen(IGameState state);
    IGameEventV2 Copy();
}
