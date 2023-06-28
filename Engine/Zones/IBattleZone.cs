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
        IEnumerable<ICard> GetCreatures(IPlayer controller, Race race);
        IEnumerable<ICard> GetCreatures(IPlayer controller, Race race1, Race race2);
        IEnumerable<ICard> GetCreatures(IPlayer controller, Civilization civilization);
        IEnumerable<ICard> GetCreatures(IPlayer controller, Civilization civilization1, Civilization civilization2);
        IEnumerable<ICard> GetCreaturesWithSilentSkill(IPlayer player);
        IEnumerable<ICard> GetOtherCreatures(IPlayer controller, Guid creature);
        IEnumerable<ICard> GetOtherCreatures(IPlayer controller, Guid creature, Civilization civilization);
        IEnumerable<ICard> GetOtherCreatures(Guid creature, Civilization civilization);
        IEnumerable<ICard> GetOtherCreatures(Guid creature, Race race);
        IEnumerable<ICard> GetOtherTappedCreatures(IPlayer controller, Guid creature);
        IEnumerable<ICard> GetOtherUntappedCreatures(IPlayer controller, Guid creature);
        IEnumerable<ICard> GetTappedCreatures(IPlayer controller);
        void RemoveSummoningSicknesses(IPlayer player);
    }
}