namespace Interfaces;

public interface ISlayerAbility : IStaticAbility
{
    bool Applies(ICreature creature, ICard against, IGame game);
}