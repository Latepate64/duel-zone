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
        public CardFilter Filter { get; }

        public CardMovingEffect(ZoneType source, ZoneType destination, int minimum, int maximum, bool controllerChooses, CardFilter filter)
        {
            SourceZone = source;
            DestinationZone = destination;
            Minimum = minimum;
            Maximum = maximum;
            ControllerChooses = controllerChooses;
            Filter = filter;
        }

        public CardMovingEffect(CardMovingEffect effect)
        {
            SourceZone = effect.SourceZone;
            DestinationZone = effect.DestinationZone;
            Minimum = effect.Minimum;
            Maximum = effect.Maximum;
            Filter = effect.Filter;
            ControllerChooses = effect.ControllerChooses;
        }

        public override void Apply(Game game, Ability source)
        {
            var cards = game.GetAllCards().Where(card => Filter.Applies(card, game, source.Owner));
            if (cards.Any())
            {
                if (Minimum >= cards.Count())
                {
                    game.Move(cards, SourceZone, DestinationZone);
                }
                else
                {
                    var player = game.GetPlayer(ControllerChooses ? source.Owner : game.GetOpponent(source.Owner));
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
