﻿using Engine;
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

        public override object Apply(IGame game, IAbility source)
        {
            game.Move(source, ZoneType.BattleZone, ZoneType.Hand, game.GetCard(source.Source));
            return null;
        }

        public override string ToString()
        {
            return "Return this creature to your hand.";
        }
    }
}
