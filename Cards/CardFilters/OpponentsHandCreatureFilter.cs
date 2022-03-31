using Engine;

namespace Cards.CardFilters
{
    class OpponentsHandCreatureFilter : OpponentsHandCardFilter
    {
        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.CardType == Common.CardType.Creature;
        }

        public override CardFilter Copy()
        {
            return new OpponentsHandCreatureFilter();
        }

        public override string ToString()
        {
            return "a creature in his hand";
        }
    }
}