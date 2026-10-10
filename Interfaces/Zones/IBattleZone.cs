namespace Interfaces.Zones;

public interface IBattleZone : IZone
{
    IEnumerable<ICreature> CreaturesThatHaveBlocker { get; }
    IEnumerable<ICreature> CreaturesThatDoNotHaveBlocker { get; }

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
    int GetOtherCreatureCount(Guid controller, Guid creature, Civilization civilization);
    int GetOtherCreatureCount(Guid creature, Race race);
    int GetNumberOfOtherCreaturesControllerByPlayer(ICreature attacker);
    IEnumerable<ICreature> GetOtherCreatures(Guid controller, Guid creature);
    IEnumerable<ICreature> GetOtherCreatures(Guid creature, Civilization civilization);
    IEnumerable<ICreature> GetOtherTappedCreatures(Guid controller, Guid creature);
    IEnumerable<ICreature> GetOtherUntappedCreatures(Guid controller, Guid creature);
    IEnumerable<ICreature> GetTappedCreatures(Guid controller);
    IEnumerable<ICreature> GetUntappedCreatures(IPlayerV2 player);
    IEnumerable<ICreature> GetOtherCivilizationCreaturesControllerByPlayer(
        ICreature excluded, Civilization light);
    IEnumerable<ICreature> GetCreaturesWithSilentSkillControllerByPlayer(
        IPlayerV2 player);
    IEnumerable<ICreature> GetCreaturesControllerByPlayer(IPlayerV2 player);
    int GetNumberOfOtherCreaturesControllerByPlayer(
        ICreature creature, ICardFilter filter);
}
