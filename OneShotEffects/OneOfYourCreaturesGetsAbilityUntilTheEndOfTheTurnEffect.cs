using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace OneShotEffects;

/// <summary>
/// One of your creatures in the battle zone gets ability until the end of the
/// turn.
/// </summary>
public class OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect
    : CreatureSelectionEffect
{
    private readonly IAbility ability;
    private readonly ICardFilter filter;

    public OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
        IAbility ability, ICardFilter filter) : base(1, 1, true)
    {
        this.ability = ability;
        this.filter = filter;
    }

    public OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
        OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(
            effect)
    {
        ability = effect.ability.Copy();
        filter = effect.filter.Copy();
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(
            Ability,
            new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
                ability, cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControllerByPlayer(Applier, filter);
    }

    public override IOneShotEffect Copy()
    {
        return new OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
            this);
    }
}
