namespace Interfaces.Zones;

public interface IBattleZone : IZone
{
    IEnumerable<ICreature> GetChoosableCreatures(
        IPlayerV2 player, ICardFilter filter, IGame game);
    IEnumerable<ICreature> GetOpponentsChoosableCreatures(
        IPlayerV2 player, ICardFilter filter, IGame game);
    IEnumerable<ICreature> GetUntappedCreatures(IPlayerV2 player);
    IEnumerable<ICreature> GetOtherCreaturesControlledByPlayer(
        ICreature creature, ICardFilter filter);
    IEnumerable<ICreature> GetCreaturesControlledByPlayer(IPlayerV2 player);
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
    IEnumerable<ICreature> GetChoosableCreatures(IPlayerV2 applier,
        ICardFilter filter, IGame game, SelectionRange selectionRange);
}
