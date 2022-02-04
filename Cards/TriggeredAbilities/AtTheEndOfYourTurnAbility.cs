﻿using Common.GameEvents;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.TriggeredAbilities
{
    public class AtTheEndOfYourTurnAbility : TriggeredAbility
    {
        public AtTheEndOfYourTurnAbility(OneShotEffect effect) : base(effect)
        {
        }

        public AtTheEndOfYourTurnAbility(AtTheEndOfYourTurnAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            return gameEvent is PhaseBegunEvent e && e.PhaseOrStep == PhaseOrStep.EndOfTurn && game.Turns.Single(x => x.Id == e.Turn.Id).ActivePlayer.Id == Owner && CheckInterveningIfClause(game);
        }

        public override Ability Copy()
        {
            return new AtTheEndOfYourTurnAbility(this);
        }
    }
}
