using Interfaces;

namespace OneShotEffects;

/// <summary>
/// One of your creatures in the battle zone gets +x power until the end of the
/// turn.
/// </summary>
public sealed class AddChosenCreatureAffectingNumberEffect
    : CreatureSelectionEffect
{
    private readonly ICardFilter filter;
    public int Power { get; }
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;

    public AddChosenCreatureAffectingNumberEffect(
        int power,
        ICardFilter filter,
        IContinuousEffectWithCreaturesAndIntegerFactory factory) : base(
            1, 1, true)
    {
        Power = power;
        this.filter = filter;
        this.factory = factory;
    }

    public AddChosenCreatureAffectingNumberEffect(
        AddChosenCreatureAffectingNumberEffect effect) : base(
        effect)
    {
        Power = effect.Power;
        filter = effect.filter.Copy();
        factory = effect.factory;
    }

    public override IOneShotEffect Copy()
    {
        return new AddChosenCreatureAffectingNumberEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(
            Ability,
            factory.Create(Power, cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }
}
