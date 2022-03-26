using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ReturnCreatureFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnCreatureFromYourManaZoneToYourHandEffect() : base(1, 1, true, new CardFilters.OwnersManaZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnCreatureFromYourManaZoneToYourHandEffect();
        }

        public override string ToString()
        {
            return "Return a creature from your mana zone to your hand.";
        }
    }
}
