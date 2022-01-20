﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.OneShotEffects
{
    public class ControllerMayDrawCardsEffect : OneShotEffect
    {
        public int Maximum { get; }

        private int _drawn;

        public ControllerMayDrawCardsEffect(int maximum) : base()
        {
            Maximum = maximum;
        }

        public ControllerMayDrawCardsEffect(ControllerMayDrawCardsEffect effect) : base(effect)
        {
            Maximum = effect.Maximum;
        }

        public override OneShotEffect Copy()
        {
            return new ControllerMayDrawCardsEffect(this);
        }

        public override void Apply(Game game)
        {
            var player = game.GetPlayer(Controller);
            var decision = player.Choose(new YesNoChoice(Controller));
            if (decision.Decision)
            {
                player.DrawCards(1, game);
                if (++_drawn < Maximum)
                {
                    Apply(game);
                }
            }
        }
    }
}
