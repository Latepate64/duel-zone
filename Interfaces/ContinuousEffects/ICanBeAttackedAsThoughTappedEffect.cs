namespace Interfaces.ContinuousEffects
{
    public interface ICanBeAttackedAsThoughTappedEffect : IContinuousEffect
    {
        bool Applies(ICreature targetOfAttack);
    }
}
