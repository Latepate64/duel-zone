using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose a race. Each of your creatures in the battle zone of that race gets
/// ability.
/// </summary>
public sealed class YourChosenRaceCreaturesGetAbilityEffect : OneShotEffect
{
    private readonly IRaceCreatureFilterFactory raceFactory;
    private readonly IAbilityAddingContinuousEffectFactory effectFactory;
    private readonly IAbility ability;

    public YourChosenRaceCreaturesGetAbilityEffect(
        IRaceCreatureFilterFactory raceFactory,
        IAbilityAddingContinuousEffectFactory effectFactory,
        IAbility ability)
    {
        this.raceFactory = raceFactory;
        this.effectFactory = effectFactory;
        this.ability = ability;
    }

    public YourChosenRaceCreaturesGetAbilityEffect(
        YourChosenRaceCreaturesGetAbilityEffect effect) : base(effect)
    {
        raceFactory = effect.raceFactory;
        effectFactory = effect.effectFactory;
        ability = effect.ability.Copy();
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        var filter = raceFactory.Create(race);
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(
            Applier, filter);
        game.AddContinuousEffects(
            Ability,
            effectFactory.Create(ability, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new YourChosenRaceCreaturesGetAbilityEffect(this);
    }
}
