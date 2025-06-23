using OneShotEffects;

namespace Cards.DM01
{
    sealed class DimensionGate : Spell
    {
        public DimensionGate() : base("Dimension Gate", 3, Interfaces.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new SearchCreatureEffect());
        }
    }
}
