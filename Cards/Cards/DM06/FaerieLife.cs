using Common;

namespace Cards.Cards.DM06
{
    class FaerieLife : Spell
    {
        public FaerieLife() : base("Faerie Life", 2, Civilization.Nature)
        {
            ShieldTrigger = true;
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1)));
        }
    }
}
