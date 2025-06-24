using Interfaces;

namespace GameEvents;

public sealed class BattleEventV2(IPlayerV2 player, ICreature attackingCreature, ICreature defendingCreature) : GameEventV2(
    player, passable: false)
{
    public ICreature AttackingCreature { get; } = attackingCreature;
    public ICreature DefendingCreature { get; } = defendingCreature;
    readonly List<ICard> winners = [];
    bool shouldEnd;
    public IEnumerable<ICard> Winners => winners;

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is BattleEventV2 e
            && e.AttackingCreature == AttackingCreature
            && e.DefendingCreature == DefendingCreature
            && e.winners == winners
            && e.shouldEnd == shouldEnd;
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        if (shouldEnd)
        {
            return [];
        }
        shouldEnd = true;
        if (AttackingCreature.Power.Value > DefendingCreature.Power.Value)
        {
            return SetWinnerAndGetDestroyEvents(state, AttackingCreature, DefendingCreature);
        }
        else if (AttackingCreature.Power.Value < DefendingCreature.Power.Value)
        {
            return SetWinnerAndGetDestroyEvents(state, DefendingCreature, AttackingCreature);
        }
        else
        {
            return [
                .. GetDestroyEvents(state, AttackingCreature, DefendingCreature),
                .. GetDestroyEvents(state, DefendingCreature, AttackingCreature)];
        }
    }

    IEnumerable<GameEventV2> SetWinnerAndGetDestroyEvents(IGameState state, ICreature winner, ICreature loser)
    {
        winners.Add(winner);
        return GetDestroyEvents(state, loser, winner);
    }

    static IEnumerable<GameEventV2> GetDestroyEvents(IGameState state, ICreature target, ICreature against)
    {
        if (state.ContinuousEffects.DoesCreatureGetDestroyedInBattle(against, target))
        {
            return [new PutIntoGraveyardEvent(target.OwnerV2, target)];
        }
        return [];
    }
}