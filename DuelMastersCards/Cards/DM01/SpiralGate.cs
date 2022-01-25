using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    class SpiralGate : Spell
    {
        public SpiralGate() : base("Spiral Gate", 2, Civilization.Water)
        {
            ShieldTrigger = true;

            // Choose 1 creature in the battle zone and return it to its owner's hand.
            Abilities.Add(new SpellAbility(new BounceEffect(1, 1)));
        }
    }
}
