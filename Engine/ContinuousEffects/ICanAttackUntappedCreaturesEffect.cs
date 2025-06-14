namespace Engine.ContinuousEffects
{
    public interface ICanAttackUntappedCreaturesEffect : IContinuousEffect
    {
        bool CanAttackUntappedCreature(Card attacker, Card targetOfAttack, IGame game);
    }
}
