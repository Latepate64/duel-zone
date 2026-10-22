using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddChosenCreatureAffectingNumberEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;
    public int Power { get; }
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;
    private readonly IDuration duration;

    public AddChosenCreatureAffectingNumberEffect(
        int power,
        ICardFilter filter,
        IContinuousEffectWithCreaturesAndIntegerFactory factory,
        IDuration duration) : base(1, 1, true)
    {
        Power = power;
        this.filter = filter;
        this.factory = factory;
        this.duration = duration;
    }

    public AddChosenCreatureAffectingNumberEffect(
        AddChosenCreatureAffectingNumberEffect effect) : base(
        effect)
    {
        Power = effect.Power;
        filter = effect.filter.Copy();
        factory = effect.factory;
        duration = effect.duration.Copy();
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
            duration,
            factory.Create(Power, cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }
}
