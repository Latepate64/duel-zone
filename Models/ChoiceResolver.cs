using Interfaces;

namespace Models;

public abstract class ChoiceResolver<T, U> : EventResolver<T, U>, IChoiceResolver<T, U> where T : IChoiceEvent<ICard> where U : IGameEvent
{
    public abstract void Validate(T original, T proposed);
}