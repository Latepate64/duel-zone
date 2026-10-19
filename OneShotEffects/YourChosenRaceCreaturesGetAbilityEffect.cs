using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class YourChosenRaceCreaturesGetAbilityEffect : OneShotEffect
{
    private readonly IRaceCreatureFilterFactory raceFactory;
    private readonly IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory;
    private readonly IAbility ability;
    private readonly IDuration duration;

    public YourChosenRaceCreaturesGetAbilityEffect(
        IRaceCreatureFilterFactory raceFactory,
        IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory,
        IAbility ability,
        IDuration duration)
    {
        this.raceFactory = raceFactory;
        this.effectFactory = effectFactory;
        this.ability = ability;
        this.duration = duration;
    }

    public YourChosenRaceCreaturesGetAbilityEffect(
        YourChosenRaceCreaturesGetAbilityEffect effect) : base(effect)
    {
        raceFactory = effect.raceFactory;
        effectFactory = effect.effectFactory;
        ability = effect.ability.Copy();
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        var filter = raceFactory.Create(race);
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(
            Applier, filter);
        game.AddContinuousEffects(
            Ability,
            duration,
            effectFactory.Create([ability], [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new YourChosenRaceCreaturesGetAbilityEffect(this);
    }
}
