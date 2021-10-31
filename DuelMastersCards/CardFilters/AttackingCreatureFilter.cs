using DuelMastersModels;
using DuelMastersModels.Steps;

namespace DuelMastersCards.CardFilters
{
    public class AttackingCreatureFilter : CardFilter
    {
        public AttackingCreatureFilter()
        {
        }

        public AttackingCreatureFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Duel duel)
        {
            return duel.CurrentTurn.CurrentStep is AttackingCreatureStep step && step.AttackingCreature == card.Id;
        }

        public override CardFilter Copy()
        {
            return new AttackingCreatureFilter(this);
        }
    }
}
