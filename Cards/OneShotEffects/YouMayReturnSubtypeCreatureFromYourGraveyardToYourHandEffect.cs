﻿using Common;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect : SalvageEffect
    {
        private readonly Subtype _subtype;

        public YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(Subtype subtype, int maximum = 1) : base(new CardFilters.OwnersGraveyardSubtypeCreatureFilter(subtype), 0, maximum, true)
        {
            _subtype = subtype;
        }

        public YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(this);
        }

        public override string ToString()
        {
            return Maximum == 1 ? 
                $"You may return a {_subtype} from your graveyard to your hand." : 
                $"Return up to {Maximum} {_subtype}s from your graveyard to your hand.";
        }
    }
}
