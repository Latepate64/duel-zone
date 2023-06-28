using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect : ContinuousEffect, ICannotAttackEffect
    {
        public WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect() : base() { }

        public WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect(WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect effect) : base(effect)
        {
        }

        public bool CannotAttack(ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature) && !Applier.Opponent.ShieldZone.HasCards;
        }

        public override IContinuousEffect Copy()
        {
            return new WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect(this);
        }

        public override string ToString()
        {
            return "While your opponent has no shields, this creature can't attack.";
        }
    }
}