using Common;

namespace Cards.Cards.DM10
{
    class ThirstForTheHunt : Spell
    {
        public ThirstForTheHunt() : base("Thirst for the Hunt", 1, Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.AuraBlastEffect(1000));
        }
    }
}
