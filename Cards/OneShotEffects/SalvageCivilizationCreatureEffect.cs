namespace Cards.OneShotEffects
{
    abstract class SalvageCivilizationCreatureEffect : SalvageEffect
    {
        protected SalvageCivilizationCreatureEffect(SalvageEffect effect) : base(effect)
        {
        }

        protected SalvageCivilizationCreatureEffect(int minimum, int maximum) : base(minimum, maximum, true)
        {
        }
    }
}