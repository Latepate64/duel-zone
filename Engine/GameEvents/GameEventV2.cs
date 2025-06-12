using System.Collections.Generic;
using System.Linq;

namespace Engine.GameEvents;

public abstract class GameEventV2
{
    public IEnumerable<GameEventV2> EventsThatWouldHappen => _eventsThatWouldHappen;
    public GameEventV2 HappeningEvent { get; set; }
    public PlayerAction PromptedAction { get; protected set; }

    protected int index;
    readonly List<GameEventV2> _eventsThatWouldHappen = [];

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>
    /// <param name="action"></param>
    /// <returns>true if the event has happened completely, false otherwise</returns>
    internal abstract bool Happen(GameState state, PlayerAction action);

    protected void AddEventThatWouldHappen(GameEventV2 gameEvent)
    {
        PromptedAction = null;
        _eventsThatWouldHappen.Add(gameEvent);
    }

    internal void ClearEventsThatWouldHappen()
    {
        _eventsThatWouldHappen.Clear();
    }

    public override bool Equals(object obj)
    {
        return obj is GameEventV2 e
            && HappeningEvent == e.HappeningEvent
            && PromptedAction == e.PromptedAction
            && index == e.index
            && _eventsThatWouldHappen.SequenceEqual(e._eventsThatWouldHappen);
    }
}