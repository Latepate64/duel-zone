using DuelMastersModels;
using DuelMastersModels.Steps;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    class ArmoredWalkerUrherionFilter : TargetFilter
    {
        public ArmoredWalkerUrherionFilter()
        {
        }

        public ArmoredWalkerUrherionFilter(ArmoredWalkerUrherionFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            // While you have at least 1 Human in the battle zone, this creature gets +2000 power during its attacks.
            return base.Applies(card, game, player) && game.BattleZone.GetCreatures(player.Id).Any(x => x.Subtypes.Contains(Subtype.Human)) && game.CurrentTurn.CurrentStep is AttackingCreatureStep step && step.AttackingCreature == card.Id;
        }

        public override CardFilter Copy()
        {
            return new ArmoredWalkerUrherionFilter(this);
        }
    }
}
