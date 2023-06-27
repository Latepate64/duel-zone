using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class TakeExtraTurnAfterThisOneEffect : OneShotEffect
    {
        public TakeExtraTurnAfterThisOneEffect()
        {
        }

        public TakeExtraTurnAfterThisOneEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            Turn turn = new() { ActivePlayer = Applier, NonActivePlayer = GetOpponent(game) };
            game.ExtraTurns.Push(turn);
        }

        public override IOneShotEffect Copy()
        {
            return new TakeExtraTurnAfterThisOneEffect(this);
        }

        public override string ToString()
        {
            return "Take an extra turn after this one.";
        }
    }
}