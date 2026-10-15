using Interfaces;

namespace OneShotEffects;

public sealed class CreatureSelectionIntegerAffectingContinuousEffectAddingEffect
    : CreatureSelectionEffect
{
    private readonly int number;
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;

    public CreatureSelectionIntegerAffectingContinuousEffectAddingEffect(
        int number, IContinuousEffectWithCreaturesAndIntegerFactory factory)
        : base(1, 1, true)
    {
        this.number = number;
        this.factory = factory;
    }

    public CreatureSelectionIntegerAffectingContinuousEffectAddingEffect(
        CreatureSelectionIntegerAffectingContinuousEffectAddingEffect effect)
        : base(effect)
    {
        number = effect.number;
        factory = effect.factory;
    }

    public override IOneShotEffect Copy()
    {
        return new CreatureSelectionIntegerAffectingContinuousEffectAddingEffect(
            this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(
            Ability,
            factory.Create(cards, number));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
