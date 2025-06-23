using OneShotEffects;

namespace Cards.DM01
{
    sealed class UltimateForce : Spell
    {
        public UltimateForce() : base("Ultimate Force", 5, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new PutTopTwoCardOfDeckIntoManaZoneEffect());
        }
    }
}
