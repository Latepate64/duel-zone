using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM01
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
