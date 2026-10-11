using Interfaces;

namespace OneShotEffects;

public sealed class ChooseAndDestroyCreaturesEffect : DestroyEffect
{
    private readonly ICardFilter filter;

    public ChooseAndDestroyCreaturesEffect(
        int min, int max, ICardFilter filter) : base(min, max, true)
    {
        this.filter = filter;
    }

    public ChooseAndDestroyCreaturesEffect(
        ChooseAndDestroyCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ChooseAndDestroyCreaturesEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(Applier, filter, game);
    }
}
