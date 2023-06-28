using System;
using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IBattleZone : IZone, ICopyable<IBattleZone>
    {
        IEnumerable<ICard> EvolutionCreatures { get; }

        IEnumerable<ICard> GetChoosableCreaturesControlledByAnyone(IGame game, IPlayer chooser);
        IEnumerable<ICard> GetChoosableCreaturesControlledByChoosersOpponent(IGame game, IPlayer chooser);
        IEnumerable<ICard> GetChoosableEvolutionCreaturesControlledByChoosersOpponent(IGame game, IPlayer chooser);
        IEnumerable<ICard> GetChoosableUntappedCreaturesControlledByChoosersOpponent(IGame game, IPlayer chooser);
        IEnumerable<ICard> GetCreatures(Guid controller, Race race);
        IEnumerable<ICard> GetCreatures(Guid controller, Race race1, Race race2);
        IEnumerable<ICard> GetCreatures(Guid controller, Civilization civilization);
        IEnumerable<ICard> GetCreatures(Guid controller, Civilization civilization1, Civilization civilization2);
        IEnumerable<ICard> GetCreatures(IPlayer player);
        IEnumerable<ICard> GetCreaturesWithSilentSkill(IPlayer player);
        IEnumerable<ICard> GetOtherCreatures(Guid controller, Guid creature);
        IEnumerable<ICard> GetOtherCreatures(Guid controller, Guid creature, Civilization civilization);
        IEnumerable<ICard> GetOtherCreatures(Guid creature, Civilization civilization);
        IEnumerable<ICard> GetOtherCreatures(Guid creature, Race race);
        IEnumerable<ICard> GetOtherTappedCreatures(Guid controller, Guid creature);
        IEnumerable<ICard> GetOtherUntappedCreatures(Guid controller, Guid creature);
        IEnumerable<ICard> GetTappedCreatures(Guid controller);
        void RemoveSummoningSicknesses(IPlayer player);
    }
}