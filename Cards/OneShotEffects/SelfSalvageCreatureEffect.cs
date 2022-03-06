namespace Cards.OneShotEffects
{
    class SelfSalvageCreatureEffect : SalvageEffect
    {
        public SelfSalvageCreatureEffect(int minimum, int maximum) : base(new CardFilters.OwnersGraveyardCardFilter { CardType = Common.CardType.Creature }, minimum, maximum, true)
        {
        }
    }
}
