using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect : ContinuousEffect, IUnblockableEffect
    {
        public ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect()
        {
        }

        public ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect(ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect effect) : base(effect)
        {
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return IsSourceOfAbility(attacker) && targetOfAttack is ICard;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect(this);
        }

        public override string ToString()
        {
            return "While attacking a creature, this creature can't be blocked.";
        }
    }
}
