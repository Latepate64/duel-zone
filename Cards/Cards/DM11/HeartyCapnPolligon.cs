using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class HeartyCapnPolligon : Creature
    {
        public HeartyCapnPolligon() : base("Hearty Cap'n Polligon", 1, 2000, Common.Subtype.SnowFaerie, Common.Civilization.Nature)
        {
            // At the end of each of your turns, if this creature broke any shields that turn, return it to your hand.
            AddAbilities(new HeartyCapnPolligonAbility(new HeartyCapnPolligonEffect()));
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
