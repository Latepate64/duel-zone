﻿using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.OneShotEffects
{
    class RothusTheTravelerEffect : OneShotEffect
    {
        public RothusTheTravelerEffect()
        {
        }

        public override void Apply(Game game, Ability source)
        {
            // Destroy one of your creatures. Then your opponent chooses one of his creatures and destroys it.
            new DestroyEffect(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true).Apply(game, source);
            new DestroyEffect(new CardFilters.OpponentsBattleZoneCreatureFilter(), 1, 1, false).Apply(game, source);
        }

        public override OneShotEffect Copy()
        {
            return new RothusTheTravelerEffect();
        }
    }
}