using Engine;
using Engine.Steps;
using System;
using System.Linq;

namespace Cards.Conditions
{
    class AttackingCreatureCondition : Condition
    {
        public AttackingCreatureCondition(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Game game, Guid player)
        {
            return game.CurrentTurn.CurrentPhase is AttackPhase phase && game.GetAllCards().Any(card => Filter.Applies(card, game, game.GetPlayer(player)) && phase.AttackingCreature == card.Id);
        }

        public override string ToString()
        {
            return $"{Filter} is attacking";
        }
    }
}
