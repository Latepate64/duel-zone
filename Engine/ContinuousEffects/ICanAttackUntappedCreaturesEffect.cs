namespace Engine.ContinuousEffects
{
    public interface ICanAttackUntappedCreaturesEffect : IContinuousEffect
    {
        bool CanAttackUntappedCreature(ICard attacker, ICard targetOfAttack, IGame game);
    }
}
