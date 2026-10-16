using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your creatures in the battle zone. It can't be blocked this
/// turn.
/// </summary>
public sealed class ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;
    private readonly IContinuousEffectFactory factory;

    public ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(
        ICardFilter filter, IContinuousEffectFactory factory) : base(1, 1, true)
    {
        this.filter = filter;
        this.factory = factory;
    }

    public ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(
        ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect effect)
        : base(effect)
    {
        filter = effect.filter.Copy();
        factory = effect.factory;
    }

    public override ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect Copy()
    {
        return new ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(this);
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
