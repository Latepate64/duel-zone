using Interfaces;

namespace GameEvents;

public sealed class AttackEvent : GameEventV2
{
    public ICreature AttackingCreature { get; init; }
    public ICreature AttackedCreature { get; init; }
    public IPlayerV2 AttackedPlayer { get; init; }
    bool shouldEnd;

    public AttackEvent(IPlayerV2 player, bool passable = true) : base(player, passable)
    {
    }

    AttackEvent(AttackEvent gameEvent) : base(gameEvent)
    {
        AttackingCreature = gameEvent.AttackingCreature.Copy();
        AttackedCreature = gameEvent.AttackedCreature.Copy();
        AttackedPlayer = gameEvent.AttackedPlayer.Copy();
        shouldEnd = gameEvent.shouldEnd;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is AttackEvent a
            && a.AttackingCreature == AttackingCreature
            && a.AttackedCreature == AttackedCreature
            && a.AttackedPlayer == AttackedPlayer
            && a.shouldEnd == shouldEnd;
    }

    public override void Validate(IGameEventV2 gameEvent)
    {
        var attack = IllegalActionException.ThrowIfNotOfType<AttackEvent>(gameEvent);
        IllegalActionException.ThrowIf(attack, attack.AttackingCreature == null,
            IllegalActionType.AttackingCreatureIsNull);
        IllegalActionException.ThrowIf(attack, attack.AttackingCreature!.Tapped,
            IllegalActionType.AttackingCreatureIsTapped);
        // TODO: Check if any effect bypasses summoning sickness
        IllegalActionException.ThrowIf(attack, attack.AttackingCreature.SummoningSickness,
            IllegalActionType.AttackingCreatureHasSummoningSickness);
        IllegalActionException.ThrowIf(attack, attack.AttackedCreature == null && attack.AttackedPlayer == null,
            IllegalActionType.AttackedCreatureAndAttackedPlayerAreNull);
        IllegalActionException.ThrowIf(attack, attack.AttackedCreature != null && attack.AttackedPlayer != null,
            IllegalActionType.AttackedCreatureAndAttackedPlayerAreNotNull);
        // TODO: Check if the attacking creature can attack the chosen creature
        // TODO: Check if the attacking creature can attack the chosen player
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        if (shouldEnd)
        {
            return [];
        }
        shouldEnd = true;
        AttackingCreature.Tapped = true;
        // TODO: Check if blocking happens
        if (AttackedCreature != null)
        {
            return [new BattleEventV2(Player, AttackingCreature, AttackedCreature)];
        }
        if (AttackedPlayer == null)
        {
            throw new InvalidOperationException();
        }
        if (!AttackedPlayer.ShieldZone.HasCards)
        {
            return [new LoseGameEvent(AttackedPlayer)];
        }
        throw new NotImplementedException();
    }

    public override IGameEventV2 Copy()
    {
        return new AttackEvent(this);
    }
}