using Engine;
using System;

namespace Cards.Conditions
{
    class ItIsYourOpponentsTurnCondition : Condition
    {
        public ItIsYourOpponentsTurnCondition() : base(new TargetFilter())
        {
        }

        public ItIsYourOpponentsTurnCondition(ItIsYourOpponentsTurnCondition condition) : base(condition)
        {
        }

        public override bool Applies(Game game, Guid player)
        {
            return game.GetOpponent(player) == game.CurrentTurn.ActivePlayer.Id;
        }

        public override Condition Copy()
        {
            return new ItIsYourOpponentsTurnCondition(this);
        }

        public override string ToString()
        {
            return "During your opponent's turn";
        }
    }
}
