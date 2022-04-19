using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class TakeExtraTurnAfterThisOneEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            Turn turn = new() { ActivePlayer = source.GetController(game), NonActivePlayer = source.GetOpponent(game) };
            game.ExtraTurns.Push(turn);
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