using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class CardMovingEffect : OneShotEffect
    {
        public ZoneType SourceZone { get; }
        public ZoneType DestinationZone { get; }
        public int Minimum { get; }
        public int Maximum { get; }
        public bool ControllerChooses { get; }
        public ICollection<CardFilter> Filters { get; }

        public CardMovingEffect(ZoneType source, ZoneType destination, int minimum, int maximum, bool controllerChooses, params CardFilter[] cardFilters)
        {
            SourceZone = source;
            DestinationZone = destination;
            Minimum = minimum;
            Maximum = maximum;
            ControllerChooses = controllerChooses;
            Filters = cardFilters;
        }

        public CardMovingEffect(CardMovingEffect effect) : base(effect)
        {
            SourceZone = effect.SourceZone;
            DestinationZone = effect.DestinationZone;
            Minimum = effect.Minimum;
            Maximum = effect.Maximum;
            Filters = effect.Filters;
            foreach (var filter in Filters)
            {
                filter.Owner = Controller;
            }
            ControllerChooses = effect.ControllerChooses;
        }

        public override void Apply(Game game)
        {
            var cards = game.GetAllCards().Where(card => Filters.All(f => f.Applies(card, game)));
            if (cards.Any())
            {
                if (Minimum >= cards.Count())
                {
                    game.Move(cards, SourceZone, DestinationZone);
                }
                else
                {
                    var player = game.GetPlayer(ControllerChooses ? Controller : game.GetOpponent(Controller));
                    if (player != null)
                    {
                        var selectedCards = player.Choose(new GuidSelection(player.Id, cards.Select(x => x.Id), Minimum, Math.Min(Maximum, cards.Count()))).Decision.Select(x => game.GetCard(x));
                        game.Move(selectedCards, SourceZone, DestinationZone);
                    }
                }

            }
        }

        public override OneShotEffect Copy()
        {
            return new CardMovingEffect(this);
        }
    }
}
