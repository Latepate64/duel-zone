using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddRaceAffectingAbilityAddingEffect : OneShotEffect
{
    private readonly IContinuousEffectWithRaceIntegerAndAbilityFactory effectFactory;
    private readonly IStaticAbilityWithIntegerFactory abilityFactory;
    private readonly int power;
    private readonly IDuration duration;

    public AddRaceAffectingAbilityAddingEffect(
        IContinuousEffectWithRaceIntegerAndAbilityFactory effectFactory,
        IStaticAbilityWithIntegerFactory abilityFactory,
        int power,
        IDuration duration)
    {
        this.effectFactory = effectFactory;
        this.abilityFactory = abilityFactory;
        this.power = power;
        this.duration = duration;
    }

    public AddRaceAffectingAbilityAddingEffect(
        AddRaceAffectingAbilityAddingEffect effect) : base(effect)
    {
        effectFactory = effect.effectFactory;
        abilityFactory = effect.abilityFactory;
        power = effect.power;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        game.AddContinuousEffects(
            Ability,
            duration,
            effectFactory.Create(race, abilityFactory, power));
    }

    public override IOneShotEffect Copy()
    {
        return new AddRaceAffectingAbilityAddingEffect(this);
    }
}
