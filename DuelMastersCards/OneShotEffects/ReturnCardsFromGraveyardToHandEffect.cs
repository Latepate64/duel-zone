using DuelMastersModels;
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

        public override void Apply(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var cards = player.Graveyard.Cards.Where(x => Filter.Applies(x, duel));
            if (cards.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, cards, 0, Maximum));
                duel.Move(decision.Decision.Select(x => duel.GetCard(x)), DuelMastersModels.Zones.ZoneType.Graveyard, DuelMastersModels.Zones.ZoneType.Hand);
            }
        }
    }
}
