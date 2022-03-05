﻿using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    public class GhastlyDrainEffect : ChooseAnyNumberOfCardsEffect
    {
        public GhastlyDrainEffect() : base(new CardFilters.OwnersShieldZoneCardFilter())
        {
        }

        public GhastlyDrainEffect(GhastlyDrainEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new GhastlyDrainEffect(this);
        }

        public override string ToString()
        {
            return "Choose any number of your shields and put them into your hand. You can't use the \"shield trigger\" abilities of those shields.";
        }

        protected override void Apply(Game game, Ability source, params Card[] cards)
        {
            game.PutFromShieldZoneToHand(cards, false);
        }
    }
}