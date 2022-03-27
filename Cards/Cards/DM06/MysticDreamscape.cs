using Common;

namespace Cards.Cards.DM06
{
    class MysticDreamscape : Spell
    {
        public MysticDreamscape() : base("Mystic Dreamscape", 4, Civilization.Water)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.ReturnUpToCardsFromYourManaZoneToYourHandEffect(3));
        }
    }
}
