using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class ChekiculVizierOfEndurance : Creature
    {
        public ChekiculVizierOfEndurance() : base("Chekicul, Vizier of Endurance", 5, 1000, Race.Initiate, Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new ChekiculEffect());
        }
    }

    class ChekiculEffect : ContinuousEffect, ISkipBattleAfterBlockEffect
    {
        public ChekiculEffect()
        {
        }

        public ChekiculEffect(ChekiculEffect effect) : base(effect)
        {
        }

        public bool Applies(ICard attacker, ICard blocker, IGame game)
        {
            return blocker == GetSourceCard(game);
        }

        public override IContinuousEffect Copy()
        {
            return new ChekiculEffect(this);
        }

        public override string ToString()
        {
            return "Whenever this creature blocks, no battle happens.";
        }
    }
}
