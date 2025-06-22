using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class EachOtherCivilizationCreaturePowerEffect : ContinuousEffect, IPowerModifyingEffect
{
    private readonly Civilization _civilization;
    private readonly int _power;

    public EachOtherCivilizationCreaturePowerEffect(EachOtherCivilizationCreaturePowerEffect effect) : base(effect)
    {
        _civilization = effect._civilization;
        _power = effect._power;
    }

    public EachOtherCivilizationCreaturePowerEffect(Civilization civilization, int power) : base()
    {
        _civilization = civilization;
        _power = power;
    }

    public void ModifyPower(IGame game)
    {
        game.BattleZone.Creatures.Where(x => !IsSourceOfAbility(x)).ToList().ForEach(x => x.IncreasePower(_power));
    }

    public override string ToString()
    {
        return $"Each other {_civilization} creature in the battle zone gets +{_power} power.";
    }

    public override IContinuousEffect Copy()
    {
        return new EachOtherCivilizationCreaturePowerEffect(this);
    }
}
