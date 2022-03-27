using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ReturnSpellFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public ReturnSpellFromYourManaZoneToYourHandEffect() : base(1, 1, true, new CardFilters.OwnersManaZoneSpellFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnSpellFromYourManaZoneToYourHandEffect();
        }

        public override string ToString()
        {
            return "Return a spell from your mana zone to your hand.";
        }
    }
}
