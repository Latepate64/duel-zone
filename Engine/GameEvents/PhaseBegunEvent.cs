using Engine.Steps;
using Interfaces;

namespace Engine.GameEvents
{
    public sealed class PhaseBegunEvent(Phase nextPhase, Turn currentTurn) : GameEvent
    {
        public Turn Turn { get; } = currentTurn;
        public Phase Phase { get; } = nextPhase;

        public override void Happen(IGame game)
        {
            Turn.Phases.Add(Phase);
            Turn.StartCurrentPhase(game);
        }

        public override string ToString()
        {
            return $"{Turn}: {ToString(Phase.Type)} begun.";
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
                _ => throw new System.InvalidOperationException(),
            };
        }
    }
}
