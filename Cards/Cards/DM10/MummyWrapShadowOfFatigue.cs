using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class MummyWrapShadowOfFatigue : Creature
    {
        public MummyWrapShadowOfFatigue() : base("Mummy Wrap, Shadow of Fatigue", 3, 1000, Race.Ghost, Civilization.Darkness)
        {
            AddTapAbility(new MummyWrapShadowOfFatigueEffect());
        }
    }

    class MummyWrapShadowOfFatigueEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.Players.ToList().ForEach(x => x.DiscardAtRandom(game, 1, source));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new MummyWrapShadowOfFatigueEffect();
        }

        public override string ToString()
        {
            return "Each player discards a card at random from his hand.";
        }
    }
}
