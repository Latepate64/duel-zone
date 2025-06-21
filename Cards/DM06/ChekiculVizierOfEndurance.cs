using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM06
{
    class ChekiculVizierOfEndurance : Creature
    {
        public ChekiculVizierOfEndurance() : base("Chekicul, Vizier of Endurance", 5, 1000, Race.Initiate, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
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

        public bool Applies(ICreature attacker, ICreature blocker, IGame game)
        {
            return blocker == Source;
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
