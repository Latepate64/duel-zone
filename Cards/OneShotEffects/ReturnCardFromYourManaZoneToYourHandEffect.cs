using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ReturnCardFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnCardFromYourManaZoneToYourHandEffect() : base(1, 1, true, new CardFilters.OwnersManaZoneCardFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnCardFromYourManaZoneToYourHandEffect();
        }

        public override string ToString()
        {
            return "Return a card from your mana zone to your hand.";
        }
    }
}
