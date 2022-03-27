using Common;

namespace Cards.Cards.DM04
{
    class ScreamingSunburst : Spell
    {
        public ScreamingSunburst() : base("Screaming Sunburst", 3, Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.TapAreaOfEffect(new CardFilters.BattleZoneNonCivilizationCreatureFilter(Civilization.Light)));
        }
    }
}
