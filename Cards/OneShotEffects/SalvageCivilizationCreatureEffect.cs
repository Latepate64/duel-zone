namespace Cards.OneShotEffects
{
    abstract class SalvageCivilizationCreatureEffect : SalvageEffect
    {
        protected SalvageCivilizationCreatureEffect(int minimum, int maximum) : base(minimum, maximum, true)
        {
        }
    }
}