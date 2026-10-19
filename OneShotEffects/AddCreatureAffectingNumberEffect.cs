using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddCreatureAffectingNumberEffect :
    OneShotEffect
{
    public int Power { get; }
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;

    public AddCreatureAffectingNumberEffect(
        int power, IContinuousEffectWithCreaturesAndIntegerFactory factory)
    {
        Power = power;
        this.factory = factory;
    }

    public AddCreatureAffectingNumberEffect(
        AddCreatureAffectingNumberEffect effect) :
        base(effect)
    {
        Power = effect.Power;
        factory = effect.factory;
    }

    public override IOneShotEffect Copy()
    {
        return new AddCreatureAffectingNumberEffect(this);
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            factory.Create(Power, (ICreature)Ability.Source));
    }
}
