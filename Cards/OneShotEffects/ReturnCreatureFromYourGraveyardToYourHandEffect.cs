﻿using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ReturnCreatureFromYourGraveyardToYourHandEffect : SalvageCreatureEffect
    {
        public ReturnCreatureFromYourGraveyardToYourHandEffect() : base(1, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnCreatureFromYourGraveyardToYourHandEffect();
        }

        public override string ToString()
        {
            return "Return a creature from your graveyard to your hand.";
        }
    }
}