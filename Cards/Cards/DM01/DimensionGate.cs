using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class DimensionGate : Spell
    {
        public DimensionGate() : base("Dimension Gate", 3, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new SearchCreatureEffect());
        }
    }
}
