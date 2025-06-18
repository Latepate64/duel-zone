namespace Engine.ContinuousEffects
{
    public interface ICanAttackUntappedCreaturesEffect : IContinuousEffect
    {
        bool CanAttackUntappedCreature(Creature attacker, Creature targetOfAttack, IGame game);
    }
}
