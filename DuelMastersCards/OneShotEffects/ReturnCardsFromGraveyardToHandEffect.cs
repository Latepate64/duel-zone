﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class ReturnCardsFromGraveyardToHandEffect : OneShotEffect
    {
        public int Maximum { get; }
        CardFilter Filter { get; }

        public ReturnCardsFromGraveyardToHandEffect(int maximum, CardFilter filter)
        {
            Maximum = maximum;
            Filter = filter;
        }

        public ReturnCardsFromGraveyardToHandEffect(ReturnCardsFromGraveyardToHandEffect effect) : base(effect)
        {
            Maximum = effect.Maximum;
            Filter = effect.Filter;
        }

        public override OneShotEffect Copy()
        {
            return new ReturnCardsFromGraveyardToHandEffect(this);
        }

        public override void Apply(Game game)
        {
            var player = game.GetPlayer(Controller);
            var cards = player.Graveyard.Cards.Where(x => Filter.Applies(x, game));
            if (cards.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, cards, 0, Maximum));
                game.Move(decision.Decision.Select(x => game.GetCard(x)), DuelMastersModels.Zones.ZoneType.Graveyard, DuelMastersModels.Zones.ZoneType.Hand);
            }
        }
    }
}
