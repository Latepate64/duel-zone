﻿using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using System.Linq;

namespace Cards.TriggeredAbilities
{
    class HeartyCapnPolligonAbility : AtTheEndOfYourTurnAbility
    {
        public HeartyCapnPolligonAbility() : base(new HeartyCapnPolligonEffect())
        {
        }

        public override bool CheckInterveningIfClause(IGame game)
        {
            // if this creature broke any shields that turn
            return game.CurrentTurn.GameEvents.OfType<CreatureBreaksShieldsEvent>().Any(x => x.Attacker.Id == Source);
        }
    }

    class HeartyCapnPolligonEffect : OneShotEffect
    {
        public override IOneShotEffect Copy()
        {
            return new HeartyCapnPolligonEffect();
        }

        public override void Apply(IGame game)
        {
            game.Move(Source, ZoneType.BattleZone, ZoneType.Hand, game.GetCard(Source.Source));
        }

        public override string ToString()
        {
            return "Return it to your hand.";
        }
    }
}
