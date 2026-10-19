using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class OneOfYourCreaturesGetsAbilityEffect : CreatureSelectionEffect
{
    private readonly IAbility ability;
    private readonly ICardFilter filter;
    private readonly IContinuousEffectWithAbilitiesAndCreaturesFactory factory;
    private readonly IDuration duration;

    public OneOfYourCreaturesGetsAbilityEffect(
        IAbility ability,
        ICardFilter filter,
        IContinuousEffectWithAbilitiesAndCreaturesFactory factory,
        IDuration duration) : base(1, 1, true)
    {
        this.ability = ability;
        this.filter = filter;
        this.factory = factory;
        this.duration = duration;
    }

    public OneOfYourCreaturesGetsAbilityEffect(
        OneOfYourCreaturesGetsAbilityEffect effect) : base(
            effect)
    {
        ability = effect.ability.Copy();
        filter = effect.filter.Copy();
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] creatures)
    {
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create([ability], creatures));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }

    public override IOneShotEffect Copy()
    {
        return new OneOfYourCreaturesGetsAbilityEffect(this);
    }
}
