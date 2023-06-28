namespace Engine.ContinuousEffects
{
    public interface IPlayerCannotChooseCreatureEffect : IContinuousEffect
    {
        bool PlayerCannotChooseCreature(ICard creature, System.Guid player);
    }
}
