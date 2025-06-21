namespace Interfaces.ContinuousEffects
{
    public interface IBreakerEffect : IContinuousEffect
    {
        int GetAmount(IGame game, ICreature creature);
    }
}
