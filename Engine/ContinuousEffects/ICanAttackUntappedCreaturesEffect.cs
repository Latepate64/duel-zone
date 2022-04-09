namespace Engine.ContinuousEffects
{
    public interface ICanAttackUntappedCreaturesEffect : IContinuousEffect
    {
        bool Applies(ICard attacker, ICard targetOfAttack, IGame game);
    }
}
