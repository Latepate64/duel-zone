﻿using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureHasBlockerEffect : ContinuousEffect, IBlockerEffect
    {
        public ThisCreatureHasBlockerEffect() : base()
        {
        }

        public bool Applies(ICard blocker, ICard attacker, IGame game)
        {
            return IsSourceOfAbility(blocker, game);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureHasBlockerEffect();
        }

        public override string ToString()
        {
            return "Blocker";
        }
    }
}
