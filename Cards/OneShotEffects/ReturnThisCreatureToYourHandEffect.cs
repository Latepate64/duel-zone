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

        public override IOneShotEffect Copy()
        {
            return new ReturnThisCreatureToYourHandEffect(this);
        }

        public override void Apply()
        {
            Game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, Source);
        }

        public override string ToString()
        {
            return "Return this creature to your hand.";
        }
    }
}
