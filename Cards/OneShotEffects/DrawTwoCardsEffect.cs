﻿using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DrawTwoCardsEffect : OneShotEffect
    {
        public DrawTwoCardsEffect()
        {
        }

        public DrawTwoCardsEffect(DrawTwoCardsEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            Applier.DrawCards(2, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new DrawTwoCardsEffect(this);
        }

        public override string ToString()
        {
            return "Draw 2 cards.";
        }
    }

    class DrawCardEffect : OneShotEffect
    {
        public DrawCardEffect()
        {
        }

        public DrawCardEffect(DrawCardEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            Applier.DrawCards(1, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new DrawCardEffect(this);
        }

        public override string ToString()
        {
            return "Draw a card.";
        }
    }
}