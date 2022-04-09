namespace Engine.ContinuousEffects
{
    public interface ISubtypeAddingEffect : IContinuousEffect
    {
        void AddSubtype(IGame game);
    }
}
