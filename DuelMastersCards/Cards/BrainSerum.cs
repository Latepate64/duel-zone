using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    class BrainSerum : Spell
    {
        public BrainSerum() : base("Brain Serum", 4, Civilization.Water)
        {
            ShieldTrigger = true;

            // Draw up to 2 cards.
            Abilities.Add(new SpellAbility(new ControllerMayDrawCardsEffect(2)));
        }
    }
}
