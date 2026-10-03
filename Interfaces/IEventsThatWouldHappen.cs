
namespace Interfaces;

public interface IEventsThatWouldHappen
{
    void Add(params IGameEventV2[] events);
    void Clear();
    IEventsThatWouldHappen Copy();
    IEnumerable<IGameEventV2> Get();
}
