using Common.GameEvents;
using Engine;
using System;

namespace Cards.Durations
{
    public class UntilStartOfYourNextTurn : Duration
    {
        private readonly Guid _player;

        public UntilStartOfYourNextTurn(UntilStartOfYourNextTurn duration)
        {
            _player = duration._player;
        }

        public UntilStartOfYourNextTurn(Guid player)
        {
            _player = player;
        }

        public override IDuration Copy()
        {
            return new UntilStartOfYourNextTurn(this);
        }

        public override bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.StartOfTurn && phase.Turn.ActivePlayerId == _player;
        }

        public override string ToString()
        {
            return "Until the start of your next turn";
        }
    }
}
