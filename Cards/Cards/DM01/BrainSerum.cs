using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class BrainSerum : Spell
    {
        public BrainSerum() : base("Brain Serum", 4, Common.Civilization.Water)
        {
            ShieldTrigger = true;

            // Draw up to 2 cards.
            AddSpellAbilities(new YouMayDrawCardsEffect(2));
        }
    }
}
