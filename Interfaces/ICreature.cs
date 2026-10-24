namespace Interfaces;

public interface ICreature : ICard, IAttackable
{
    IList<Race> Races { get; }
    bool IsNonEvolutionCreature { get; }
    bool HasBlocker { get; }
}
