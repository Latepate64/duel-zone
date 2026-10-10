using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

/// <summary>
/// One of your creatures in the battle zone gets +x power until the end of the
/// turn.
/// </summary>
public sealed class OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect
    : CreatureSelectionEffect, IPowerable
{
    private readonly ICardFilter filter;
    public int Power { get; }

    public OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(
        int power, ICardFilter filter) : base(1, 1, true)
    {
        Power = power;
        this.filter = filter;
    }

    public OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(
        OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect effect) : base(
        effect)
    {
        Power = effect.Power;
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        throw new NotImplementedException();
        // game.AddContinuousEffects(Ability, new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(
        //     Power, cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControllerByPlayer(Applier, filter);
    }
}
