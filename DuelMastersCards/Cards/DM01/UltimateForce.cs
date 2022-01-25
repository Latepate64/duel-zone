using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
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
