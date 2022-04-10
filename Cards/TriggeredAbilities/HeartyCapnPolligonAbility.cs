using Common;
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

        public override bool CheckInterveningIfClause(IGame game)
        {
            // if this creature broke any shields that turn
            throw new System.NotImplementedException();
            //return game.CurrentTurn.Phases.SelectMany(x => x.GameEvents).OfType<ShieldsBrokenEvent>().Any(x => x.Attacker.Id == Source);
        }
    }

    class HeartyCapnPolligonEffect : OneShotEffect
    {
        public override IOneShotEffect Copy()
        {
            return new HeartyCapnPolligonEffect();
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Hand, game.GetCard(source.Source));
            return null;
        }

        public override string ToString()
        {
            return "Return it to your hand.";
        }
    }
}
