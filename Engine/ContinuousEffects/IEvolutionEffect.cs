namespace Engine.ContinuousEffects
{
    public interface IEvolutionEffect : IContinuousEffect
    {
        bool CanEvolve(IGame game, Creature evolutionCreature);
        void Evolve(Creature evolutionCreature, IGame game);
    }
}