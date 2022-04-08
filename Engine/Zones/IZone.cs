using System;
using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IZone
    {
        List<ICard> Cards { get; }
        IEnumerable<ICard> Creatures { get; }

        void Add(ICard card, IGame game);
        void Dispose();
        IEnumerable<ICard> GetCreatures(Guid owner);
        IEnumerable<ICard> GetCreatures(Common.Subtype subtype);
        List<ICard> Remove(ICard card, IGame game);
        string ToString();
    }
}