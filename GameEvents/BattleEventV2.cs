using Interfaces;

namespace GameEvents;

public sealed class BattleEventV2 : GameEventV2
{
    public ICreature AttackingCreature { get; }
    public ICreature DefendingCreature { get; }
    bool shouldEnd;

    public BattleEventV2(IPlayerV2 player, ICreature attackingCreature,
    ICreature defendingCreature) : base(player, passable: false)
    {
        AttackingCreature = attackingCreature;
        DefendingCreature = defendingCreature;
    }

    BattleEventV2(BattleEventV2 gameEvent) : base(gameEvent)
    {
        AttackingCreature = gameEvent.AttackingCreature.Copy();
        DefendingCreature = gameEvent.DefendingCreature.Copy();
        shouldEnd = gameEvent.shouldEnd;
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not BattleEventV2 e) return false;
        if (e.AttackingCreature != AttackingCreature) return false;
        if (e.DefendingCreature != DefendingCreature) return false;
        if (e.shouldEnd != shouldEnd) return false;
        return true;
    }

    public override IEnumerable<IGameEventV2> Happen(IGameState state)
    {
        if (shouldEnd)
        {
            return [];
        }
        shouldEnd = true;
        if (AttackingCreature.Power > DefendingCreature.Power)
        {
            return GetDestroyEvents(
                state, AttackingCreature, DefendingCreature);
        }
        else if (AttackingCreature.Power < DefendingCreature.Power)
        {
            return GetDestroyEvents(
                state, DefendingCreature, AttackingCreature);
        }
        return [
            .. GetDestroyEvents(state, AttackingCreature, DefendingCreature),
            .. GetDestroyEvents(state, DefendingCreature, AttackingCreature)];
    }

    static IEnumerable<IGameEventV2> GetDestroyEvents(
        IGameState state, ICreature creature1, ICreature creature2)
    {
        if (state.ContinuousEffects.DoesCreatureGetDestroyedInBattle(
            creature1, creature2))
        {
            return [new PutIntoGraveyardEvent(creature2.OwnerV2, creature2)];
        }
        return [];
    }

    public override BattleEventV2 Copy()
    {
        return new BattleEventV2(this);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            base.GetHashCode(),
            AttackingCreature,
            DefendingCreature,
            shouldEnd);
    }
}