using Engine;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class JigglyTotemEffect : PowerAttackerMultiplierEffect
{
    public JigglyTotemEffect(JigglyTotemEffect effect) : base(effect)
    {
    }

    public JigglyTotemEffect(int power) : base(power)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new JigglyTotemEffect(this);
    }

    public override string ToString()
    {
        return $"While attacking, this creature gets +{Power} power for each tapped card in your mana zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return Ability.Controller.ManaZone.TappedCards.Count();
    }
}