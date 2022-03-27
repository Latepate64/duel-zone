using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class ScreamingSunburst : Spell
    {
        public ScreamingSunburst() : base("Screaming Sunburst", 3, Civilization.Light)
        {
            AddSpellAbilities(new ScreamingSunburstEffect());
        }
    }

    class ScreamingSunburstEffect : OneShotEffects.TapAreaOfEffect
    {
        public ScreamingSunburstEffect() : base(new CardFilters.BattleZoneNonCivilizationCreatureFilter(Civilization.Light))
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ScreamingSunburstEffect();
        }

        public override string ToString()
        {
            return "Tap all creatures in the battle zone except light creatures.";
        }
    }
}
