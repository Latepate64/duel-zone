namespace Engine.ContinuousEffects
{
    public interface IEvolutionEffect : IContinuousEffect
    {
        bool CanEvolve(ICard evolutionCreature);
        void Evolve(ICard evolutionCreature);
    }
}