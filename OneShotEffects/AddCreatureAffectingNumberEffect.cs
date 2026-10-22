using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddCreatureAffectingNumberEffect : OneShotEffect
{
    public int Power { get; }
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;
    private readonly IDuration duration;

    public AddCreatureAffectingNumberEffect(
        int power, IContinuousEffectWithCreaturesAndIntegerFactory factory, IDuration duration)
    {
        Power = power;
        this.factory = factory;
        this.duration = duration;
    }

    public AddCreatureAffectingNumberEffect(
        AddCreatureAffectingNumberEffect effect) :
        base(effect)
    {
        Power = effect.Power;
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new AddCreatureAffectingNumberEffect(this);
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(Power, (ICreature)Ability.Source));
    }
}
