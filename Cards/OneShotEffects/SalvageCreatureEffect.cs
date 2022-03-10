namespace Cards.OneShotEffects
{
    class SalvageCreatureEffect : SalvageEffect
    {
        public SalvageCreatureEffect(int minimum, int maximum, params Common.Civilization[] civilizations) : base(new CardFilters.OwnersGraveyardCardFilter(civilizations) { CardType = Common.CardType.Creature }, minimum, maximum, true)
        {
        }
    }
}
