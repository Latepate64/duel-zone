namespace Cards.OneShotEffects
{
    class SalvageCreatureEffect : SalvageEffect
    {
        public SalvageCreatureEffect(int minimum, int maximum) : base(new CardFilters.OwnersGraveyardCreatureFilter(), minimum, maximum, true)
        {
        }
    }
}
