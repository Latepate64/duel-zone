using Engine;
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

        public override bool CheckInterveningIfClause()
        {
            // if this creature broke any shields that turn
            return Game.CurrentTurn.GameEvents.OfType<CreatureBreaksShieldsEvent>().Any(x => x.Attacker == Source);
        }
    }

    class HeartyCapnPolligonEffect : OneShotEffect
    {
        public HeartyCapnPolligonEffect()
        {
        }

        public HeartyCapnPolligonEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new HeartyCapnPolligonEffect(this);
        }

        public override void Apply()
        {
            Game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, Source);
        }

        public override string ToString()
        {
            return "Return it to your hand.";
        }
    }
}
