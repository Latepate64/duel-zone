using Engine;
using Engine.ContinuousEffects;
using Engine.Steps;

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

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IGame game)
        {
            return IsSourceOfAbility(attacker, game) && game.CurrentTurn.CurrentPhase is AttackPhase a && a.AttackTarget is ICard;
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
