using Common;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class HeartyCapnPolligonEffect : OneShotEffect
    {
        public HeartyCapnPolligonEffect() : base()
        {
        }

        public HeartyCapnPolligonEffect(HeartyCapnPolligonEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new HeartyCapnPolligonEffect(this);
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
