using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using System;

namespace Cards.TriggeredAbilities
{
    public class AtTheEndOfTurnAbility : TriggeredAbility
    {
        public Guid Turn { get; }

        public AtTheEndOfTurnAbility(Guid turn, OneShotEffect effect) : base(effect)
        {
            Turn = turn;
        }

        public AtTheEndOfTurnAbility(AtTheEndOfTurnAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            throw new System.NotImplementedException();
            //return gameEvent is PhaseBegunEvent e && e.PhaseOrStep == PhaseOrStep.EndOfTurn && e.Turn.Id == Turn && CheckInterveningIfClause(game);
        }

        public override Ability Copy()
        {
            return new AtTheEndOfTurnAbility(this);
        }

        public override string ToString()
        {
            return $"At the end of that turn, {GetEffectText()}";
        }
    }
}
