using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class CraniumClamp : Spell
    {
        public CraniumClamp() : base("Cranium Clamp", 4, Civilization.Darkness)
        {
            // Your opponent chooses and discards 2 cards from his hand.
            Abilities.Add(new SpellAbility(new CardMovingEffect(ZoneType.Hand, ZoneType.Graveyard, 2, 2, false, new OwnerZoneFilter(false, ZoneType.Hand))));
        }
    }
}
