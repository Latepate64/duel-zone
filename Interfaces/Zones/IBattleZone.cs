namespace Interfaces.Zones;

public interface IBattleZone : IZone
{
    IEnumerable<ICreature> GetChoosableCreatures(
        IPlayer player, ICardFilter filter, IGame game);
    IEnumerable<ICreature> GetOpponentsChoosableCreatures(
        IPlayer player, ICardFilter filter, IGame game);
    IEnumerable<ICreature> GetUntappedCreatures(IPlayer player);
    IEnumerable<ICreature> GetOtherCreaturesControlledByPlayer(
        ICreature creature, ICardFilter filter);
    IEnumerable<ICreature> GetCreaturesControlledByPlayer(
        IPlayer player, ICardFilter filter);
    IEnumerable<ICreature> GetCreatures(ICardFilter filter);
    IEnumerable<ICreature> GetChoosableCreatures(IPlayer applier,
        ICardFilter filter, IGame game, SelectionRange selectionRange);
    IEnumerable<ICreature> GetCreatures(IPlayer applier, ICardFilter filter,
        SelectionRange selectionRange);
    int GetNumberOfCreaturesControllerByPlayer(
        IPlayer player, ICardFilter filter);
    int GetNumberOfOtherCreatures(ICreature creature, ICardFilter filter);
    int GetNumberOfOtherCreaturesControllerByPlayer(
        ICreature creature, ICardFilter filter);
    bool HasCreaturesControllerByPlayer(IPlayer applier, ICardFilter filter);
    bool HasOtherCreaturesControllerByPlayer(
        ICreature creature, ICardFilter filter);
}
