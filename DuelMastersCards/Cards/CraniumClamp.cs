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
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(ZoneType.Hand, ZoneType.Graveyard, new OpponentsHandCardFilter(), 2, 2, false)));
        }
    }
}
