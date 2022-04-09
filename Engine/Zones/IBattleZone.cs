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
        IEnumerable<ICard> GetOtherCreatures(Guid controller, Guid creature);
        IEnumerable<ICard> GetOtherCreatures(Guid controller, Guid creature, Common.Civilization civilization);
        IEnumerable<ICard> GetOtherCreatures(Guid creature, Common.Civilization civilization);
        IEnumerable<ICard> GetOtherCreatures(Guid creature, Common.Subtype subtype);
        IEnumerable<ICard> GetTappedCreatures(Guid controller);
        IEnumerable<ICard> GetOtherTappedCreatures(Guid controller, Guid creature);
        IEnumerable<ICard> GetOtherUntappedCreatures(Guid controller, Guid creature);
    }
}