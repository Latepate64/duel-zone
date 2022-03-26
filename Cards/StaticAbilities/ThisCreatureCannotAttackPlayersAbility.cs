using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class ThisCreatureCannotAttackPlayersAbility : StaticAbility
    {
        public ThisCreatureCannotAttackPlayersAbility(params Condition[] conditions) : base(new ThisCreatureCannotAttackPlayersEffect(conditions))
        {
        }
    }

    public class ThisCreatureCannotAttackPlayersEffect : CannotAttackPlayersEffect
    {
        public ThisCreatureCannotAttackPlayersEffect(params Condition[] conditions) : base(new TargetFilter(), new Durations.Indefinite(), conditions)
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
