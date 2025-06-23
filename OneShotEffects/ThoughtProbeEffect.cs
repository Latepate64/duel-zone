using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class ThoughtProbeEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        if (game.BattleZone.GetCreatureCount(GetOpponent(game).Id) >= 3)
        {
            Controller.DrawCards(3, game, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new ThoughtProbeEffect();
    }

    public override string ToString()
    {
        return "If your opponent has 3 or more creatures in the battle zone, draw 3 cards.";
    }
}
