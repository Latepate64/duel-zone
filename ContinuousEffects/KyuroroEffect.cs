using Engine.GameEvents;
using GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class KyuroroEffect : ReplacementEffect
{
    public KyuroroEffect()
    {
    }

    public KyuroroEffect(KyuroroEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        var e = gameEvent as CreatureBreaksShieldsEvent;
        return new KyuroroEvent(e.Attacker, e.BreakAmount);
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is CreatureBreaksShieldsEvent e && e.Attacker.Owner == game.GetOpponent(Controller);
    }

    public override IContinuousEffect Copy()
    {
        return new KyuroroEffect(this);
    }

    public override string ToString()
    {
        return "Whenever an opponent's creature would break a shield, you choose the shield instead of your opponent.";
    }
}
