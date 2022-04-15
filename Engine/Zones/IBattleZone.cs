using System;
using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IBattleZone : IZone, ICopyable<IBattleZone>
    {
        IEnumerable<ICard> GetChoosableCreaturesControlledByAnyone(IGame game, Guid owner);
        IEnumerable<ICard> GetChoosableCreaturesControlledByPlayer(IGame game, Guid owner);
        IEnumerable<ICard> GetChoosableEvolutionCreaturesControlledByPlayer(IGame game, Guid owner);
        IEnumerable<ICard> GetChoosableUntappedCreaturesControlledByPlayer(IGame game, Guid controller);
        IEnumerable<ICard> GetCreatures(Guid controller, Subtype subtype);
        IEnumerable<ICard> GetCreatures(Guid controller, Subtype subtype1, Subtype subtype2);
        IEnumerable<ICard> GetCreatures(Guid controller, Civilization civilization);
        IEnumerable<ICard> GetCreatures(Guid controller, Civilization civilization1, Civilization civilization2);
        IEnumerable<ICard> GetOtherCreatures(Guid controller, Guid creature);
        IEnumerable<ICard> GetOtherCreatures(Guid controller, Guid creature, Civilization civilization);
        IEnumerable<ICard> GetOtherCreatures(Guid creature, Civilization civilization);
        IEnumerable<ICard> GetOtherCreatures(Guid creature, Subtype subtype);
        IEnumerable<ICard> GetOtherTappedCreatures(Guid controller, Guid creature);
        IEnumerable<ICard> GetOtherUntappedCreatures(Guid controller, Guid creature);
        IEnumerable<ICard> GetTappedCreatures(Guid controller);
    }
}