using System;

namespace Engine.Durations
{
    // TODO: Move implementations to Cards project and define method in IDuration that should check if duration ends.
    public interface IDuration : IDisposable
    {
        IDuration Copy();
        string ToString();
    }
}