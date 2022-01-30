using Cards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace Cards.Cards.DM01
{
    class UltimateForce : Spell
    {
        public UltimateForce() : base("Ultimate Force", 5, Civilization.Nature)
        {
            // Put the top 2 cards of your deck into your mana zone.
            Abilities.Add(new SpellAbility(new PutTopCardsOfDeckIntoManaZoneEffect(2)));
        }
    }
}
