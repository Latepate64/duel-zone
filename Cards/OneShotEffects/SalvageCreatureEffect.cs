namespace Cards.OneShotEffects
{
    abstract class SalvageCreatureEffect : SalvageEffect
    {
        protected SalvageCreatureEffect(int minimum, int maximum) : base(new CardFilters.OwnersGraveyardCreatureFilter(), minimum, maximum, true)
        {
        }
    }
}
