using Common;

namespace Cards.Cards.DM06
{
    class FaerieLife : Spell
    {
        public FaerieLife() : base("Faerie Life", 2, Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1));
        }
    }
}
