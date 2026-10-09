namespace Interfaces.ContinuousEffects
{
    public interface IBreaksAdditionalShieldsEffect : IContinuousEffect
    {
        int GetAmount(ICreature creature);
    }
}
