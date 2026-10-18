using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class WaveStrikerEffect : ContinuousEffect, IAbilityAddingEffect
{
    private readonly IAbility[] _abilities;

    public WaveStrikerEffect(WaveStrikerEffect effect) : base(effect)
    {
        _abilities = effect._abilities;
    }

    public WaveStrikerEffect(params IAbility[] abilities) : base()
    {
        _abilities = abilities;
    }

    public void AddAbility(IGame game)
    {
        if (game.BattleZone.Creatures.Count(x => x.HasWaveStriker) >= 3)
        {
            _abilities.ToList().ForEach(x => game.AddAbility(Source, x.Copy()));
        }
    }

    public override IContinuousEffect Copy()
    {
        return new WaveStrikerEffect();
    }
}
