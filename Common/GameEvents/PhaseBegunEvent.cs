﻿using System;

namespace Common.GameEvents
{
    public enum PhaseOrStep
    {
        StartOfTurn,
        Draw,
        Charge,
        Main,
        Attack,
        AttackDeclaration,
        BlockDeclaration,
        Battle,
        DirectAttack,
        EndOfAttack,
        EndOfTurn,
    }

    public class PhaseBegunEvent : GameEvent
    {
        public PhaseOrStep PhaseOrStep { get; set; }

        public Player Player { get; set; }

        public Guid Turn { get; set; }

        public PhaseBegunEvent()
        {
        }

        public PhaseBegunEvent(PhaseOrStep phase, Player player, Guid turn)
        {
            PhaseOrStep = phase;
            Player = player;
            Turn = turn;
        }

        public override string ToString()
        {
            return $"{Player} started {ToString(PhaseOrStep)}.";
        }

        private static string ToString(PhaseOrStep phase)
        {
            return phase switch
            {
                PhaseOrStep.StartOfTurn => $"Start of turn phase",
                PhaseOrStep.Draw => $"Draw phase",
                PhaseOrStep.Charge => $"Charge phase",
                PhaseOrStep.Main => $"Main phase",
                PhaseOrStep.Attack => $"Attack phase",
                PhaseOrStep.AttackDeclaration => $"Attack declaration step",
                PhaseOrStep.BlockDeclaration => $"Block declaration step",
                PhaseOrStep.Battle => $"Battle step",
                PhaseOrStep.DirectAttack => $"Direct attack step",
                PhaseOrStep.EndOfAttack => $"End of attack step",
                PhaseOrStep.EndOfTurn => $"End of turn phase",
                _ => throw new NotImplementedException(),
            };
        }
    }
}