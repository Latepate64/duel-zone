using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Destroy a creature.
/// </summary>
public sealed class ChooseAndDestroyCreatureEffect : DestroyEffect
{
    private readonly ICardFilter filter;

    public ChooseAndDestroyCreatureEffect(ICardFilter filter) : base(1, 1, true)
    {
        this.filter = filter;
    }

    public ChooseAndDestroyCreatureEffect(
        ChooseAndDestroyCreatureEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ChooseAndDestroyCreatureEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(Applier, filter, game);
    }
}
