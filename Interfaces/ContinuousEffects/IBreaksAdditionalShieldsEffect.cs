namespace Interfaces.ContinuousEffects
{
    public interface IBreaksAdditionalShieldsEffect : IContinuousEffect
    {
        int GetAmount(IGame game, ICreature creature);
    }
}
