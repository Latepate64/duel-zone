using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM10;

public sealed class ElixiaEffect : PowerModifyingMultiplierEffect
{
    public ElixiaEffect(int power = 3000) : base(power)
    {
    }

    public ElixiaEffect(ElixiaEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ElixiaEffect(this);
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each civilization in your mana zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return Controller.ManaZone.Cards.SelectMany(x => x.Civilizations).Distinct().Count();
    }
}
