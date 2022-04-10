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
            throw new System.NotImplementedException();
        }
    }
}
