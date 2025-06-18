using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class JusticeJamming : Engine.Spell
    {
        public JusticeJamming() : base("Justice Jamming", 3, Civilization.Light)
        {
            AddSpellAbilities(new JusticeJammingEffect());
        }
    }

    class JusticeJammingEffect : OneShotEffect
    {
        public JusticeJammingEffect()
        {
        }

        public JusticeJammingEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var civilization = Controller.ChooseCivilization(ToString(), Civilization.Light, Civilization.Water, Civilization.Nature);
            Controller.Tap(game, [.. game.BattleZone.GetCreatures(civilization)]);
        }

        public override IOneShotEffect Copy()
        {
            return new JusticeJammingEffect(this);
        }

        public override string ToString()
        {
            return "Tap all darkness creatures in the battle zone, or tap all fire creatures in the battle zone.";
        }
    }
}
