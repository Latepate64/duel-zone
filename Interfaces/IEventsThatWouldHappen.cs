
namespace Interfaces;

public interface IEventsThatWouldHappen
{
    void Add(params IGameEvent[] events);
    void Clear();
    IEventsThatWouldHappen Copy();
    IEnumerable<IGameEvent> Get();
}
