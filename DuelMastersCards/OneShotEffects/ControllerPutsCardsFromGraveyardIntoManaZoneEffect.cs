using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class ControllerPutsCardsFromGraveyardIntoManaZoneEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        public ControllerPutsCardsFromGraveyardIntoManaZoneEffect(CardFilter filter)
        {
            Filter = filter;
        }

        public ControllerPutsCardsFromGraveyardIntoManaZoneEffect(ControllerPutsCardsFromGraveyardIntoManaZoneEffect effect) : base(effect)
        {
            Filter = effect.Filter;
        }

        public override OneShotEffect Copy()
        {
            return new ControllerPutsCardsFromGraveyardIntoManaZoneEffect(this);
        }

        public override void Apply(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var cards = player.Graveyard.Cards.Where(x => Filter.Applies(x, duel));
            if (cards.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, cards, 0, 1)); //TODO: min and max could be different
                duel.Move(decision.Decision.Select(x => duel.GetCard(x)), DuelMastersModels.Zones.ZoneType.Graveyard, DuelMastersModels.Zones.ZoneType.ManaZone);
            }
        }
    }
}
