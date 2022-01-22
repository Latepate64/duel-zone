using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    public class CreaturesWithPowerFilter : CardFilter
    {
        public int Power { get; }

        public CreaturesWithPowerFilter(int power)
        {
            Power = power;
        }

        public CreaturesWithPowerFilter(CreaturesWithPowerFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return card.CardType == CardType.Creature && game.GetPower(card) == Power;
        }

        public override CardFilter Copy()
        {
            return new CreaturesWithPowerFilter(this);
        }
    }
}
