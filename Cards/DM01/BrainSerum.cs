using OneShotEffects;

namespace Cards.DM01
{
    sealed class BrainSerum : Engine.Spell
    {
        public BrainSerum() : base("Brain Serum", 4, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new YouMayDrawUpToTwoCardsEffect());
        }
    }
}
