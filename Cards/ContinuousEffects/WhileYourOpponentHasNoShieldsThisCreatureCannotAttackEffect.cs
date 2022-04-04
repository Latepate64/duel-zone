using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect : ContinuousEffect, ICannotAttackEffect
    {
        public WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect() : base(new TargetFilter(), new Durations.Indefinite()) { }

        public WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect(WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect effect) : base(effect)
        {
        }

        public bool Applies(IGame game)
        {
            return !game.GetAbility(SourceAbility).GetOpponent(game).ShieldZone.Cards.Any();
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