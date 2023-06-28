﻿using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IZone
    {
        List<ICard> Cards { get; }
        IEnumerable<ICard> Creatures { get; }
        bool HasCards { get; }
        IEnumerable<ICard> Spells { get; }
        ZoneType Type { get; }
        IGame Game { get; }

        void Add(ICard card);
        void Dispose();
        IEnumerable<ICard> GetCards(Civilization civilization);
        IEnumerable<ICard> GetCreatures(Civilization civilization);
        IEnumerable<ICard> GetCreatures(Race race);
        IEnumerable<ICard> GetCreatures(IPlayer player);
        IEnumerable<ICard> GetOtherCreatures(ICard creature);
        List<ICard> Remove(ICard card);
        string ToString();
    }
}