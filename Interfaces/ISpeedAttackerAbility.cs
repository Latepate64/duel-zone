namespace Interfaces;

public interface ISpeedAttackerAbility : IStaticAbility
{
    bool Applies(ICreature creature, IGame game);
}