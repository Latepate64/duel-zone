using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotAttackPlayersEffect : ContinuousEffect, ICannotAttackPlayersEffect
    {
        public ThisCreatureCannotAttackPlayersEffect() : base(new TargetFilter(), new Durations.Indefinite())
        {
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