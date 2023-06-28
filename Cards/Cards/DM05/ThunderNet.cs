using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM05
{
    class ThunderNet : Spell
    {
        public ThunderNet() : base("Thunder Net", 2, Civilization.Water)
        {
            AddSpellAbilities(new ThunderNetEffect());
        }
    }

    class ThunderNetEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var amount = game.BattleZone.GetCreatures(Applier.Id).Count(x => x.HasCivilization(Civilization.Water));
            var creatures = Applier.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, Applier.Opponent), 0, amount, ToString());
            Applier.Tap(game, creatures.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new ThunderNetEffect();
        }

        public override string ToString()
        {
            return "For each water creature you have in the battle zone, you may choose one of your opponent's creatures in the battle zone and tap it.";
        }
    }
}
