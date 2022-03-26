using Common;

namespace Cards.Cards.DM03
{
    class BoomerangComet : Charger
    {
        public BoomerangComet() : base("Boomerang Comet", 6, Civilization.Light)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.ReturnCardsFromYourManaZoneToYourHandEffect(1));
        }
    }
}
