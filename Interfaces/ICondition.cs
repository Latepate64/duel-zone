namespace Interfaces;

public interface ICondition
{
    bool IsMet(ICreature creature);
    ICondition Copy();
}
