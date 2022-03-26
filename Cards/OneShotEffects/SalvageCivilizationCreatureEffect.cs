namespace Cards.OneShotEffects
{
    abstract class SalvageCivilizationCreatureEffect : SalvageEffect
    {
        protected SalvageCivilizationCreatureEffect(int minimum, int maximum, params Common.Civilization[] civilizations) : base(new CardFilters.OwnersGraveyardCivilizationCreatureFilter(civilizations), minimum, maximum, true)
        {
        }
    }
}