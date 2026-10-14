using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class UltimateForce : Spell
{
    public UltimateForce() : base("Ultimate Force", 5, Civilization.Nature)
    {
        AddSpellAbilities(
            new PutTopCardsOfDeckIntoManaZoneEffect(2));
    }
}