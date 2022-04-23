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

        public override bool CheckInterveningIfClause(IGame game)
        {
            // if this creature broke any shields that turn
            return game.CurrentTurn.GameEvents.OfType<CreatureBreaksShieldsEvent>().Any(x => x.Attacker == SourceCard);
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

        public override void Apply(IGame game)
        {
            game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, Ability.SourceCard);
        }

        public override string ToString()
        {
            return "Return it to your hand.";
        }
    }
}
