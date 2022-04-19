﻿using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class TapAreaOfEffect : OneShotEffect
    {
        protected TapAreaOfEffect()
        {
        }

        public override void Apply(IGame game, IAbility source)
        {
            var cards = GetAffectedCards(game, source).ToArray();
            source.GetController(game).Tap(game, cards);
        }

        protected abstract IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source);
    }
}
