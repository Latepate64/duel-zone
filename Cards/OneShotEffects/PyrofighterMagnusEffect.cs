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
            // Return this creature to your hand.
            game.Move(game.GetCard(source.Source), ZoneType.BattleZone, ZoneType.Hand);
        }
    }
}
