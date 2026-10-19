using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class YourChosenCreaturesCannotBeBlockedThisTurnEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;
    private readonly IContinuousEffectFactory factory;
    private readonly IDuration duration;

    public YourChosenCreaturesCannotBeBlockedThisTurnEffect(
        int minimum,
        int maximum,
        ICardFilter filter,
        IContinuousEffectFactory factory,
        IDuration duration) : base(minimum, maximum, true)
    {
        this.filter = filter;
        this.factory = factory;
        this.duration = duration;
    }

    public YourChosenCreaturesCannotBeBlockedThisTurnEffect(
        YourChosenCreaturesCannotBeBlockedThisTurnEffect effect)
        : base(effect)
    {
        filter = effect.filter.Copy();
        factory = effect.factory;
        duration = effect.duration.Copy();
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
            duration,
            factory.Create(creatures));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }
}
