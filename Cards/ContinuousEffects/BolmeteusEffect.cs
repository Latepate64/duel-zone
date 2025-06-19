using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.ContinuousEffects;

public class BolmeteusEffect : ReplacementEffect
{
    public BolmeteusEffect()
    {
    }

    public BolmeteusEffect(BolmeteusEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        var e = gameEvent as CreatureBreaksShieldsEvent;
        return new BolmeteusEvent(e.Attacker, e.BreakAmount);
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is CreatureBreaksShieldsEvent e && e.Attacker == Source;
    }

    public override IContinuousEffect Copy()
    {
        return new BolmeteusEffect(this);
    }

    public override string ToString()
    {
        return "Whenever this creature would break a shield, your opponent puts that shield into his graveyard instead.";
    }
}
