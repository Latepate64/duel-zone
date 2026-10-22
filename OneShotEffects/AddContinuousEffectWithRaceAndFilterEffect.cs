using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddContinuousEffectWithRaceAndFilterEffect : OneShotEffect
{
    private readonly IContinuousEffectWithTwoFiltersFactory factory;
    private readonly IDuration duration;
    private readonly ICardFilter filter;
    private readonly IRaceCreatureFilterFactory raceCreatureFilterFactory;

    public AddContinuousEffectWithRaceAndFilterEffect(
        IContinuousEffectWithTwoFiltersFactory factory,
        IDuration duration,
        ICardFilter filter,
        IRaceCreatureFilterFactory raceCreatureFilterFactory)
    {
        this.factory = factory;
        this.duration = duration;
        this.filter = filter;
        this.raceCreatureFilterFactory = raceCreatureFilterFactory;
    }

    public AddContinuousEffectWithRaceAndFilterEffect(
        AddContinuousEffectWithRaceAndFilterEffect effect) : base(effect)
    {
        factory = effect.factory;
        duration = effect.duration;
        filter = effect.filter.Copy();
        raceCreatureFilterFactory = effect.raceCreatureFilterFactory;
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        var raceFilter = raceCreatureFilterFactory.Create(race);
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(raceFilter, filter));
    }

    public override IOneShotEffect Copy()
    {
        return new AddContinuousEffectWithRaceAndFilterEffect(this);
    }
}
