namespace Interfaces.ContinuousEffects
{
    public interface ISpeedAttackerEffect : IContinuousEffect
    {
        bool Applies(ICreature creature, IGame game);
    }
}
