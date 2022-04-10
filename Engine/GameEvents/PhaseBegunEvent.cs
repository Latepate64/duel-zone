using Engine.Steps;

namespace Engine.GameEvents
{
    class PhaseBegunEvent : GameEvent
    {
        private readonly ITurn _currentTurn;
        private readonly IPhase _nextPhase;

        public PhaseBegunEvent(IPhase nextPhase, ITurn currentTurn)
        {
            _nextPhase = nextPhase;
            _currentTurn = currentTurn;
        }

        public override void Happen(IGame game)
        {
            _currentTurn.Phases.Add(_nextPhase);
            _currentTurn.StartCurrentPhase(game);
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
