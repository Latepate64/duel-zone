using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    class DarkReversal : Spell
    {
        public DarkReversal() : base("Dark Reversal", 2, Civilization.Darkness)
        {
            ShieldTrigger = true;

            // Return a creature from your graveyard to your hand.
            Abilities.Add(new SpellAbility(new SalvageEffect(new OwnersGraveyardCreatureFilter(), 1, 1, true)));
        }
    }
}
