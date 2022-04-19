using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM07
{
    class JusticeJamming : Spell
    {
        public JusticeJamming() : base("Justice Jamming", 3, Civilization.Light)
        {
            AddSpellAbilities(new JusticeJammingEffect());
        }
    }

    class JusticeJammingEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var civilization = source.GetController(game).ChooseCivilization(ToString(), Civilization.Light, Civilization.Water, Civilization.Nature);
            source.GetController(game).Tap(game, game.BattleZone.GetCreatures(civilization).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new JusticeJammingEffect();
        }

        public override string ToString()
        {
            return "Tap all darkness creatures in the battle zone, or tap all fire creatures in the battle zone.";
        }
    }
}
