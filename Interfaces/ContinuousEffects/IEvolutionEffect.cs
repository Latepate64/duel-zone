namespace Interfaces.ContinuousEffects;

public interface IEvolutionEffect : IContinuousEffect
{
    bool CanEvolve(IGame game, ICreature evolutionCreature);
}
