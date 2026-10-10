using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Each of your creatures gets ability until the end of the turn.
/// </summary>
public sealed class EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect
    : OneShotAreaOfEffect
{
    private readonly IAbility ability;
    private readonly ICardFilter filter;

    public EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
        IAbility ability, ICardFilter filter) : base()
    {
        this.ability = ability;
        this.filter = filter;
    }

    public EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
        EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect effect) : base(
            effect)
    {
        ability = effect.ability.Copy();
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
                ability,
                [.. GetAffectedCards(game, Ability)]));
    }

    public override IOneShotEffect Copy()
    {
        return new EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }
}
