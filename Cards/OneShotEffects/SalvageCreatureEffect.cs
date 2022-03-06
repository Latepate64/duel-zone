namespace Cards.OneShotEffects
{
    class SalvageCreatureEffect : SalvageEffect
    {
        public SalvageCreatureEffect(int minimum, int maximum) : base(new CardFilters.OwnersGraveyardCardFilter { CardType = Common.CardType.Creature }, minimum, maximum, true)
        {
        }
    }
}
