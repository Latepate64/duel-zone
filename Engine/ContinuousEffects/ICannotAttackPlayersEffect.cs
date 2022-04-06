namespace Engine.ContinuousEffects
{
    public interface ICannotAttackPlayersEffect : IContinuousEffect
    {
        bool Applies(ICard creature, IGame game);
    }
}
