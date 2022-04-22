using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class UltimateForce : Spell
    {
        public UltimateForce() : base("Ultimate Force", 5, Engine.Civilization.Nature)
        {
            AddSpellAbilities(new PutTopTwoCardOfDeckIntoManaZoneEffect());
        }
    }
}
