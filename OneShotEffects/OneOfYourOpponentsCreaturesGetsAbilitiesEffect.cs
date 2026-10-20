using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class OneOfYourOpponentsCreaturesGetsAbilitiesEffect : CreatureSelectionEffect
{
    private readonly IAbility[] abilities;
    private readonly ICardFilter filter;
    private readonly IContinuousEffectWithAbilitiesAndCreaturesFactory factory;
    private readonly IDuration duration;

    public OneOfYourOpponentsCreaturesGetsAbilitiesEffect(
        ICardFilter filter,
        IContinuousEffectWithAbilitiesAndCreaturesFactory factory,
        IDuration duration,
        params IAbility[] abilities) : base(1, 1, true)
    {
        this.abilities = abilities;
        this.filter = filter;
        this.factory = factory;
        this.duration = duration;
    }

    public OneOfYourOpponentsCreaturesGetsAbilitiesEffect(
        OneOfYourOpponentsCreaturesGetsAbilitiesEffect effect) : base(effect)
    {
        abilities = [.. effect.abilities.Select(x => x.Copy())];
        filter = effect.filter.Copy();
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] creatures)
    {
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(abilities, creatures));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier.Opponent, filter);
    }

    public override IOneShotEffect Copy()
    {
        return new OneOfYourOpponentsCreaturesGetsAbilitiesEffect(this);
    }
}
