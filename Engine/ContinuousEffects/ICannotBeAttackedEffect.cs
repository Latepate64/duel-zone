namespace Engine.ContinuousEffects
{
    public interface ICannotBeAttackedEffect : IContinuousEffect
    {
        bool Applies(Card attacker, Card targetOfAttack, IGame game);
    }
}
