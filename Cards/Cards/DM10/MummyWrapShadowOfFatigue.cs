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
        public MummyWrapShadowOfFatigueEffect()
        {
        }

        public MummyWrapShadowOfFatigueEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.Players.ToList().ForEach(x => x.DiscardAtRandom(1, Ability));
        }

        public override IOneShotEffect Copy()
        {
            return new MummyWrapShadowOfFatigueEffect(this);
        }

        public override string ToString()
        {
            return "Each player discards a card at random from his hand.";
        }
    }
}
