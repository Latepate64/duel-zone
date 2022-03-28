using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class UltimateForce : Spell
    {
        public UltimateForce() : base("Ultimate Force", 5, Common.Civilization.Nature)
        {
            AddSpellAbilities(new PutTopCardsOfDeckIntoManaZoneEffect(2));
        }
    }
}
