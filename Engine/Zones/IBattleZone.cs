using System;
using System.Collections.Generic;
using Interfaces;

namespace Engine.Zones;

public interface IBattleZone : IZone
{
    IEnumerable<ICreature> CreaturesThatHaveBlocker { get; }
    IEnumerable<ICreature> CreaturesThatDoNotHaveBlocker { get; }

    IBattleZone Copy();
    IEnumerable<ICreature> CreaturesThatHaveBlockerOwnedBy(IPlayer player);
    IEnumerable<ICreature> GetChoosableCreaturesControlledByAnyone(IGame game, Guid owner);
    IEnumerable<ICreature> GetChoosableCreaturesControlledByPlayer(IGame game, Guid owner);
    IEnumerable<ICreature> GetChoosableEvolutionCreaturesControlledByPlayer(IGame game, Guid owner);
    IEnumerable<ICreature> GetChoosableUntappedCreaturesControlledByPlayer(IGame game, Guid controller);
    int GetCreatureCount(Guid controller, Race race);
    IEnumerable<ICreature> GetCreatures(Guid controller, Race race);
    IEnumerable<ICreature> GetCreatures(Guid controller, Race race1, Race race2);
    IEnumerable<ICreature> GetCreatures(Guid controller, Civilization civilization);
    IEnumerable<ICreature> GetCreatures(Guid controller, Civilization civilization1, Civilization civilization2);
    IEnumerable<ICreature> GetCreatures(IPlayer player);
    IEnumerable<ICreature> GetCreaturesWithSilentSkill(IPlayer player);
    int GetOtherCreatureCount(Guid controller, Guid creature, Civilization civilization);
    int GetOtherCreatureCount(Guid creature, Race race);
    IEnumerable<ICreature> GetOtherCreatures(Guid controller, Guid creature);
    IEnumerable<ICreature> GetOtherCreatures(Guid creature, Civilization civilization);
    IEnumerable<ICreature> GetOtherTappedCreatures(Guid controller, Guid creature);
    IEnumerable<ICreature> GetOtherUntappedCreatures(Guid controller, Guid creature);
    IEnumerable<ICreature> GetTappedCreatures(Guid controller);
    void RemoveSummoningSicknesses(IPlayer player);
}
