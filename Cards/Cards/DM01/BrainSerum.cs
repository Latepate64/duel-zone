using OneShotEffects;

namespace Cards.Cards.DM01
{
    class BrainSerum : Engine.Spell
    {
        public BrainSerum() : base("Brain Serum", 4, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new YouMayDrawUpToTwoCardsEffect());
        }
    }
}
