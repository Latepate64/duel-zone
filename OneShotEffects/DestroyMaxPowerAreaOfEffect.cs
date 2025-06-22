using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class DestroyMaxPowerAreaOfEffect : DestroyAreaOfEffect, IPowerable
{
    public DestroyMaxPowerAreaOfEffect(int power) : base()
    {
        Power = power;
    }

    public DestroyMaxPowerAreaOfEffect(DestroyMaxPowerAreaOfEffect effect) : base(effect)
    {
        Power = effect.Power;
    }

    public int Power { get; }

    public override IOneShotEffect Copy()
    {
        return new DestroyMaxPowerAreaOfEffect(this);
    }

    public override string ToString()
    {
        return $"Destroy all creatures that have power {Power} or less.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesWithMaxPower(Power);
    }
}
