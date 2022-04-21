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
        public override void Apply(IGame game, IAbility source)
        {
            var controller = GetController(game);
            var amount = game.BattleZone.GetCreatures(controller.Id).Count(x => x.HasCivilization(Civilization.Water));
            var creatures = controller.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id), 0, amount, ToString());
            controller.Tap(game, creatures.ToArray());
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
