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

        public override void Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                var cards = duel.GetPlayer(Controller).Graveyard.Cards.Where(x => Filter.Applies(x, duel));
                if (cards.Any())
                {
                    duel.SetAwaitingChoice(new GuidSelection(Controller, cards, 0, 1)); //TODO: min and max could be different
                }
            }
            else
            {
                duel.Move((decision as GuidDecision).Decision.Select(x => duel.GetCard(x)), DuelMastersModels.Zones.ZoneType.Graveyard, DuelMastersModels.Zones.ZoneType.ManaZone);
            }
        }
    }
}
