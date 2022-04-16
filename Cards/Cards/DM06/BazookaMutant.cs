using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM06
{
    class BazookaMutant : Creature
    {
        public BazookaMutant() : base("Bazooka Mutant", 4, 8000, Race.Hedrian, Civilization.Darkness)
        {
            AddStaticAbilities(new BazookaMutantEffect());
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }

    class BazookaMutantEffect : ContinuousEffect, ICannotAttackCreaturesEffect
    {
        public BazookaMutantEffect()
        {
        }

        public BazookaMutantEffect(BazookaMutantEffect effect) : base(effect)
        {
        }

        public bool Applies(ICard attacker, ICard target, IGame game)
        {
            return IsSourceOfAbility(attacker, game) && !target.GetAbilities<BlockerAbility>().Any();
        }

        public override IContinuousEffect Copy()
        {
            return new BazookaMutantEffect(this);
        }

        public override string ToString()
        {
            return "This creature can attack only creatures that have \"blocker.\"";
        }
    }
}
