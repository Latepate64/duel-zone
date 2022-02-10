using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    public class PyrofighterMagnusEffect : OneShotEffect
    {
        public PyrofighterMagnusEffect() : base()
        {
        }

        public PyrofighterMagnusEffect(PyrofighterMagnusEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new PyrofighterMagnusEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Hand, game.GetCard(source.Source));
        }

        public override string ToString()
        {
            return "Return this creature to your hand.";
        }
    }
}
