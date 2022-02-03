using Common;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class HeartyCapnPolligonEffect : OneShotEffect
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
            // At the end of each of your turns, if this creature broke any shields that turn, return it to your hand.
            game.Move(game.GetCard(source.Source), ZoneType.BattleZone, ZoneType.Hand);
        }
    }
}
