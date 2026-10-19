using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class CreatureSelectionIntegerAffectingContinuousEffectAddingEffect
    : CreatureSelectionEffect
{
    private readonly IContinuousEffectWithAbilitiesAndCreaturesFactory factory;
    private readonly IAbility[] abilities;
    private readonly IDuration duration;

    public CreatureSelectionIntegerAffectingContinuousEffectAddingEffect(
        IContinuousEffectWithAbilitiesAndCreaturesFactory factory,
        IDuration duration,
        params IAbility[] abilities)
        : base(1, 1, true)
    {
        this.factory = factory;
        this.abilities = abilities;
        this.duration = duration;
    }

    public CreatureSelectionIntegerAffectingContinuousEffectAddingEffect(
        CreatureSelectionIntegerAffectingContinuousEffectAddingEffect effect)
        : base(effect)
    {
        factory = effect.factory;
        abilities = [.. effect.abilities.Select(x => x.Copy())];
        duration = effect.duration.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new CreatureSelectionIntegerAffectingContinuousEffectAddingEffect(this);
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] creatures)
    {
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(abilities, creatures));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
