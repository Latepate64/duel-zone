namespace Cards.OneShotEffects
{
    abstract class SalvageCreatureEffect : SalvageEffect
    {
        protected SalvageCreatureEffect(int minimum, int maximum) : base(minimum, maximum, true)
        {
        }

        protected SalvageCreatureEffect(SalvageCreatureEffect effect) : base(effect)
        {
        }
    }
}
