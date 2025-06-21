using System.Collections.Generic;

namespace Engine.GameEvents;

public class BattleEventV2(IPlayerV2 player, Creature attackingCreature, Creature defendingCreature) : GameEventV2(
    player, passable: false)
{
    public Creature AttackingCreature { get; } = attackingCreature;
    public Creature DefendingCreature { get; } = defendingCreature;
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

    internal override IEnumerable<GameEventV2> Happen(GameState state)
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

    IEnumerable<GameEventV2> SetWinnerAndGetDestroyEvents(GameState state, Creature winner, Creature loser)
    {
        winners.Add(winner);
        return GetDestroyEvents(state, loser, winner);
    }

    static IEnumerable<GameEventV2> GetDestroyEvents(GameState state, ICreature target, Creature against)
    {
        if (state.ContinuousEffects.DoesCreatureGetDestroyedInBattle(against, target))
        {
            return [new PutIntoGraveyardEvent(target.OwnerV2, target)];
        }
        return [];
    }
}