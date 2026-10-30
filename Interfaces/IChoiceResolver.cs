namespace Interfaces;

public interface IChoiceResolver<T, U> where T : IChoiceEvent<ICard> where U : IGameEvent
{
    void Validate(T original, T proposed);
}