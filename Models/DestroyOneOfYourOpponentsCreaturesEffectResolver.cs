using Interfaces;

namespace Models;

public class DestroyOneOfYourOpponentsCreaturesEffectResolver(IGame game)
    : EventResolver<DestroyOneOfYourOpponentsCreaturesEffect>
{
    private readonly IGame game = game;

    public override IEnumerable<IGameEventV3> Resolve(
        IGameState state, IPlayerV2 applier, DestroyOneOfYourOpponentsCreaturesEffect effect)
    {
        var creatures = state.BattleZone.GetOpponentsChoosableCreatures(
            applier, effect.CardFilter, game);
        if (!creatures.Any()) return [];
        else if (creatures.Count() == 1) return [new DestroyEvent(creatures.Single())];
        else throw new NotImplementedException("Let applier choose");
    }
}
