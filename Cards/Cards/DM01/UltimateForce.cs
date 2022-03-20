using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class UltimateForce : Spell
    {
        public UltimateForce() : base("Ultimate Force", 5, Common.Civilization.Nature)
        {
            // Put the top 2 cards of your deck into your mana zone.
            AddSpellAbilities(new PutTopCardsOfDeckIntoManaZoneEffect(2));
        }
    }
}
