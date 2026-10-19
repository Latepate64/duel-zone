using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddRaceAffectingAbilityAddingEffect : OneShotEffect
{
    private readonly IContinuousEffectWithRaceIntegerAndAbilityFactory effectFactory;
    private readonly IStaticAbilityWithIntegerFactory abilityFactory;
    private readonly int power;

    public AddRaceAffectingAbilityAddingEffect(
        IContinuousEffectWithRaceIntegerAndAbilityFactory effectFactory,
        IStaticAbilityWithIntegerFactory abilityFactory,
        int power)
    {
        this.effectFactory = effectFactory;
        this.abilityFactory = abilityFactory;
        this.power = power;
    }

    public AddRaceAffectingAbilityAddingEffect(
        AddRaceAffectingAbilityAddingEffect effect) : base(effect)
    {
        effectFactory = effect.effectFactory;
        abilityFactory = effect.abilityFactory;
        power = effect.power;
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        game.AddContinuousEffects(
            Ability,
            effectFactory.Create(race, abilityFactory, power));
    }

    public override IOneShotEffect Copy()
    {
        return new AddRaceAffectingAbilityAddingEffect(this);
    }
}
