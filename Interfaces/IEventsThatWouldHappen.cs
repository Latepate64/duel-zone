
namespace Interfaces;

public interface IEventsThatWouldHappen
{
    void Add(params IGameEventV2[] events);
    void Clear();
    IEnumerable<IGameEventV2> Get();
}
