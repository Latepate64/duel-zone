using OneShotEffects;

namespace Cards.DM01
{
    class BrainSerum : Engine.Spell
    {
        public BrainSerum() : base("Brain Serum", 4, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new YouMayDrawUpToTwoCardsEffect());
        }
    }
}
