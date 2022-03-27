using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayReturnSpellFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
    {
        public YouMayReturnSpellFromYourManaZoneToYourHandEffect() : base(0, 1, true, new CardFilters.OwnersManaZoneSpellFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayReturnSpellFromYourManaZoneToYourHandEffect();
        }

        public override string ToString()
        {
            return "You may return a spell from your mana zone to your hand.";
        }
    }
}
