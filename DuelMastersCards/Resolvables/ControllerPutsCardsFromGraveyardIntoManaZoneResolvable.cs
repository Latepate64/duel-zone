using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class ControllerPutsCardsFromGraveyardIntoManaZoneResolvable : Resolvable
    {
        public CardFilter Filter { get; }

        public ControllerPutsCardsFromGraveyardIntoManaZoneResolvable(CardFilter filter)
        {
            Filter = filter;
        }

        public ControllerPutsCardsFromGraveyardIntoManaZoneResolvable(ControllerPutsCardsFromGraveyardIntoManaZoneResolvable resolvable) : base(resolvable)
        {
            Filter = resolvable.Filter;
        }

        public override Resolvable Copy()
        {
            return new ControllerPutsCardsFromGraveyardIntoManaZoneResolvable(this);
        }

        public override void Resolve(Duel duel)
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
