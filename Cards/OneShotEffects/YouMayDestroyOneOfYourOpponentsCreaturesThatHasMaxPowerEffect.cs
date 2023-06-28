﻿using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect : DestroyEffect, IPowerable
    {

        public YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(int power) : base(0, 1, true)
        {
            Power = power;
        }

        public int Power { get; }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(this);
        }

        public override string ToString()
        {
            return $"You may destroy one of your opponent's creatures that has power {Power} or less.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier).Where(x => x.Power <= Power);
        }
    }
}
