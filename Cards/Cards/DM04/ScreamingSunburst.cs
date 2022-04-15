using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class ScreamingSunburst : Spell
    {
        public ScreamingSunburst() : base("Screaming Sunburst", 3, Engine.Civilization.Light)
        {
            AddSpellAbilities(new ScreamingSunburstEffect());
        }
    }

    class ScreamingSunburstEffect : OneShotEffects.TapAreaOfEffect
    {
        public ScreamingSunburstEffect() : base()
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.Creatures.Where(x => !x.HasCivilization(Engine.Civilization.Light));
        }
    }
}
