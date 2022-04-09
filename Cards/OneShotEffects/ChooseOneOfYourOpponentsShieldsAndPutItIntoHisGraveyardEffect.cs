﻿using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect : ShieldBurnEffect
    {
        public ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect() : base(new CardFilters.OpponentsShieldZoneCardFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's shields and put it into his graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetOpponent(game).ShieldZone.Cards;
        }
    }
}
