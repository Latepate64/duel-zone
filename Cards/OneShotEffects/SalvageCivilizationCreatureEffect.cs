namespace Cards.OneShotEffects
{
    class SalvageCivilizationCreatureEffect : SalvageEffect
    {
        public SalvageCivilizationCreatureEffect(int minimum, int maximum, params Common.Civilization[] civilizations) : base(new CardFilters.OwnersGraveyardCivilizationCreatureFilter(civilizations), minimum, maximum, true)
        {
        }
    }
}