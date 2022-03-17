using Cards.CardFilters;

namespace Cards.OneShotEffects
{
    class SelfManaBurnEffect : ManaBurnEffect
    {
        public SelfManaBurnEffect(int minimum, int maximum) : base(new ManaBurnEffect(new OwnersManaZoneCardFilter(), minimum, maximum, true))
        {
        }

        public SelfManaBurnEffect(int amount) : this(amount, amount) { }
    }
}
