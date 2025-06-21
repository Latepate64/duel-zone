using System;
using System.Collections.Generic;
using Interfaces;

namespace Engine.Zones;

public interface IBattleZone : IZone
{
    IEnumerable<Creature> CreaturesThatHaveBlocker { get; }
    IEnumerable<Creature> CreaturesThatDoNotHaveBlocker { get; }

    BattleZone Copy();
    IEnumerable<Creature> CreaturesThatHaveBlockerOwnedBy(Player player);
    IEnumerable<Creature> GetChoosableCreaturesControlledByAnyone(IGame game, Guid owner);
    IEnumerable<Creature> GetChoosableCreaturesControlledByPlayer(IGame game, Guid owner);
    IEnumerable<Creature> GetChoosableEvolutionCreaturesControlledByPlayer(IGame game, Guid owner);
    IEnumerable<Creature> GetChoosableUntappedCreaturesControlledByPlayer(IGame game, Guid controller);
    int GetCreatureCount(Guid controller, Race race);
    IEnumerable<Creature> GetCreatures(Guid controller, Race race);
    IEnumerable<Creature> GetCreatures(Guid controller, Race race1, Race race2);
    IEnumerable<Creature> GetCreatures(Guid controller, Civilization civilization);
    IEnumerable<Creature> GetCreatures(Guid controller, Civilization civilization1, Civilization civilization2);
    IEnumerable<Creature> GetCreatures(Player player);
    IEnumerable<Creature> GetCreaturesWithSilentSkill(Player player);
    int GetOtherCreatureCount(Guid controller, Guid creature, Civilization civilization);
    int GetOtherCreatureCount(Guid creature, Race race);
    IEnumerable<Creature> GetOtherCreatures(Guid controller, Guid creature);
    IEnumerable<Creature> GetOtherCreatures(Guid creature, Civilization civilization);
    IEnumerable<Creature> GetOtherTappedCreatures(Guid controller, Guid creature);
    IEnumerable<Creature> GetOtherUntappedCreatures(Guid controller, Guid creature);
    IEnumerable<Creature> GetTappedCreatures(Guid controller);
    void RemoveSummoningSicknesses(Player player);
}
