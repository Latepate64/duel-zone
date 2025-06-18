namespace Engine.ContinuousEffects
{
    public interface ICannotBeAttackedEffect : IContinuousEffect
    {
        bool Applies(Creature attacker, Creature targetOfAttack, IGame game);
    }
}
