using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect : ContinuousEffect, IUnblockableEffect, IPowerable
    {
        public ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(int power) : base()
        {
            Power = power;
        }

        public int Power { get; }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack)
        {
            return IsSourceOfAbility(attacker) && blocker.Power <= Power;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(this);
        }

        public override string ToString()
        {
            return $"This creature can't be blocked by any creature that has power {Power} or less.";
        }
    }
}