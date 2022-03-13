using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ReturnThisCreatureToYourHandEffect : OneShotEffect
    {
        public ReturnThisCreatureToYourHandEffect() : base()
        {
        }

        public ReturnThisCreatureToYourHandEffect(ReturnThisCreatureToYourHandEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ReturnThisCreatureToYourHandEffect(this);
        }

        public override object Apply(Game game, Ability source)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Hand, game.GetCard(source.Source));
            return null;
        }

        public override string ToString()
        {
            return "Return this creature to your hand.";
        }
    }
}
