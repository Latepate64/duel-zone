using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OpponentsBattleZoneChoosableMaxPowerCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter
    {
        public int Power { get; }

        public OpponentsBattleZoneChoosableMaxPowerCreatureFilter(int power)
        {
            Power = power;
        }

        public OpponentsBattleZoneChoosableMaxPowerCreatureFilter(OpponentsBattleZoneChoosableMaxPowerCreatureFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && game.GetPower(card) <= Power;
        }
    }
}
