using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class ChosenCreaturesCannotBeBlockedThisTurnEffect : UntilEndOfTurnEffect, IUnblockableEffect
    {
        private readonly ICard[] _cards;

        public ChosenCreaturesCannotBeBlockedThisTurnEffect(params ICard[] cards) : base()
        {
            _cards = cards;
        }

        public ChosenCreaturesCannotBeBlockedThisTurnEffect(ChosenCreaturesCannotBeBlockedThisTurnEffect effect) : base(effect)
        {
            _cards = effect._cards;
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IGame game)
        {
            return _cards.Any(x => x.Id == attacker.Id);
;        }

        public override IContinuousEffect Copy()
        {
            return new ChosenCreaturesCannotBeBlockedThisTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature can't be blocked this turn.";
        }
    }
}
