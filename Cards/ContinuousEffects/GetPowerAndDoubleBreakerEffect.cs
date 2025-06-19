using Abilities.Static;
using Effects.Continuous;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.ContinuousEffects;

public abstract class GetPowerAndDoubleBreakerEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
{
    private readonly int _power;

    protected GetPowerAndDoubleBreakerEffect(GetPowerAndDoubleBreakerEffect effect) : base(effect)
    {
        _power = effect._power;
    }

    protected GetPowerAndDoubleBreakerEffect(int power) : base()
    {
        _power = power;
    }

    public void AddAbility(IGame game)
    {
        GetAffectedCards(game).ForEach(x => x.AddGrantedAbility(new DoubleBreakerAbility()));
    }

    public void ModifyPower(IGame game)
    {
        GetAffectedCards(game).ForEach(x => x.IncreasePower(_power));
    }

    protected abstract List<Creature> GetAffectedCards(IGame game);
}
