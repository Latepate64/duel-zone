using Interfaces;

namespace GameEvents.Steps
{
    public interface ITurnBasedActionable
    {
        void PerformTurnBasedAction(IGame game);
    }
}