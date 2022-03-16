using Engine;
using System;
using System.Linq;

namespace Cards.Conditions
{
    class TappedCondition : Condition
    {
        public TappedCondition(CardFilter filter) : base(filter)
        {
        }

        public TappedCondition(TappedCondition condition) : base(condition)
        {
        }

        public override bool Applies(Game game, Guid player)
        {
            return game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(player))).All(x => x.Tapped);
        }

        public override Condition Copy()
        {
            return new TappedCondition(this);
        }

        public override string ToString()
        {
            return $"While {Filter} is tapped";
        }
    }
}
