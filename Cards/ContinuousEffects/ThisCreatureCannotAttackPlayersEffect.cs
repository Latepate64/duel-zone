using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotAttackPlayersEffect : ContinuousEffect, ICannotAttackPlayersEffect
    {
        public ThisCreatureCannotAttackPlayersEffect() : base()
        {
        }

        public bool CannotAttackPlayers(ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature);
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