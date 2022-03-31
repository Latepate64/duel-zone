using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class TakeExtraTurnAfterThisOneEffect : OneShotEffect
    {
        public override Turn Apply(IGame game, IAbility source)
        {
            Turn turn = new() { ActivePlayer = source.GetController(game), NonActivePlayer = source.GetOpponent(game) };
            game.ExtraTurns.Push(turn);
            return turn;
        }

        public override IOneShotEffect Copy()
        {
            return new TakeExtraTurnAfterThisOneEffect();
        }

        public override string ToString()
        {
            return "Take an extra turn after this one.";
        }
    }
}