using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class YourChosenCreaturesCannotBeBlockedThisTurnEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;
    private readonly IContinuousEffectFactory factory;

    public YourChosenCreaturesCannotBeBlockedThisTurnEffect(
        int minimum,
        int maximum,
        ICardFilter filter,
        IContinuousEffectFactory factory) : base(minimum, maximum, true)
    {
        this.filter = filter;
        this.factory = factory;
    }

    public YourChosenCreaturesCannotBeBlockedThisTurnEffect(
        YourChosenCreaturesCannotBeBlockedThisTurnEffect effect)
        : base(effect)
    {
        filter = effect.filter.Copy();
        factory = effect.factory;
    }

    public override YourChosenCreaturesCannotBeBlockedThisTurnEffect Copy()
    {
        return new YourChosenCreaturesCannotBeBlockedThisTurnEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] creatures)
    {
        game.AddContinuousEffects(
            Ability,
            factory.Create(creatures));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }
}
