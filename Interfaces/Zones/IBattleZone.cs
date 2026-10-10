namespace Interfaces.Zones;

public interface IBattleZone : IZone
{
    IEnumerable<ICreature> GetChoosableCreaturesControlledByAnyone(IGame game, Guid owner);
    IEnumerable<ICreature> GetChoosableCreaturesControlledByPlayer(IGame game, Guid owner);
    IEnumerable<ICreature> GetChoosableEvolutionCreaturesControlledByPlayer(IGame game, Guid owner);
    IEnumerable<ICreature> GetChoosableUntappedCreaturesControlledByPlayer(IGame game, Guid controller);
    IEnumerable<ICreature> GetOtherCreatures(Guid controller, Guid creature);
    IEnumerable<ICreature> GetUntappedCreatures(IPlayerV2 player);
    IEnumerable<ICreature> GetOtherCreaturesControlledByPlayer(
        ICreature creature, ICardFilter filter);
    IEnumerable<ICreature> GetCreaturesControllerByPlayer(IPlayerV2 player);
    IEnumerable<ICreature> GetCreaturesControlledByPlayer(
        IPlayerV2 player, ICardFilter filter);
    int GetNumberOfCreaturesControllerByPlayer(
        IPlayerV2 player, ICardFilter filter);
    int GetNumberOfOtherCreaturesControllerByPlayer(ICreature creature);
    int GetNumberOfOtherCreaturesControllerByPlayer(
        ICreature creature, ICardFilter filter);
    bool HasCreaturesControllerByPlayer(IPlayerV2 applier, ICardFilter filter);
    bool HasOtherCreaturesControllerByPlayer(
        ICreature creature, ICardFilter filter);
    int GetNumberOfOtherCreatures(ICreature creature, ICardFilter filter);
    IEnumerable<ICreature> GetCreatures(ICardFilter filter);
}
