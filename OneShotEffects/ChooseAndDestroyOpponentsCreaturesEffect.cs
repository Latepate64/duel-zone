using Interfaces;

namespace OneShotEffects;

public sealed class ChooseAndDestroyOpponentsCreaturesEffect : DestroyEffect
{
    private readonly ICardFilter filter;

    public ChooseAndDestroyOpponentsCreaturesEffect(
        int min, int max, ICardFilter filter) : base(min, max, true)
    {
        this.filter = filter;
    }

    public ChooseAndDestroyOpponentsCreaturesEffect(
        ChooseAndDestroyOpponentsCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ChooseAndDestroyOpponentsCreaturesEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
    }
}
