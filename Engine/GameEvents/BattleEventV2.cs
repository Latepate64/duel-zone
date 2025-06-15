using System.Collections.Generic;

namespace Engine.GameEvents;

public class BattleEventV2(PlayerV2 player, Card attackingCreature, Card defendingCreature) : GameEventV2(
    player, passable: false)
{
    public Card AttackingCreature { get; } = attackingCreature;
    public Card DefendingCreature { get; } = defendingCreature;
    readonly List<Card> winners = [];
    bool shouldEnd;
    public IEnumerable<Card> Winners => winners;

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

    IEnumerable<GameEventV2> SetWinnerAndGetDestroyEvents(GameState state, Card winner, Card loser)
    {
        winners.Add(winner);
        return GetDestroyEvents(state, loser, winner);
    }

    static IEnumerable<GameEventV2> GetDestroyEvents(GameState state, Card target, Card against)
    {
        if (state.ContinuousEffects.DoesCreatureGetDestroyedInBattle(against, target))
        {
            return [new PutIntoGraveyardEvent(target.OwnerV2, target)];
        }
        return [];
    }
}