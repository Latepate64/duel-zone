﻿using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YouMayDestroyOneOfYourOpponentsCreaturesEffect : DestroyEffect
    {
        public YouMayDestroyOneOfYourOpponentsCreaturesEffect() : base(0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyOneOfYourOpponentsCreaturesEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your opponent's creatures.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id);
        }
    }
}
