using System;
using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IZone
    {
        List<ICard> Cards { get; }
        IEnumerable<ICard> Creatures { get; }
        IEnumerable<ICard> Spells { get; }

        void Add(ICard card, IGame game);
        void Dispose();
        IEnumerable<ICard> GetCards(Civilization civilization);
        IEnumerable<ICard> GetCreatures(Civilization civilization);
        IEnumerable<ICard> GetCreatures(Guid owner);
        IEnumerable<ICard> GetCreatures(Race race);
        IEnumerable<ICard> GetOtherCreatures(Guid creature);
        List<ICard> Remove(ICard card, IGame game);
        string ToString();
    }
}