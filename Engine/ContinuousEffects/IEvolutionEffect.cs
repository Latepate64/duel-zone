namespace Engine.ContinuousEffects
{
    public interface IEvolutionEffect : IContinuousEffect
    {
        bool CanEvolveFrom(ICard bait, ICard evolutionCreature, IGame game);
        bool CanEvolve(IGame game, ICard evolutionCreature);
    }
}