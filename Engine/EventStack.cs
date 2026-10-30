using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Engine;

public sealed class EventStack<TInputEvent, TOutputEvent> : IEventStack<TInputEvent, TOutputEvent> where TInputEvent : IGameEvent where TOutputEvent : IGameEvent
{
    readonly Stack<TInputEvent[]> events = new();
    private readonly IServiceProvider provider;

    public EventStack(IServiceProvider provider)
    {
        this.provider = provider;
    }

    private EventStack(EventStack<TInputEvent, TOutputEvent> eventStack)
    {
        events = new Stack<TInputEvent[]>(eventStack.events);
        provider = eventStack.provider;
    }

    public IEventStack<TInputEvent, TOutputEvent> Copy()
    {
        return new EventStack<TInputEvent, TOutputEvent>(this);
    }

    public void Push(params TInputEvent[] gameEvents)
    {
        events.Push(gameEvents);
    }

    public TInputEvent[] Pop()
    {
        return events.Pop();
    }

    public bool IsEmpty => events.Count == 0;

    public override bool Equals(object obj)
    {
        if (obj is not EventStack<TInputEvent, TOutputEvent> stack) return false;
        if (!events.SequenceEqual(stack.events)) return false;
        return true;
    }

    public IEnumerable<TOutputEvent> Happen(IGameState state)
    {
        var output = new List<TOutputEvent>();
        var eventsToHappen = events.Peek();
        foreach (var eventToHappen in eventsToHappen)
        {
            var resolver = provider.GetRequiredService<IEventResolver<TInputEvent, TOutputEvent>>();
            var player = state.ActivePlayer; //TODO IS NOT ALWAYS ACTIVE PLAYER!
            output.AddRange(resolver.Resolve(state, player, eventToHappen));
        }
        return output;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var e in events)
        {
            hash.Add(e);
        }
        return hash.ToHashCode();
    }

    public void SetChoice(IChoiceEvent<ICard> choice)
    {
        var resolver = provider.GetRequiredService<IEventResolver<TInputEvent, TOutputEvent>>();

        // var resolver = provider.GetRequiredService<IChoiceResolver<IChoiceEvent<ICard>, IGameEvent>>();
        // var eventsToHappen = events.Peek();
        // var original = eventsToHappen.OfType<IChoiceEvent<ICard>>().First(); // TODO Get the right one
        // resolver.Validate(original, choice);
        // var foo = events.ElementAt(1);
        // var moveEvent = foo.First();
        // var resolver2 = provider.GetRequiredService<IEventResolver<TInputEvent, TOutputEvent>>();

        // throw new NotImplementedException("remove original from stack?");
    }
}