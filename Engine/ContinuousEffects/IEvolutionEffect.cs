namespace Engine.ContinuousEffects
{
    public interface IEvolutionEffect : IContinuousEffect
    {
        bool CanEvolveFrom(ICard bait, ICard evolutionCard, IGame game);
    }
}