using Engine.Steps;

namespace Engine.GameEvents
{
    public class PhaseBegunEvent : GameEvent
    {
        public ITurn Turn { get; }
        public IPhase Phase { get; }

        public PhaseBegunEvent(IPhase nextPhase, ITurn currentTurn)
        {
            Phase = nextPhase;
            Turn = currentTurn;
        }

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
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}
