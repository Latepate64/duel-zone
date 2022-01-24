using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    class DarkReversal : Spell
    {
        public DarkReversal() : base("Dark Reversal", 2, Civilization.Darkness)
        {
            ShieldTrigger = true;

            // Return a creature from your graveyard to your hand.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(new OwnersGraveyardCreatureFilter(), 1, 1, true, ZoneType.Graveyard, ZoneType.Hand)));
        }
    }
}
