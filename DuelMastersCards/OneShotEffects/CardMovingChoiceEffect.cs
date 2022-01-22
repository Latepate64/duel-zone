using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.Zones;
using System;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class CardMovingChoiceEffect : CardMovingEffect
    {
        public int Minimum { get; }
        public int Maximum { get; }
        public bool ControllerChooses { get; }

        public CardMovingChoiceEffect(ZoneType source, ZoneType destination, CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(source, destination, filter)
        {
            Minimum = minimum;
            Maximum = maximum;
            ControllerChooses = controllerChooses;
        }

        public CardMovingChoiceEffect(CardMovingChoiceEffect effect) : base(effect)
        {
            Minimum = effect.Minimum;
            Maximum = effect.Maximum;
            ControllerChooses = effect.ControllerChooses;
        }

        public override void Apply(Game game, Ability source)
        {
            var cards = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(source.Owner)));
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
            return new CardMovingChoiceEffect(this);
        }
    }
}
