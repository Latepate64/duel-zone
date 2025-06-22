using OneShotEffects;

namespace Cards.DM01
{
    sealed class CrystalMemory : Engine.Spell
    {
        public CrystalMemory() : base("Crystal Memory", 4, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new SearchCardNoRevealEffect());
        }
    }
}
