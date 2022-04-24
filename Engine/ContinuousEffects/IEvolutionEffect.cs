namespace Engine.ContinuousEffects
{
    public interface IEvolutionEffect : IContinuousEffect
    {
        bool CanEvolve(IGame game, ICard evolutionCreature);
        void Evolve(ICard evolutionCreature, IGame game);
    }
}