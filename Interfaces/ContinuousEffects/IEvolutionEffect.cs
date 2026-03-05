namespace Interfaces.ContinuousEffects;

public interface IEvolutionEffect : IContinuousEffect
{
    bool CanEvolve(IGame game, ICreature evolutionCreature);
    void Evolve(ICreature evolutionCreature, IGame game);
}
