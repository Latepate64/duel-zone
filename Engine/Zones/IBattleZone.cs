using System;
using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IBattleZone : IZone
    {
        IEnumerable<ICard> GetChoosableCreatures(IGame game, Guid owner);
        IEnumerable<ICard> GetChoosableEvolutionCreatures(IGame game, Guid owner);
        IEnumerable<ICard> GetCreatures(Guid controller, Common.Subtype subtype);
        IEnumerable<ICard> GetCreatures(Guid controller, Common.Subtype subtype1, Common.Subtype subtype2);
        IEnumerable<ICard> GetCreatures(Guid controller, Common.Civilization civilization);
        IEnumerable<ICard> GetCreatures(Guid controller, Common.Civilization civilization1, Common.Civilization civilization2);
    }
}