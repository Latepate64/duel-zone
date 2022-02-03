using Common;
using Engine;
using Engine.Steps;
using System.Linq;

namespace Cards.CardFilters
{
    class ArmoredWalkerUrherionFilter : TargetFilter
    {
        public Subtype Race { get; }

        public ArmoredWalkerUrherionFilter(Subtype race)
        {
            Race = race;
        }

        public ArmoredWalkerUrherionFilter(ArmoredWalkerUrherionFilter filter) : base(filter)
        {
            Race = filter.Race;
        }

        public override bool Applies(Engine.Card card, Game game, Player player)
        {
            // While you have at least 1 Human in the battle zone, this creature gets +2000 power during its attacks.
            return base.Applies(card, game, player) && game.BattleZone.GetCreatures(player.Id).Any(x => x.Subtypes.Contains(Race)) && game.CurrentTurn.CurrentPhase is AttackPhase phase && phase.AttackingCreature == card.Id;
        }

        public override CardFilter Copy()
        {
            return new ArmoredWalkerUrherionFilter(this);
        }
    }
}
