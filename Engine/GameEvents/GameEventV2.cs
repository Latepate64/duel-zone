namespace Engine.GameEvents;

public abstract class GameEventV2
{
    protected int index;

    /// <param name="state"></param>
    /// <param name="action"></param>
    /// <returns>true if the event has happened completely, false otherwise</returns>
    internal abstract bool Happen(GameState state);

    public override bool Equals(object obj)
    {
        return obj is GameEventV2 e
            && index == e.index;
    }
}