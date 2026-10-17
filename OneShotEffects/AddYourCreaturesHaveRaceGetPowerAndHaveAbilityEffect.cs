using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddYourCreaturesHaveRaceGetPowerAndHaveAbilityEffect : OneShotEffect
{
    private readonly IYourCreaturesHaveRaceGetPowerAndHaveAbilityEffectFactory effectFactory;
    private readonly ICardFilter filter;
    private readonly Race race;
    private readonly int power;
    private readonly IStaticAbilityFactory abilityFactory;

    public AddYourCreaturesHaveRaceGetPowerAndHaveAbilityEffect(
        IYourCreaturesHaveRaceGetPowerAndHaveAbilityEffectFactory effectFactory,
        ICardFilter filter,
        Race race,
        int power,
        IStaticAbilityFactory abilityFactory)
    {
        this.effectFactory = effectFactory;
        this.filter = filter;
        this.race = race;
        this.power = power;
        this.abilityFactory = abilityFactory;
    }

    public AddYourCreaturesHaveRaceGetPowerAndHaveAbilityEffect(
        AddYourCreaturesHaveRaceGetPowerAndHaveAbilityEffect effect) : base(effect)
    {
        effectFactory = effect.effectFactory;
        filter = effect.filter.Copy();
        race = effect.race;
        power = effect.power;
        abilityFactory = effect.abilityFactory;
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
        var effect = effectFactory.Create(race, power, abilityFactory, [.. creatures]);
        game.AddContinuousEffects(Ability, effect);
    }

    public override IOneShotEffect Copy()
    {
        return new AddYourCreaturesHaveRaceGetPowerAndHaveAbilityEffect(this);
    }
}
