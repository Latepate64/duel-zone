using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class FaerieLife : Spell
{
    public FaerieLife() : base("Faerie Life", 2, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new PutTopCardsOfDeckIntoManaZoneEffect(1));
    }
}