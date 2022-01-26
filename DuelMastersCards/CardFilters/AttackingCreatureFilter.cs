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

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && game.CurrentTurn.CurrentPhase is AttackPhase phase && phase.AttackingCreature == card.Id;
        }

        public override CardFilter Copy()
        {
            return new AttackingCreatureFilter(this);
        }
    }
}
