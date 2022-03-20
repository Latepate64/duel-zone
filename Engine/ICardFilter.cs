using System;

namespace Engine
{
    public interface ICardFilter : IDisposable
    {
        bool Applies(ICard card, IGame game, IPlayer player);
        ICardFilter Copy();
        string ToString();
    }
}