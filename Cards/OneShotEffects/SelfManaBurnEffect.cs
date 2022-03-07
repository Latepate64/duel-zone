using Cards.CardFilters;

namespace Cards.OneShotEffects
{
    class SelfManaBurnEffect : ManaBurnEffect
    {
        public SelfManaBurnEffect(int amount) : base(new ManaBurnEffect(new OwnersManaZoneCardFilter(), amount, amount, true))
        {
        }
    }
}
