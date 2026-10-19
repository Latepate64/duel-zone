using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddContinuousEffectWithRaceAndFilterEffect : OneShotEffect
{
    private readonly IContinuousEffectWithRaceAndFilterFactory factory;
    private readonly IDuration duration;
    private readonly ICardFilter filter;

    public AddContinuousEffectWithRaceAndFilterEffect(
        IContinuousEffectWithRaceAndFilterFactory factory,
        IDuration duration,
        ICardFilter filter)
    {
        this.factory = factory;
        this.duration = duration;
        this.filter = filter;
    }

    public AddContinuousEffectWithRaceAndFilterEffect(
        AddContinuousEffectWithRaceAndFilterEffect effect) : base(effect)
    {
        factory = effect.factory;
        duration = effect.duration;
        filter = effect.filter;
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(race, filter));
    }

    public override IOneShotEffect Copy()
    {
        return new AddContinuousEffectWithRaceAndFilterEffect(this);
    }
}
