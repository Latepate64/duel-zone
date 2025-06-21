using System;
using System.Collections.Generic;
using Interfaces;

namespace Engine.Zones
{
    public interface IZone
    {
        ZoneType Type { get; }
        IEnumerable<Creature> Creatures { get; }
        IEnumerable<Spell> Spells { get; }
        int Size { get; }
        bool HasCards { get; }
        IEnumerable<Card> Cards { get; }
        IEnumerable<Creature> Dragons { get; }

        IEnumerable<Card> CardsWithManaCost(int manaCost);
        IEnumerable<Card> CardsWithName(string name);
        void Dispose();
        bool Equals(object obj);
        int GetCardCount(Civilization civilization);
        IEnumerable<Card> GetCards(Civilization civilization);
        int GetCreatureCount(Guid owner);
        int GetCreatureCount(Civilization civilization);
        IEnumerable<Creature> GetCreatures(Guid owner);
        IEnumerable<Creature> GetCreatures(params Race[] races);
        IEnumerable<Creature> GetCreatures(Civilization civilization);
        IEnumerable<Creature> GetCreaturesWithMaxPower(int maxPower);
        IEnumerable<Creature> GetOtherCreatures(Guid creature);
        IEnumerable<Card> NonCivilizationCards(Civilization civ);
        void SetOwner(PlayerV2 owner);
    }
}
