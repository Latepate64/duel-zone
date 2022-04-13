using System;

namespace Common.GameEvents
{
    public class PhaseBegunEvent : GameEvent
    {
        public PhaseOrStep PhaseOrStep { get; set; }

        public ITurn Turn { get; set; }

        public PhaseBegunEvent()
        {
        }

        public PhaseBegunEvent(PhaseOrStep phase, ITurn turn)
        {
            PhaseOrStep = phase;
            Turn = turn;
        }

        public override string ToString()
        {
            return $"{Turn}: {ToString(PhaseOrStep)} begun.";
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