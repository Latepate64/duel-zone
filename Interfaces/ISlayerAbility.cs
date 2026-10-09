namespace Interfaces;

public interface ISlayerAbility : IStaticAbility
{
    bool Applies(ICreature creature, ICreature against);
}