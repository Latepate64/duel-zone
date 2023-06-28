using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class StaticWarp : Spell
    {
        public StaticWarp() : base("Static Warp", 2, Civilization.Light)
        {
            AddSpellAbilities(new StaticWarpEffect());
        }
    }

    class StaticWarpEffect : OneShotEffect
    {
        public override void Apply()
        {
            var chosen = Game.Players.Select(x => x.ChooseCard(Game.BattleZone.GetCreatures(x), ToString()));
            Applier.Tap(Game.BattleZone.Creatures.Where(x => !chosen.Contains(x)).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new StaticWarpEffect();
        }

        public override string ToString()
        {
            return "Each player chooses one of his creatures in the battle zone. Tap the rest of the creatures in the battle zone.";
        }
    }
}
