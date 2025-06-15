using System;
using System.Collections.Generic;

namespace Engine.GameEvents;

public class AttackEvent(PlayerV2 player, bool passable = true) : GameEventV2(player, passable)
{
    public Card AttackingCreature { get; init; }
    public Card AttackedCreature { get; init; }
    public PlayerV2 AttackedPlayer { get; init; }
    bool shouldEnd;

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is AttackEvent a
            && a.AttackingCreature == AttackingCreature
            && a.AttackedCreature == AttackedCreature
            && a.AttackedPlayer == AttackedPlayer
            && a.shouldEnd == shouldEnd;
    }

    internal override void Validate(GameEventV2 gameEvent)
    {
        var attack = IllegalActionException.ThrowIfNotOfType<AttackEvent>(gameEvent);
        IllegalActionException.ThrowIf(attack, attack.AttackingCreature == null,
            IllegalActionType.AttackingCreatureIsNull);
        IllegalActionException.ThrowIf(attack, attack.AttackingCreature.Tapped,
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

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        if (shouldEnd)
        {
            return [];
        }
        shouldEnd = true;
        AttackingCreature.Tap();
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
}