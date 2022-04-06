using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotAttackPlayersEffect : ContinuousEffect, ICannotAttackPlayersEffect
    {
        public ThisCreatureCannotAttackPlayersEffect() : base()
        {
        }

        public bool Applies(ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature, game);
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureCannotAttackPlayersEffect();
        }

        public override string ToString()
        {
            return "This creature can't attack players.";
        }
    }
}