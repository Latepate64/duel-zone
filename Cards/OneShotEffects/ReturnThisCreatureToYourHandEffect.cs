using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    public class ReturnThisCreatureToYourHandEffect : OneShotEffect
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
