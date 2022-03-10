using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.TriggeredAbilities
{
    class HeartyCapnPolligonAbility : AtTheEndOfYourTurnAbility
    {
        public HeartyCapnPolligonAbility() : base(new HeartyCapnPolligonEffect())
        {
        }

        public override bool CheckInterveningIfClause(Game game)
        {
            // if this creature broke any shields that turn
            return game.CurrentTurn.Phases.SelectMany(x => x.GameEvents).OfType<ShieldsBrokenEvent>().Any(x => x.Attacker.Id == Source);
        }
    }

    class HeartyCapnPolligonEffect : OneShotEffect
    {
        public override OneShotEffect Copy()
        {
            return new HeartyCapnPolligonEffect();
        }

        public override void Apply(Game game, Ability source)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Hand, game.GetCard(source.Source));
        }

        public override string ToString()
        {
            return "If this creature broke any shields that turn, return it to your hand.";
        }
    }
}
