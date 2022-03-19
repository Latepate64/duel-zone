using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableNonEvolutionCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter
    {
        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.IsEvolutionCreature;
        }

        public override string ToString()
        {
            return $"non-evolution {base.ToString()}";
        }
    }
}