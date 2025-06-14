namespace Engine.ContinuousEffects
{
    public interface IEvolutionEffect : IContinuousEffect
    {
        bool CanEvolve(IGame game, Card evolutionCreature);
        void Evolve(Card evolutionCreature, IGame game);
    }
}