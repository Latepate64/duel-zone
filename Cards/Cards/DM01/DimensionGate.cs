using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class DimensionGate : Spell
    {
        public DimensionGate() : base("Dimension Gate", 3, Common.Civilization.Nature)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new SearchCreatureEffect());
        }
    }
}
