namespace Engine.ContinuousEffects
{
    public interface ICannotBeAttackedEffect : IContinuousEffect
    {
        bool Applies(ICard attacker, ICard targetOfAttack, IGame game);
    }
}
