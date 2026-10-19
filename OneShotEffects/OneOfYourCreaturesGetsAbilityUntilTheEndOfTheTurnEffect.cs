using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect : CreatureSelectionEffect
{
    private readonly IAbility ability;
    private readonly ICardFilter filter;
    private readonly IAbilityAddingContinuousEffectFactory factory;

    public OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
        IAbility ability,
        ICardFilter filter,
        IAbilityAddingContinuousEffectFactory factory) : base(1, 1, true)
    {
        this.ability = ability;
        this.filter = filter;
        this.factory = factory;
    }

    public OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
        OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(
            effect)
    {
        ability = effect.ability.Copy();
        filter = effect.filter.Copy();
        factory = effect.factory;
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] creatures)
    {
        game.AddContinuousEffects(
            Ability,
            factory.Create(ability, creatures));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }

    public override IOneShotEffect Copy()
    {
        return new OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
            this);
    }
}
