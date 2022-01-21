using DuelMastersModels;
using System;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    public class ChoosableCreaturesFilter : CardFilter
    {
        public ChoosableCreaturesFilter()
        {
        }

        public ChoosableCreaturesFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game)
        {
            var owner = game.GetPlayer(Owner);
            var ownerApplies = game.BattleZone.Creatures.Where(x => x.Owner == Owner).Select(x => x.Id).Contains(card.Id);
            var opponent = game.GetOpponent(owner);
            if (opponent != null)
            {
                return game.BattleZone.Creatures.Where(x => x.Owner == opponent.Id).Select(x => x.Id).Contains(card.Id) || ownerApplies;
            }
            else
            {
                return ownerApplies;
            }
        }

        public override CardFilter Copy()
        {
            return new OpponentsChoosableCreaturesFilter(this);
        }
    }
}
