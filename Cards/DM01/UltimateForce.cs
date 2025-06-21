using OneShotEffects;

namespace Cards.DM01
{
    class UltimateForce : Engine.Spell
    {
        public UltimateForce() : base("Ultimate Force", 5, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new PutTopTwoCardOfDeckIntoManaZoneEffect());
        }
    }
}
